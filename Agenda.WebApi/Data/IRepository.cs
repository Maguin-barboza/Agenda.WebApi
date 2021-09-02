using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.WebApi.Helpers;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        bool SaveChanges();

        TipoContato[] GetAllTipoContato();
        TipoContato GetTipoContatoById(int Id);

        Contato[] GetAllContatos();
        Task<PageList<Contato>> GetAllContatosAsync(Paginations pageConfig);
        Contato[] GetContatosByIdTipo(int IdTipoContato);
        Contato GetByContatoId(int id);
        Contato GetContatoByName(string Nome, string sobrenome);

        Telefone[] GetTelefonesByContatoId(int contatoId);
		Telefone GetTelefoneById(int IdTelefone);

        EmailContato[] GetEmailsByContatoId(int contatoId);
		EmailContato GetEmailById(int IdEmail);
    }
}