using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
        [MaxLength(13)]
        public string Numero { get; set; }
        public bool IsFax { get; set; }
    }
}