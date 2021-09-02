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
	public class TipoContatoController : ControllerBase
	{
		private readonly IRepository _repository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public TipoContatoController(IRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Busca todos os tipos de contatos.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_repository.GetAllTipoContato());
		}

		/// <summary>
		/// Busca tipo de contato de acordo com seu Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("byId/{id}")]
		public IActionResult GetById(int id)
		{
			TipoContato tipoContato = _repository.GetTipoContatoById(id);

			if (tipoContato is null)
				return BadRequest("Não existe registro com id especificado.");

			return Ok(tipoContato);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tipoContato"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post(TipoContato tipoContato)
		{
			_repository.Add(tipoContato);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível incluir o registro.");

			return Ok(tipoContato);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tipoContato"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public IActionResult Put(int id, TipoContato tipoContato)
		{
			TipoContato tipoContatoAux = _repository.GetTipoContatoById(id);

			if (tipoContatoAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Update(tipoContato);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar alteração do registro.");

			return Ok(tipoContato);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			TipoContato tipoContatoAux = _repository.GetTipoContatoById(id);

			if (tipoContatoAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Delete(tipoContatoAux);

			if (_repository.SaveChanges())
				return BadRequest("Não foi possível realizar a exclusão do registro");

			return Ok($"Tipo Contato foi deletado com sucesso.");
		}
	}
}