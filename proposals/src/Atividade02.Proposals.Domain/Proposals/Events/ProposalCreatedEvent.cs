using System;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Events
{
    public class ProposalCreatedEvent : Event
    {
        public ProposalCreatedEvent(string id, string cpf, string cnpj)
            :
        base("proposals", "proposal-created")
        {
            Id = id;
            CPF = cpf;
            CNPJ = cnpj;
        }

        public string Id
        {
            get;
            private set;
        }

        public string CPF {
            get;
            private set;
        }

        public string CNPJ
        {
            get;
            private set;
        }

    }
}

