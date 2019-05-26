namespace api_bludata.domain.domain.models
{
    public class empresa
    {
        public string cnpj { get; set; }
        public string nome_fantasia { get; set; }
        public int estado_id { get; set; }

        public estado estado { get; set; }
    }
}
