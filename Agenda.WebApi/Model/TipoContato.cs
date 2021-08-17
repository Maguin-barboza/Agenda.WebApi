using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.Model
{
    public class TipoContato
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
    }
}