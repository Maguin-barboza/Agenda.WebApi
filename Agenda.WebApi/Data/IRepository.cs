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
        Contato GetByIdContato(int id);
        Contato GetContatoByName(string Nome, string sobrenome);
        
        Telefone[] GetAllTelefonesContato(int IdContato);
        
        EmailContato[] GetAllEmailsContato(int IdContato);
    }
}