using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Core.Common.Domain;
using Atividade02.Proposals.Application.Proposals.Commands.Views;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Stores.Interfaces;
using MediatR;

namespace Atividade02.Proposals.Application.Proposals.Commands.Handlers
{
    public class CreateProposalCommandHandlers : IRequestHandler<CreateProposalCommand, View>
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IStoreRepository _storeRepository;
        public CreateProposalCommandHandlers(IProposalRepository proposalRepository, IStoreRepository storeRepository)
        {
            _proposalRepository = proposalRepository;
            _storeRepository = storeRepository;
        }

        public async Task<View> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
        {
            Proposal proposal = await _proposalRepository.Get(request.CPF, request.CNPJ);

            if (proposal is not null)
                throw new DomainException("Proposal already exists!");

            var store = await _storeRepository.GetByCNPJ(request.CNPJ);

            if (store is null)
                throw new DomainException("Store not exists!");

            var proponent = new Proponent(request.Name, request.CPF, request.CNPJ, request.Cellphone);
            proposal = new Proposal(proponent, store, request.Notes);

            _proposalRepository.Add(proposal);

            await _proposalRepository.unitOfWork.Commit();

            return new CreateProposalCommandView(proposal);
        }
    }
}

