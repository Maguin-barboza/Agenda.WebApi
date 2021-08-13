using System;

using Agenda.WebApi.Model.Models_Endereco;

namespace Agenda.WebApi.Model
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int IdTipoContato { get; set; }
        public TipoContato Tipo { get; set; }
        public Endereco EnderecoContato { get; set; }
        public DateTime DataAniversario { get; set; }
        public string HomePage { get; set; }
        public string Observacao { get; set; }
    }
}