using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Domain.Interfaces.Services;
using ControleDeAlunos.Domain.Services;
using ControleDeAlunos.Infra.Repositories;
using ControleDeAlunos.Service.Interface;
using ControleDeAlunos.Service.Services;
using ControleDeAlunos.UI.App_Start;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ControleDeAlunos.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var resolver = new Dependencies();

            // Serviços e configuração da API da Web
             resolver.Register(config);
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
