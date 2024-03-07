using System;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Atividade02.FraudAnalysis.Worker.Workers
{
    //public class PreAnalysisPolicyWorker : BackgroundService
    //{
    //    public PreAnalysisPolicyWorker(ILogger<PreAnalysisPolicyWorker> logger, IServiceProvider serviceProvider) 
    //    {
    //        _logger = logger;
    //        _serviceProvider = serviceProvider;

    //    }

    //    private readonly ILogger<PreAnalysisPolicyWorker> _logger;
    //    private readonly IServiceProvider _serviceProvider;

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        _logger.LogInformation("[WORKER[SEND-EMAIL] - Creating process...");
    //        while (!stoppingToken.IsCancellationRequested)
    //        {
    //            _logger.LogInformation("[WORKER[SEND-EMAIL] - Starting process...");
    //            using (var scope = _serviceProvider.CreateScope())
    //            {
    //                var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBus>();
    //                var mediatorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

    //                messageBus.Subscribe<CreateNotificationCommand>("notifications", "send-notification-Email", Process,
    //                    stoppingToken);
    //                await Task.Delay(-1, stoppingToken);
    //            }
    //        }
    //    }

    //    protected async Task Process(CreateNotificationCommand request)
    //    {
    //        using (var scope = _serviceProvider.CreateScope())
    //        {
    //            var mediatorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
    //            var command = SendNotificationFactory.Create(request);
    //            await mediatorHandler.Send<CreateNotificationCommand>(command);
    //        }
    //    }
    //}
}

