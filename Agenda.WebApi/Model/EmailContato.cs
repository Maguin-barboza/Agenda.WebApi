using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.Model
{
    public class EmailContato
    {
        public int Id { get; set; }
        public int IdContato { get; set; }
        public EmailContato Contato { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        
    }
}