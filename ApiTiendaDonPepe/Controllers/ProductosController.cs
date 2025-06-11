using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiendaDonPepe.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repo;
        public ProductosController(IProductoRepository repo) => _repo = repo;
         
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Productos p)
        {
            var id = await _repo.Create(p);
            return CreatedAtAction(nameof(GetById), new { id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Productos p)
        {
            p.Id = id;
            return await _repo.Update(p) ? Ok(p) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repo.Delete(id) ? NoContent() : NotFound();
        }
    }

}
