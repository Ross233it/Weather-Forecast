using SoapCore;
using WsSoapTranslator.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<ISoapTranslator, SoapTranslator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints => { 
    endpoints.UseSoapEndpoint<ISoapTranslator>("/", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();
