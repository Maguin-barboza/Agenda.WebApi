using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;
using System.Linq;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly AgendaContext _context;

        public CidadeController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Cidades);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Cidade cid = _context.Tbl_Cidades.FirstOrDefault(cid => cid.Id == id);

            if (cid is null)
                BadRequest("Não foi possível encontrar alguma cidade com este id.");

            return Ok(cid);
        }

        [HttpGet("byIdEstado/{IdEstado}")]
        public IActionResult GetByEstado(int IdEstado)
        {
            IQueryable<Cidade> cidades = _context.Tbl_Cidades.Where(cid => cid.IdEstado == IdEstado);

            if (cidades is null)
                return BadRequest("Não existe cidades cadastradas para este estado.");

            return Ok(cidades);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            Cidade cidade = _context.Tbl_Cidades.FirstOrDefault(cid => cid.Nome.Contains(nome));

            if (cidade is null)
                return BadRequest("Não existe cidade com este nome.");

            return Ok(cidade);
        }

        [HttpPost]
        public IActionResult Post(Cidade cidade)
        {
            _context.Tbl_Cidades.Add(cidade);

            if (_context.SaveChanges() == 0)
                return BadRequest("Não foi possível incluir registro.");


            return Ok(cidade);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Cidade cidade)
        {
            Cidade cidadeAux = _context.Tbl_Cidades.FirstOrDefault(cid => cid.Id == Id);

            if (cidadeAux is null)
                return BadRequest("Não foi possível encontrar cidade para alteração.");

            _context.Tbl_Cidades.Update(cidade);
            if (_context.SaveChanges() > 0)
                return BadRequest("Não foi possível alterar registro.");

            return Ok(cidade);



        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Cidade cidadeAux = _context.Tbl_Cidades.FirstOrDefault(cid => cid.Id == Id);

            if (cidadeAux is null)
                return BadRequest("Não foi possível encontrar cidade para alteração.");
            
            _context.Tbl_Cidades.Remove(cidadeAux);
            
            if (_context.SaveChanges() > 0)
                return BadRequest("Não foi possível excluir registro.");
            
            return Ok($"Cidade {cidadeAux.Nome} excluída com sucesso.");
        }
    }
}