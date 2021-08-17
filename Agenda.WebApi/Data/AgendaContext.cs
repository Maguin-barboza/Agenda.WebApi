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
        public DbSet<Endereco> Tbl_Enderecos_Contato { get; set; }
        public DbSet<TipoEndereco> Tbl_Tipos_Endereco { get; set; }
        public DbSet<Bairro> Tbl_Bairros { get; set; }
        public DbSet<Cidade> Tbl_Cidades { get; set; }
        public DbSet<Estado> Tbl_Estados { get; set; }
        public DbSet<EmailContato> Tbl_Emails_Contato { get; set; }
        public DbSet<Telefone> Tbl_Telefones_Contato { get; set; }
        public DbSet<TipoContato> Tbl_Tipos_Contato { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estado>()
                .HasData(new List<Estado>(){
                    new Estado(){ Id = 1, Nome = "Minas Gerais", Sigla = "MG"}
                });
            
            builder.Entity<Cidade>()
                .HasData(new List<Cidade>(){
                    new Cidade(){
                        Id = 1,
                        Nome = "Governador Valadares",
                        IdEstado = 1
                    }
                });
            
            builder.Entity<Bairro>()
                .HasData(new List<Bairro>(){
                    new Bairro(){ Id = 1, Descricao = "Grã-Duquesa"}
                });
            
            builder.Entity<TipoEndereco>()
                .HasData(new List<TipoEndereco>(){
                    new TipoEndereco(){
                        Id = 1,
                        Descricao = "Casa"
                    },
                    new TipoEndereco(){
                        Id = 2,
                        Descricao = "Trabalho"
                    }
                });
            
            builder.Entity<TipoContato>()
                .HasData(new List<TipoContato>(){
                    new TipoContato(){
                        Id = 1,
                        Descricao = "CLIENTE"
                    },
                    new TipoContato(){
                        Id = 2,
                        Descricao = "OUTROS"
                    }
                });
        }
    }
}


//Rm 8.22, 23