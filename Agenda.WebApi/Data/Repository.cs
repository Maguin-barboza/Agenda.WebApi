using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Model;

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

		public Contato[] GetAllContatos()
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;

			Query = Query.AsNoTracking().OrderBy(contato => contato.Nome);
			return Query.ToArray();
		}

		public Contato GetByContatoId(int id)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;
			
			Contato contatoAux = Query.Where(contato => contato.Id == id)
			 						  .Include(c => c.TelefonesContato)
								      .Include(c => c.EmailsContato)
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
			IQueryable<Telefone> Query = _context.Tbl_Telefones_Contato
								 .Where(tel => tel.ContatoId == contatoId);
			
			return Query.ToArray();
		}

		public Telefone GetTelefoneById(int IdTelefone)
		{
			return _context.Tbl_Telefones_Contato
				   .FirstOrDefault(tel => tel.Id == IdTelefone);
		}

		public EmailContato[] GetEmailsByContatoId(int contatoId)
		{
			IQueryable<EmailContato> Query = _context.Tbl_Emails_Contato
								 			 .Where(email => email.ContatoId == contatoId);
			
			return Query.ToArray();
		}

		public EmailContato GetEmailById(int IdEmail)
		{
			return _context.Tbl_Emails_Contato
				   .FirstOrDefault(email => email.Id == IdEmail);
		}
	}
}