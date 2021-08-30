using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneContatoController: ControllerBase
    {
		private readonly IRepository _repository;

		public TelefoneContatoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("byIdContato/{idContato}")]
        public IActionResult GetByIdContato(int idContato)
        {
            Telefone[] telefonesContato = _repository.GetTelefonesByContatoId(idContato);
            return Ok(telefonesContato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Telefone telefone = _repository.GetTelefoneById(id);
            return Ok(telefone);
        }

        [HttpPost]
        public IActionResult Post(Telefone telefone)
        {
            _repository.Add(telefone);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(telefone);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Telefone telefone)
        {
            Telefone telefoneAux = _repository.GetTelefoneById(Id);
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Update(telefone);
            
            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(telefone);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Telefone telefoneAux = _repository.GetTelefoneById(Id);;
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(telefoneAux);

            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Telefone foi deletado com sucesso.");
        }
    }
}