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

		public Contato GetByIdContato(int id)
		{
			IQueryable<Contato> Query = _context.Tbl_Contatos;
			
			Contato contatoAux = Query.Include(contato => contato.TelefonesContato.Where(telefone => telefone.ContatoId == id))
						 			  .FirstOrDefault(cont => cont.Id == id);
			
			return contatoAux;
		}

		public Contato GetContatoByName(string Nome, string sobrenome)
		{
			throw new System.NotImplementedException();
		}

		public Telefone[] GetAllTelefonesContato(int IdContato)
		{
			throw new System.NotImplementedException();
		}

		public EmailContato[] GetAllEmailsContato(int IdContato)
		{
			throw new System.NotImplementedException();
		}
	}
}