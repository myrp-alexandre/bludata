using System.Collections.Generic;

namespace api_bludata.domain.domain.models
{
    public class telefone
    {
        public int telefone_id { get; set; }
        public string numero { get; set; }
        public int fornecedor_id { get; set; }

        public fornecedor fornecedor { get; set; }
    }
}
