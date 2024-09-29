using mf_apis_web_services_gestao_de_salao_servicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_gestao_de_salao_servicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSubCategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SSubCategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.ServicoSubCategorias.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ServicoSubCategoria model)
        {
            _context.ServicoSubCategorias.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.ServicoSubCategorias
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ServicoSubCategoria model)
        {
            if (id != model.Id) return BadRequest();

            var modeloDb = await _context.ServicoSubCategorias.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.ServicoSubCategorias.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.ServicoSubCategorias.FindAsync(id);
            if (model == null) return NotFound();
            _context.ServicoSubCategorias.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private void GerarLinks(ServicoSubCategoria model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));
        }
    }
}
