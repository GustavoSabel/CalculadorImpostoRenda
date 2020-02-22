using CalculadorImpostoRenda.Dominio.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CalculadorImpostoRenda.API.Extensions
{
    static class ExceptionHandlerExtension
    {
        public static void UseTratamentoErros(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature.Error != null)
                    {
                        if (exceptionHandlerPathFeature.Error is ValidacaoException validacaoEntidade)
                        {
                            context.Response.StatusCode = 400;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Mensagem = validacaoEntidade.Message }));
                            return;
                        }
                        else
                        {
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new {
                                Mensagem = exceptionHandlerPathFeature.Error.Message, 
                                Exception = exceptionHandlerPathFeature.Error.ToString() 
                            }));
                            return;
                        }
                    }

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Ocorreu algum erro no sistema");
                });
            });
        }
    }
}
