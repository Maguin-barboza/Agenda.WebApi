using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Model;
using System.Threading.Tasks;
using Agenda.WebApi.Helpers;

namespace Agenda.WebApi.Data
{
	public class Repository: IRepository
	{
		private readonly AgendaContext _context;

		public Repository(AgendaContext context)
		{
			_context = context;

		}

		public void Add<T>(T Entity) where T : class
		{
			_context.Add(Entity);
		}

		public void Update<T>(T Entity) where T : class
		{
			_context.Update(Entity);
		}

		public void Delete<T>(T Entity) where T: class
		{
			_context.Remove(Entity);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() > 0);
		}

		public TipoContato[] GetAllTipoContato()
		{
			IQueryable<TipoContato> Query = _context.Tbl_Tipos_Contato;

			Query = Query.AsNoTracking()
						 .Include(tc => tc.Contatos)
						 .ThenInclude(cont => cont.TelefonesContato)
						 .Include(tc => tc.Contatos).ThenInclude(cont => cont.EmailsContato)
						 .OrderBy(tc => tc.Id);
			
			return Query.ToArray();
		}

		public TipoContato GetTipoContatoById(int Id)
		{
			IQueryable<TipoContato> Query = _context.Tbl_Tipos_Contato;
			return Query.FirstOrDefault(tc => tc.Id == Id);
		}

		public Contato[] GetAllContatos()
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;

			Query = Query.AsNoTracking()
						 .Include(cont => cont.TelefonesContato)
						 .Include(cont => cont.EmailsContato)
						 .Include(cont => cont.Tipo)
						 .OrderBy(contato => contato.Nome);
			return Query.ToArray();
		}

		public async Task<PageList<Contato>> GetAllContatosAsync(Paginations pageConfig)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;

			Query = Query.AsNoTracking()
						 .Include(cont => cont.TelefonesContato)
						 .Include(cont => cont.EmailsContato)
						 .Include(cont => cont.Tipo)
						 .OrderBy(contato => contato.Nome);
			
			return await PageList<Contato>.GetPageList(Query, pageConfig.PageNumber, pageConfig.PageSize);
		}
		
		public Contato[] GetContatosByIdTipo(int IdTipoContato)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;
			Query = Query.Where(cont => cont.TipoId == IdTipoContato)
						 .OrderBy(cont => cont.Nome);
			return Query.ToArray();
		}

		public Contato GetByContatoId(int id)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;
			
			Contato contatoAux = Query.Where(contato => contato.Id == id)
			 						  .Include(c => c.TelefonesContato)
								      .Include(c => c.EmailsContato)
									  .Include(c => c.Tipo)
						 			  .FirstOrDefault();
			return contatoAux;
		}

		public Contato GetContatoByName(string nome, string sobrenome)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;
			
			Contato contatoAux = Query.Where(contato => contato.Nome.Contains(nome) && contato.Nome.Contains(sobrenome))
			 						  .Include(c => c.TelefonesContato)
								      .Include(c => c.EmailsContato)
						 			  .FirstOrDefault();
			return contatoAux;
		}

		public Telefone[] GetTelefonesByContatoId(int contatoId)
		{
			IQueryable<Telefone> Query = _context.Tbl_Telefones_Contato;
			return Query.Where(tel => tel.ContatoId == contatoId).ToArray();
		}

		public Telefone GetTelefoneById(int IdTelefone)
		{
			IQueryable<Telefone> Query = _context.Tbl_Telefones_Contato;
			return Query.FirstOrDefault(tel => tel.Id == IdTelefone);
		}

		public EmailContato[] GetEmailsByContatoId(int contatoId)
		{
			IQueryable<EmailContato> Query = _context.Tbl_Emails_Contato;
			
			return Query.Where(email => email.ContatoId == contatoId).ToArray();
		}

		public EmailContato GetEmailById(int IdEmail)
		{
			IQueryable<EmailContato> Query = _context.Tbl_Emails_Contato;
			return Query.FirstOrDefault(email => email.Id == IdEmail);
		}
	}
}