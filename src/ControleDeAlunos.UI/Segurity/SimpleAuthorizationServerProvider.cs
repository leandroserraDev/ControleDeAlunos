using ControleDeAlunos.Domain.Interfaces.Repositories;
using ControleDeAlunos.Infra.Data;
using ControleDeAlunos.Infra.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ControleDeAlunos.UI.Segurity
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioRepository usuarioRepository = new UsuarioRepository(new DataContext());

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
             context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = usuarioRepository.Autenticar(context.UserName, context.Password);

            if(user == false)
            {
                context.SetError("invalid_grant", "Nome ou password inválido");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}