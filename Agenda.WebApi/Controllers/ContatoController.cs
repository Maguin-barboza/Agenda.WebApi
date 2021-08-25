using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;
using Agenda.WebApi.DTOs;

namespace Agenda.WebApi.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class ContatoController: ControllerBase
    {
		private readonly IRepository _repository;
		private readonly IMapper _mapper;

		public ContatoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _repository.GetAllContatos();
            return Ok(_mapper.Map<IEnumerable<ContatoDto>>(contatos));
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Contato contato = _repository.GetByContatoId(id);
            
            if(contato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            ContatoDto contatoDto = _mapper.Map<ContatoDto>(contato);
            return Ok(contatoDto);
        }

        [HttpGet("byIdTipoContato/{IdTipoContato}")]
        public IActionResult GetByIdTipoContato(int IdTipoContato)
        {
            Contato[] contatos = _repository.GetContatosByIdTipo(IdTipoContato);

            var contatosDto = _mapper.Map<IEnumerable<ContatoDto>>(contatos);
            return Ok(contatosDto);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            Contato contato = _repository.GetContatoByName(nome, sobrenome);
            ContatoDto contDto = _mapper.Map<ContatoDto>(contato);

            if(contato is null)
                return BadRequest("Não foi possível encontrar registro com nome e sobrenome especificado.");
            
            return Ok(contDto);
        }

        [HttpPost]
        public IActionResult Post(ContatoDto model)
        {
            Contato contato = _mapper.Map<Contato>(model);
            _repository.Add(contato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Created($"/api/contato/{model.Id}", _mapper.Map<ContatoDto>(contato));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, ContatoDto model)
        {
            Contato contato = _repository.GetByContatoId(Id);
            
            if(contato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _mapper.Map(model, contato);
            _repository.Update(contato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível alterar o registro.");
            
            return Created($"/api/Contato/{model.Id}", contato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Contato contatoAux = _repository.GetByContatoId(Id);
            
            if(contatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(contatoAux);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível deletar o registro.");
            
            return Ok($"Contato {contatoAux.Nome} foi deletado com sucesso.");
        }
    }
}