using System;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Stores
{
    public class Store : AggregateRoot
    {
        protected Store()
        {
        }

        public Store(FantasyName name, CNPJ myProperty)
        {
            Name = name;
            MyProperty = myProperty;
        }

        public FantasyName Name
        {
            get;
            private set;
        }

        public CNPJ MyProperty
        {
            get;
            private set;
        }
    }
}

