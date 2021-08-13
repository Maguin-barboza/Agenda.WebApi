namespace Agenda.WebApi.Model.Models_Endereco
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Bairro Bairro { get; set; }
        public int IdBairro { get; set; }
        public Cidade Cidade { get; set; }
        public int IdCidade { get; set; }
    }
}