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

        public EmailContatoController(AgendaContext context)
        {
            _context = context;
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
            _context.Tbl_Emails_Contato.Add(emailContato);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(emailContato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, EmailContato emailContato)
        {
            EmailContato emailContatoAux = _context.Tbl_Emails_Contato.AsNoTracking().FirstOrDefault(email => email.Id == Id);
            
            if(emailContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Emails_Contato.Update(emailContato);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(emailContato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            EmailContato emailContatoAux = _context.Tbl_Emails_Contato.FirstOrDefault(email => email.Id == Id);
            
            if(emailContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Emails_Contato.Remove(emailContatoAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Email do contato {emailContatoAux.Email} foi deletado com sucesso.");
        }
    }
}