using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.Model
{
    public class EmailContato
    {
        public int Id { get; set; }
        public int ContatoId { get; set; }
        public Contato Contato { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
    }
}