using System;
using Atividade02.Proponent.API.Events;
using Atividade02.Proponent.API.Models.Interfaces;
using Atividade02.Proponent.API.Models.Interfaces.Services;

namespace Atividade02.Proponent.API.Services
{
    public class ProponentServices : IProponentServices
    {
        private readonly ILogger<ProponentServices> _logger;
        private readonly IProponentRepository _proponentRepository;
       
        public ProponentServices(ILogger<ProponentServices> logger, IProponentRepository proponentRepository)
        {
            _logger = logger;
            _proponentRepository = proponentRepository;
        }

        public async Task Create(ProposalApprovedEvent request)
        {
            _logger.LogInformation("Init create proponent...");

            var proponente = new Models.Proponent(Guid.NewGuid().ToString(), request.Proponent.Name, request.Proponent.CPF, request.Proponent.DDD, request.Proponent.CellphoneNumber);

            _proponentRepository.Add(proponente);

            await _proponentRepository.unitOfWork.Commit();

            _logger.LogInformation($"Proponent {proponente.CPF} created.");
        }
    }
}

