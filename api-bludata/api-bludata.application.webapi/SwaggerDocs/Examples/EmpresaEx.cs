using api_bludata.domain.domain.models;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_bludata.application.webapi.SwaggerDocs.Examples
{
    public class EmpresaEx : IExamplesProvider
    {
        public object GetExamples()
        {
            return new empresa
            {
                cnpj = "00266953000104",
                nome_fantasia = "Estevão S.A",
                estado_id = 1                
            };
        }
    }
}
