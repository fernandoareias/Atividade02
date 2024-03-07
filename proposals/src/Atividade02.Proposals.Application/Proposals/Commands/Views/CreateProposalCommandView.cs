using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;

namespace Atividade02.Proposals.Application.Proposals.Commands.Views
{
    public class CreateProposalCommandView : View
    {
        public CreateProposalCommandView(Proposal proposal)
        {

        }

        public Guid Id
        {
            get;
            private set;
        }

        public string Status{
            get;
            private set;
        }
    }
}

