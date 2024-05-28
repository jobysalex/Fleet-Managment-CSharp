using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fleet_Managment.Context;
namespace Fleet_Managment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrajectoriesController : ControllerBase
    {
        private readonly ContextDB _context;
        public TrajectoriesController(ContextDB context)
        {
            _context = context;
        }
        [HttpGet("historial")]
        public async Task<IActionResult> GetTrajectories(
            [FromQuery] int taxiId,
            [FromQuery] DateTime date,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            // Convertir la fecha proporcionada a UTC
            var dateUtc = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            var query = _context.Trajectories
                .Where(t => t.TaxiId == taxiId && t.Date.Date == dateUtc.Date);
            var totalRecords = await query.CountAsync();
            var trajectories = await query
                .OrderBy(t => t.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new {
                    t.Latitude,
                    t.Longitude,
                    Timestamp = t.Date
                })
                .ToListAsync();
            if (!trajectories.Any())
            {
                return NotFound(new { Message = "No data found for the given taxi ID and date." });
            }
            var response = new
            {
                Data = trajectories,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)                
            };
            return Ok(response);
        }
    }
}

