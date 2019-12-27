using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Domain.Interfaces.Services;
using ControleDeAlunos.Domain.Services;
using ControleDeAlunos.Infra.Repositories;
using ControleDeAlunos.Service.Interface;
using ControleDeAlunos.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace ControleDeAlunos.UI.App_Start
{
    public class Dependencies
    {
        private readonly UnityContainer container = new UnityContainer();



        public void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
          
            container.RegisterType<IAlunoRepository, AlunoRepository>();
            container.RegisterType<IAlunoService, AlunoService>();
            container.RegisterType<IAlunoAppService, AlunoAppService>();
            container.RegisterType<ITurmaRepository, TurmaRepository>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
          
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}