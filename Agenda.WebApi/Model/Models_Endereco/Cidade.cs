namespace Agenda.WebApi.Model.Models_Endereco
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
        
    }
}