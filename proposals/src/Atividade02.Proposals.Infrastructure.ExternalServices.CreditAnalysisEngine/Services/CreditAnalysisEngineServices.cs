using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.Interfaces;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine;

public class CreditAnalysisEngineServices : ICreditAnalysisEngineServices
{
    private readonly IMessageBus _messageBus;

    public CreditAnalysisEngineServices(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task<ExecuteFormalizationResponse> ExecuteFormalization(ExecuteFormalizationRequest request)
    {
        return await _messageBus.RPCClient<ExecuteFormalizationResponse>(
           "credit-analysis-engine",
           "execute-formalization",
           request.CorrelationId,
           request
           );
    }

    public async Task<ExecuteFraudAnalysisResponse> ExecuteFraudAnalysis(ExecuteFraudAnalysisRequest request)
    {
        return await _messageBus.RPCClient<ExecuteFraudAnalysisResponse>(
           "credit-analysis-engine",
           "execute-fraud-analysis",
           request.CorrelationId,
           request
           );
    }

    public async Task<ExecutePreAnalysisResponse> ExecutePreAnalysis(ExecutePreAnalysisRequest request)
    {
        return await _messageBus.RPCClient<ExecutePreAnalysisResponse>(
            "credit-analysis-engine",
            "execute-pre-analysis",
            request.CorrelationId,
            request
            );
    }
}

