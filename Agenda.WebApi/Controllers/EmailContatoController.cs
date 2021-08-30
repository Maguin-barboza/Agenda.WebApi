using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailContatoController: ControllerBase
    {
		private readonly IRepository _repository;

		public EmailContatoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("byIdContato/{idContato}")]
        public IActionResult GetByIdContato(int contatoId)
        {
            EmailContato[] emailsContato = _repository.GetEmailsByContatoId(contatoId);
            return Ok(emailsContato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            EmailContato email = _repository.GetEmailById(id);
            return Ok(email);
        }

        [HttpPost]
        public IActionResult Post(EmailContato email)
        {
            _repository.Add(email);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(email);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, EmailContato email)
        {
            EmailContato emailAux = _repository.GetEmailById(Id);
            
            if(emailAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Update(email);
            
            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(email);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            EmailContato emailAux = _repository.GetEmailById(Id);;
            
            if(emailAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(emailAux);

            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Email foi deletado com sucesso.");
        }
    }
}