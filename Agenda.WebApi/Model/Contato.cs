using System;
using System.ComponentModel.DataAnnotations;

//using Agenda.WebApi.Model.Models_Endereco;

namespace Agenda.WebApi.Model
{
    public class Contato
    {
        public int Id { get; set; }
        [MaxLength(70)]
        public string Nome { get; set; }
        [MaxLength(70)]
        public string Sobrenome { get; set; }
        public int IdTipoContato { get; set; }
        public TipoContato Tipo { get; set; }
        [MaxLength(50)]
        public string Endereco { get; set; }
        [MaxLength(50)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }
        public DateTime DataAniversario { get; set; }
        [MaxLength(50)]
        public string HomePage { get; set; }
        public string Observacao { get; set; }
    }
}