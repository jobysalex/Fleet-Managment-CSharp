using Fleet_Managment.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Fleet_Managment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxiController : ControllerBase
    {
        private readonly ContextDB _context;
        public TaxiController(ContextDB context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetTaxis(int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Taxis
                .Select(t => new { id = t.Id, plate = t.Plate })
                .OrderBy(t => t.id);
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return Ok(new { items, totalCount });
        }

    }
}