using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Services;

namespace Atividade02.Proposals.Domain.Services.Services
{
    public class FormalizationPolicyServices : IFormalizationPolicyServices
    {
        public Task<FormalizationPolicy> Process(Proposal aggregate)
        {
            throw new NotImplementedException();
        }
    }
}

