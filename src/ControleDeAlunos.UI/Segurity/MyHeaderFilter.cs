using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ControleDeAlunos.UI.Segurity
{
    public class MyHeaderFilter : IDocumentFilter, IOperationFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/Login", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Login" },
                    consumes = new List<string>
                {
                    "application/x-www-form-urlencoded"
                },
                    parameters = new List<Parameter> {
                    new Parameter
                    {
                        type = "string",
                        name = "grant_type",
                        required = true,
                        @in = "formData",
                        description = "password"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "username",
                        required = true,
                        @in = "formData",
                        description = "Usuário"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "password",
                        required = true,
                        @in = "formData",
                        description = "Senha"
                    }
                    }
                }
            });

        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {

            if (operation.parameters == null)
                operation.parameters = new List<Swashbuckle.Swagger.Parameter>();

            operation.parameters.Add(new Swashbuckle.Swagger.Parameter
            {
                name = "Authorization",
                type = "string",
                @in = "header",
                required = true // set to false if this is optional
            });
        }
    }
}