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
        private readonly AgendaContext _context;
		private readonly IRepository _repository;

		public EmailContatoController(IRepository repository, AgendaContext context)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Emails_Contato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            EmailContato emailContato = _context.Tbl_Emails_Contato.FirstOrDefault(email => email.Id == id);
            if(emailContato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(emailContato);
        }

        [HttpPost]
        public IActionResult Post(EmailContato emailContato)
        {
            _repository.Add(emailContato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(emailContato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, EmailContato emailContato)
        {
            EmailContato emailContatoAux = _context.Tbl_Emails_Contato.AsNoTracking().FirstOrDefault(email => email.Id == Id);
            
            if(emailContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Update(emailContato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível alterar o registro.");
            
            return Ok(emailContato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            EmailContato emailContatoAux = _context.Tbl_Emails_Contato.FirstOrDefault(email => email.Id == Id);
            
            if(emailContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(emailContatoAux);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível deletar o registro.");
            
            return Ok($"Email do contato {emailContatoAux.Email} foi deletado com sucesso.");
        }
    }
}