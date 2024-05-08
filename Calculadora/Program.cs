using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;
using System.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddSoapCore();
builder.Services.AddSingleton<ICalculadoraService, CalculadoraService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// Usa casting explícito para clarificar cuál sobrecarga usar
(app as IApplicationBuilder).UseSoapEndpoint<ICalculadoraService>(
    "/CalculadoraService.asmx",
    new SoapEncoderOptions(),
    SoapSerializer.DataContractSerializer);

app.Run();
