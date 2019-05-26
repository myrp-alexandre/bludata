using api_bludata.domain.domain.models;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_bludata.application.webapi.SwaggerDocs.Examples
{
    public class FornecedorEx : IExamplesProvider
    {
        public object GetExamples()
        {
            var telefones = new List<telefone>(); ;
            telefones.Add(new telefone { numero = "5545888888888" });

            return new fornecedor
            {
                nome = "Claudionei Tomazoni",
                data_cadastro = DateTime.Now,
                empresa_cnpj = "77854081000111",
                cpf = "84955012019",
                pessoa_fisica = new pessoa_fisica { cpf = "84955012019", data_nascimento = DateTime.Parse("1990-01-01") },
                telefones = telefones
            };
        }
    }

    public class FornecedorUpdateEx : IExamplesProvider
    {
        public object GetExamples()
        {
            var telefones = new List<telefone>(); ;
            telefones.Add(new telefone { numero = "5545888888888" });

            return new fornecedor
            {
                fornecedor_id = 1,
                nome = "Fornecedor Update",
                data_cadastro = DateTime.Now,
                empresa_cnpj = "77854081000111",
                cpf = "84955012019",
                pessoa_fisica = new pessoa_fisica { cpf = "84955012019", data_nascimento = DateTime.Parse("1990-01-01") },
                telefones = telefones
            };
        }
    }

    public class FornecedorDeleteEx : IExamplesProvider
    {
        public object GetExamples()
        {
            var telefones = new List<telefone>(); ;
            telefones.Add(new telefone { telefone_id = 1 });

            return new fornecedor
            {
                fornecedor_id = 1,
                pessoa_fisica = new pessoa_fisica { cpf = "84955012019" },
                telefones = telefones
            };
        }
    }
}
