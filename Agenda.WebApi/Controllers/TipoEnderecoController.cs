using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model.Models_Endereco;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoEnderecoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public TipoEnderecoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Tipos_Endereco);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            TipoEndereco tipoEndereco = _context.Tbl_Tipos_Endereco.FirstOrDefault(te => te.Id == id);
            
            if(tipoEndereco is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(tipoEndereco);
        }

        [HttpPost]
        public IActionResult Post(TipoEndereco tipoEndereco)
        {
            _context.Tbl_Tipos_Endereco.Add(tipoEndereco);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(tipoEndereco);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, TipoEndereco tipoEndereco)
        {
            TipoEndereco tipoEnderecoAux = _context.Tbl_Tipos_Endereco.FirstOrDefault(te => te.Id == Id);
            
            if(tipoEnderecoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Tipos_Endereco.Update(tipoEndereco);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(tipoEndereco);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            TipoEndereco tipoEnderecoAux = _context.Tbl_Tipos_Endereco.FirstOrDefault(te => te.Id == Id);
            
            if(tipoEnderecoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Tipos_Endereco.Remove(tipoEnderecoAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Tipo Endereço foi deletado com sucesso.");
        }
    }
}