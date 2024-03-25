using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Application.Proposals.Queries
{
    [DataContract]
    public class GetListProposalByFilterQuery : QueryList
    {
        public GetListProposalByFilterQuery(string? cpf, string? cnpj)
        {
            CPF = cpf;
            CNPJ = cnpj;
        }

        protected GetListProposalByFilterQuery()
        {

        }


        [DataMember]
        public string? CPF { get; private set; }

        [DataMember]
        public string? CNPJ { get; private set; }
    }
}