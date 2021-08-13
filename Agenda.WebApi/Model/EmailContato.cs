namespace Agenda.WebApi.Model
{
    public class EmailContato
    {
        public int Id { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
        public string Email { get; set; }
        
    }
}