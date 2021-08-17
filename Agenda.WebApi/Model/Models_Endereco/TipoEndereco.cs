using System.ComponentModel.DataAnnotations;

namespace Agenda.WebApi.Model.Models_Endereco
{
    public class TipoEndereco
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
    }
}