using System;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using System.Text;
using Atividade02.Proposals.Infrastructure;
using Atividade02.Proposals.Application;

namespace Atividade02.Proposals.API.Configurations
{
    public static class ApiConfigurations
    {
        public static void ApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ApiInjection(services);
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        private static void ApiInjection(this IServiceCollection services)
        {
            services.AddProposalInfrastructure();
            services.AddProposalApplication();
        }
    }
}

