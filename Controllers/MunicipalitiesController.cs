using Institution.Data;
using Institution.Data.Entities;
using Institution.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Institution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly ApplicationDataContext _context;


        public MunicipalitiesController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            var municipalities = await _context.Municipalities
                .Include(m => m.Sectors)
                .ToListAsync();
            return Ok(municipalities);
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return Ok(municipality);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MunicipalityDto municipalityDto)
        {
            var municipality = new Municipality
            {
                Name = municipalityDto.Name
            };

            _context.Municipalities.Add(municipality);
            await _context.SaveChangesAsync();

            return Ok(municipality);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, MunicipalityDto municipalityDto)
        {
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            municipality.Name = municipalityDto.Name;

            _context.Municipalities.Update(municipality);

            await _context.SaveChangesAsync();

            return Ok(municipality);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            _context.Municipalities.Remove(municipality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}