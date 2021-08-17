namespace Agenda.WebApi.Model.Models_Endereco
{
    public class Endereco
    {
        public int Id { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
        public int IdTipoEndereco { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Bairro Bairro { get; set; }
        public int IdBairro { get; set; }
        public Cidade Cidade { get; set; }
        public int IdCidade { get; set; }
    }
}