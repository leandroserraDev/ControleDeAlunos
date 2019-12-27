using System.Web.Http;
using WebActivatorEx;
using ControleDeAlunos.UI;
using Swashbuckle.Application;
using System;
using System.Linq;
using ControleDeAlunos.UI.Segurity;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ControleDeAlunos.UI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Controle de aluno");
                    c.DocumentFilter<MyHeaderFilter>();
                    c.OperationFilter<MyHeaderFilter>();

                 
                    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\ControleDeAlunos.UI.xml");             
                  
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                    c.DocumentTitle("Exemplo de utilização do Swagger");
                    c.DocExpansion(DocExpansion.List);
                });
                

        }
    }
}
