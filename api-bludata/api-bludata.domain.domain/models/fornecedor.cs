using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bludata.domain.domain.models
{
    public class fornecedor
    {
        public int fornecedor_id { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cpf { get; set; }
        public string empresa_cnpj { get; set; }
        public string cnpj { get; set; }

        public empresa empresa { get; set; }
        public pessoa_fisica pessoa_fisica { get; set; }
        public ICollection<telefone> telefones { get; set; }
    }
}
