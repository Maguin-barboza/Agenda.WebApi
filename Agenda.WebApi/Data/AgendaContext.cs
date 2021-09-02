using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Model;
using Agenda.WebApi.Model.Models_Endereco;
using System.Collections.Generic;

namespace Agenda.WebApi.Data
{
    public class AgendaContext: DbContext
        {
        public AgendaContext(DbContextOptions<AgendaContext> option) : base(option) {  }
        
        public DbSet<Contato> Tbl_Contatos { get; set; }
        public DbSet<EmailContato> Tbl_Emails_Contato { get; set; }
        public DbSet<Telefone> Tbl_Telefones_Contato { get; set; }
        public DbSet<TipoContato> Tbl_Tipos_Contato { get; set; }
    }
}


//Rm 8.22, 23