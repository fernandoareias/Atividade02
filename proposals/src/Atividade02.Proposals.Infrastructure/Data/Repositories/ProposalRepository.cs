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
            var data = await DbSet.FindAsync(Builders<Proposal>.Filter.Eq("_id", cpf));
            return data.SingleOrDefault();
        }

      
    }
}

