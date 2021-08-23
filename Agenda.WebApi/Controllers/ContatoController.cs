using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController: ControllerBase
    {
        private readonly AgendaContext _context;
		private readonly IRepository _repository;

		public ContatoController(IRepository repository, AgendaContext context)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Contatos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Contato contato = _context.Tbl_Contatos.FirstOrDefault(cont => cont.Id == id);
            if(contato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(contato);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            Contato contato = _context.Tbl_Contatos.FirstOrDefault(cont => 
                cont.Nome.Contains(nome) && cont.Nome.Contains(sobrenome));
            
            if(contato is null)
                return BadRequest("Não foi possível encontrar registro com nome e sobrenome especificado.");
            
            return Ok(contato);
        }

        [HttpPost]
        public IActionResult Post(Contato contato)
        {
            _repository.Add(contato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, Contato contato)
        {
            Contato contatoAux = _context.Tbl_Contatos.AsNoTracking().FirstOrDefault(cont => cont.Id == Id);
            
            if(contatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Update(contato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível alterar o registro.");
            
            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Contato contatoAux = _context.Tbl_Contatos.FirstOrDefault(cont => cont.Id == Id);
            
            if(contatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(contatoAux);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível deletar o registro.");
            
            return Ok($"Contato {contatoAux.Nome} foi deletado com sucesso.");
        }
    }
}