using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class EmailContatoController : ControllerBase
	{
		private readonly IRepository _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public EmailContatoController(IRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Busca todos os emails conforme Id do contato informado.
		/// </summary>
		/// <param name="contatoId"></param>
		/// <returns></returns>
		[HttpGet("byIdContato/{idContato}")]
		public IActionResult GetByIdContato(int contatoId)
		{
			EmailContato[] emailsContato = _repository.GetEmailsByContatoId(contatoId);
			return Ok(emailsContato);
		}

		/// <summary>
		/// Busca email do contato conforme Id do email.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("byId/{id}")]
		public IActionResult GetById(int id)
		{
			EmailContato email = _repository.GetEmailById(id);
			return Ok(email);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post(EmailContato email)
		{
			_repository.Add(email);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível incluir o registro.");

			return Ok(email);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpPut("{Id}")]
		public IActionResult Put(int Id, EmailContato email)
		{
			EmailContato emailAux = _repository.GetEmailById(Id);

			if (emailAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Update(email);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar alteração do registro.");

			return Ok(email);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("{Id}")]
		public IActionResult Delete(int Id)
		{
			EmailContato emailAux = _repository.GetEmailById(Id); ;

			if (emailAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Delete(emailAux);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar a exclusão do registro");

			return Ok($"Email foi deletado com sucesso.");
		}
	}
}