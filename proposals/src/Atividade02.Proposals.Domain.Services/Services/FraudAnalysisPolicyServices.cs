using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Services;

namespace Atividade02.Proposals.Domain.Services.Services
{
    public class FraudAnalysisPolicyServices : IFraudAnalysisPolicyServices
    {
        public Task<FraudAnalysisPolicy> Process(Proposal aggregate)
        {
            throw new NotImplementedException();
        }
    }
}

