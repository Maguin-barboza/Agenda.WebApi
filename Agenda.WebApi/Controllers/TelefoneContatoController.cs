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
	public class TelefoneContatoController : ControllerBase
	{
		private readonly IRepository _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public TelefoneContatoController(IRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Busca todos os telefones através do Id do contato.
		/// </summary>
		/// <param name="idContato"></param>
		/// <returns></returns>
		[HttpGet("byIdContato/{idContato}")]
		public IActionResult GetByIdContato(int idContato)
		{
			Telefone[] telefonesContato = _repository.GetTelefonesByContatoId(idContato);
			return Ok(telefonesContato);
		}

		/// <summary>
		/// Busca 1 telefone através do Id informado
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("byId/{id}")]
		public IActionResult GetById(int id)
		{
			Telefone telefone = _repository.GetTelefoneById(id);
			return Ok(telefone);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="telefone"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post(Telefone telefone)
		{
			_repository.Add(telefone);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível incluir o registro.");

			return Ok(telefone);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="telefone"></param>
		/// <returns></returns>
		[HttpPut("{Id}")]
		public IActionResult Put(int Id, Telefone telefone)
		{
			Telefone telefoneAux = _repository.GetTelefoneById(Id);

			if (telefoneAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Update(telefone);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar alteração do registro.");

			return Ok(telefone);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("{Id}")]
		public IActionResult Delete(int Id)
		{
			Telefone telefoneAux = _repository.GetTelefoneById(Id); ;

			if (telefoneAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Delete(telefoneAux);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar a exclusão do registro");

			return Ok($"Telefone foi deletado com sucesso.");
		}
	}
}