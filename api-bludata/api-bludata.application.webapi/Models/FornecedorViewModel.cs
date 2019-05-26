using System;
using System.Collections.Generic;
using api_bludata.domain.domain.models;

namespace api_bludata.application.webapi.Models
{
    public class FornecedorViewModel
    {
        public int fornecedor_id { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string nome_empresa { get; set; }

        public empresa empresa { get; set; }
        public ICollection<TelefoneViewModel> telefones { get; set; }
    }
}
