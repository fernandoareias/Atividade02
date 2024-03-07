using System.Text;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Factories;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Formalization.Factories;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;
using Atividade02.Proposals.Domain.Proposals.Enums;
using Atividade02.Proposals.Domain.Proposals.Services;

namespace Atividade02.Proposals.Domain.Proposals
{
    public class Proposal : AggregateRoot
    {
        public Proposal(Proponent proponent, Store store, string? notes = null)
        {
            Code = GenerateCode();
            Proponent = proponent;
            Store = store;
            Notes = notes;
        }


        public string Code {
            get;
            private set;
        }

        public EProposalStatus Status
        {
            get;
            private set;
        } = EProposalStatus.PROCESSING;

        public string? Notes
        {
            get;
            private set;
        }

        public Proponent Proponent
        {
            get;
            private set;
        }

        public Store Store
        {
            get;
            private set;
        }

        public List<PreAnalysisPolicy> PreAnalysis
        {
            get;
            private set;
        } = new List<PreAnalysisPolicy>();

        public List<FraudAnalysisPolicy> FraudAnalysis
        {
            get;
            private set;
        } = new List<FraudAnalysisPolicy>();

        public List<FormalizationPolicy> Formalizations
        {
            get;
            private set;
        } = new List<FormalizationPolicy>();


        private string GenerateCode()
        {
            Random random = new Random();

            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder("PP");

            char lastChar = '\0';

            for (int i = 0; i < 12; i++)
            {
                char randomChar;
                do
                {
                    randomChar = chars[random.Next(chars.Length)];
                } while (randomChar == lastChar); // Garante que o mesmo caractere não seja repetido consecutivamente

                sb.Append(randomChar);
                lastChar = randomChar;
            }

            return sb.ToString();
        }

        public async Task Execute(IPreAnalysisPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            AddEvent(PreAnalysisPolicyExecutedFactory.CreateEvent(this, policy));

            PreAnalysis.Add(policy);
        }

        public async void Execute(IFraudAnalysisPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            FraudAnalysis.Add(policy);

            AddEvent(FraudAnalysisPolicyExecutedFactory.CreateEvent(this, policy));

            ChangeStatus(ProposalValidator.GetStatus(GetLastPreAnalysis(), policy));

        }

        public async void Execute(IFormalizationPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            Formalizations.Add(policy);
            AddEvent(FormalizationExecutedFactory.CreateEvent(this, policy));
        }

        private void ChangeStatus(EProposalStatus status)
        {
            Status = status;
        }

        public PreAnalysisPolicy? GetLastPreAnalysis()
            => PreAnalysis.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

        public FraudAnalysisPolicy? GetLastFraudAnalysis()
          => FraudAnalysis.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

        public FormalizationPolicy? GetLastFormalization()
         => Formalizations.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
    }
}

