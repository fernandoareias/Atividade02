using Atividade02.Proposals.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApiConfiguration(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration();
app.Run();

