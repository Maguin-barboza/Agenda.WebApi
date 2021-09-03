using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;
using Agenda.WebApi.DTOs;
using Agenda.WebApi.Helpers;
using System.Threading.Tasks;

namespace Agenda.WebApi.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class ContatoController : ControllerBase
	{
		private readonly IRepository _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="mapper"></param>
		public ContatoController(IRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Busca todos os contatos.
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery]Paginations paginations)
		{
			var contatos = await _repository.GetAllContatosAsync(paginations);
			var contatosResult = _mapper.Map<IEnumerable<ContatoDto>>(contatos);

			Response.AddPagination(contatos.CurrentPage, contatos.TotalPages, contatos.PageSize, contatos.TotalItems);
			return Ok(contatosResult);
		}
		/// <summary>
		/// Busca 1 contato de acordo com o Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("byId/{id}")]
		public IActionResult GetById(int id)
		{
			Contato contato = _repository.GetByContatoId(id);

			if (contato is null)
				return BadRequest("Não existe registro com id especificado.");

			ContatoDto contatoDto = _mapper.Map<ContatoDto>(contato);
			return Ok(contatoDto);
		}
		/// <summary>
		/// Busca todos os contatos de acordo com o Id do TipoContato (Tbl_Tipos_Contatos).
		/// </summary>
		/// <param name="IdTipoContato"></param>
		/// <returns></returns>
		[HttpGet("byIdTipoContato/{IdTipoContato}")]
		public IActionResult GetByIdTipoContato(int IdTipoContato)
		{
			Contato[] contatos = _repository.GetContatosByIdTipo(IdTipoContato);

			var contatosDto = _mapper.Map<IEnumerable<ContatoDto>>(contatos);
			return Ok(contatosDto);
		}

		/// <summary>
		/// Busca 1 contato de acordo com nome e sobrenome.
		/// </summary>
		/// <param name="nome"></param>
		/// <param name="sobrenome"></param>
		/// <returns></returns>
		[HttpGet("byName")]
		public IActionResult GetByName(string nome, string sobrenome)
		{
			Contato contato = _repository.GetContatoByName(nome, sobrenome);
			ContatoDto contDto = _mapper.Map<ContatoDto>(contato);

			if (contato is null)
				return BadRequest("Não foi possível encontrar registro com nome e sobrenome especificado.");

			return Ok(contDto);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post(ContatoRegistrarDto model)
		{
			Contato contato = _mapper.Map<Contato>(model);
			_repository.Add(contato);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível incluir o registro.");

			return Created($"/api/contato/byId/{model.Id}", _mapper.Map<ContatoDto>(contato));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut("{Id}")]
		public IActionResult Put(int Id, ContatoRegistrarDto model)
		{
			Contato contato = _repository.GetByContatoId(Id);

			if (contato is null)
				return BadRequest("Não existe registro com id especificado.");

			_mapper.Map(model, contato);
			_repository.Update(contato);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível alterar o registro.");

			return Created($"/api/Contato/byId/{model.Id}", contato);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("{Id}")]
		public IActionResult Delete(int Id)
		{
			Contato contatoAux = _repository.GetByContatoId(Id);

			if (contatoAux is null)
				return BadRequest("Não existe registro com id especificado.");

			_repository.Delete(contatoAux);

			if (_repository.SaveChanges())
				BadRequest("Não foi possível deletar o registro.");

			return Ok($"Contato {contatoAux.Nome} foi deletado com sucesso.");
		}
	}
}