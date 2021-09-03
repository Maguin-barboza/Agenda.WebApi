using System;

namespace Agenda.WebApi.DTOs
{
    public class ContatoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string DataAniversario { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
    }
}