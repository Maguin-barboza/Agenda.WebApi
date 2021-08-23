using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoContatoController: ControllerBase
    {
        private readonly AgendaContext _context;
		private readonly IRepository _repository;

		public TipoContatoController(IRepository repository, AgendaContext context)
        {
            _context = context;
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Tipos_Contato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            TipoContato tipoContato = _context.Tbl_Tipos_Contato.FirstOrDefault(tc => tc.Id == id);
            
            if(tipoContato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(tipoContato);
        }

        [HttpPost]
        public IActionResult Post(TipoContato tipoContato)
        {
            _repository.Add(tipoContato);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(tipoContato);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, TipoContato tipoContato)
        {
            TipoContato tipoContatoAux = _context.Tbl_Tipos_Contato.AsNoTracking().FirstOrDefault(tc => tc.Id == Id);
            
            if(tipoContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _repository.Update(tipoContato);
            
            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(tipoContato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            TipoContato tipoContatoAux = _context.Tbl_Tipos_Contato.FirstOrDefault(tc => tc.Id == Id);
            
            if(tipoContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(tipoContatoAux);

            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Tipo Contato foi deletado com sucesso.");
        }
    }
}