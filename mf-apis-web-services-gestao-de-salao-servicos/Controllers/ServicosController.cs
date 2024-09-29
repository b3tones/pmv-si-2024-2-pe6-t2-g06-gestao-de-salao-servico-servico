using mf_apis_web_services_gestao_de_salao_servicos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_gestao_de_salao_servicos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.ServicoCategorias.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ServicoCategoria model)
        {
            _context.ServicoCategorias.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.ServicoCategorias
                //.Include(t => t.Usuario).ThenInclude(t => t.Usuario)
                .Include( t => t.ServicoSubCategorias)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ServicoCategoria model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.ServicoCategorias.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (modeloDb == null) return NotFound();
            _context.ServicoCategorias.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.ServicoCategorias.FindAsync(id);
            if (model == null) return NotFound();
            _context.ServicoCategorias.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private void GerarLinks(ServicoCategoria model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));
        }

        [HttpPost("{id}/usuarios")]
        public async Task<ActionResult> AddUsuario(int id, ServicoUsuarios model)
        {
            if(id != model.ServicoCategoriaId) return BadRequest();
            _context.ServicosUsuarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { ID = model.ServicoCategoriaId }, model);

        }


        [HttpDelete("{id}/usuarios/{usuarioId}")]
        public async Task<ActionResult> DeleteUsuario(int id, int usuarioId)
        {
            var model = await _context.ServicosUsuarios
                .Where(c => c.ServicoCategoriaId == id && c.UsuariosId == usuarioId)
                .FirstOrDefaultAsync();

            if(model == null) return NotFound();

            _context.ServicosUsuarios .Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
