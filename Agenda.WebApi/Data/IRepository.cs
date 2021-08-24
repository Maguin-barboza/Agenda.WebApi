using System.Collections.Generic;

using Agenda.WebApi.Model;

namespace Agenda.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        bool SaveChanges();

        Contato[] GetAllContatos();
        Contato GetByContatoId(int id);
        Contato GetContatoByName(string Nome, string sobrenome);

        public Telefone[] GetTelefonesByContatoId(int contatoId);
		public Telefone GetTelefoneById(int IdTelefone);
		
        public EmailContato[] GetEmailsByContatoId(int contatoId);
		public EmailContato GetEmailById(int IdEmail);
    }
}