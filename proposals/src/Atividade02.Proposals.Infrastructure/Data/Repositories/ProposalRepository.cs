using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Proponents;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Infrastructure.Data.Common.Interfaces;
using MongoDB.Driver;
using Notification.Worker.Data.Repositories;

namespace Atividade02.Proposals.Infrastructure.Data.Repositories
{
    public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
    {

        public ProposalRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<Proposal> Get(string cpf, string cnpj)
        {
            var options = new FindOptions<Proposal>
            {
                MaxTime = TimeSpan.FromSeconds(5) // Defina o tempo limite desejado
            };

            var filter = Builders<Proposal>.Filter.And(
                Builders<Proposal>.Filter.Eq("Proponent.CPF.Number", cpf),
                Builders<Proposal>.Filter.Eq("Store.cnpj", cnpj)
                );
             
            var data = await DbSet.FindAsync(filter, options);

            return data.FirstOrDefault();
        }

        public async Task<Proposal?> GetByAggregateId(string aggregateId)
        {
            var options = new FindOptions<Proposal>
            {
                MaxTime = TimeSpan.FromSeconds(5) // Defina o tempo limite desejado
            };

            var filter = Builders<Proposal>.Filter.Eq("AggregateId", aggregateId);

            var data = await DbSet.FindAsync(filter, options);

            return data.FirstOrDefault();
        }
    }
}

