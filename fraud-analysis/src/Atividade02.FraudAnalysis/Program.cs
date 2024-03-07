using Atividade02.Core.Mediator;
using Atividade02.Core.Mediator.Behaviours;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Core.MessageBus.Configurations;
using Atividade02.Core.MessageBus.Services;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.FraudAnalysis.Worker.Workers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddMediatR(services, cfg => cfg.RegisterServicesFromAssemblies(typeof(PreAnalysisPolicyWorker).Assembly));

        services.Configure<MessageBusConfigs>(
            hostContext.Configuration.GetSection(nameof(MessageBusConfigs)));

        services.AddScoped<IMessageBus, MessageBus>();

        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddHostedService<PreAnalysisPolicyWorker>();

    })
    .Build();

await host.RunAsync();