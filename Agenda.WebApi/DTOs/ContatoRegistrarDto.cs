using System;

namespace Agenda.WebApi.DTOs
{
    public class ContatoRegistrarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int TipoId { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public DateTime DataAniversario { get; set; }
        public string HomePage { get; set; }
        public string Observacao { get; set; }
    }
}