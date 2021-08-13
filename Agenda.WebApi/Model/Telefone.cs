namespace Agenda.WebApi.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
        public string Numero { get; set; }
        public bool IsFax { get; set; }
    }
}