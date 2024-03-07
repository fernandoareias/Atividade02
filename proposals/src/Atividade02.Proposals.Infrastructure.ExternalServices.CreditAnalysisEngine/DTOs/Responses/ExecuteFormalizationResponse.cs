﻿using System;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses.Common;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses
{
    public class ExecuteFormalizationResponse : BaseExecutePolicyResponse
    { 
        public ExecuteFormalizationResponse(string externalId, string result) : base(externalId, result)
        {
        }
    }
}

