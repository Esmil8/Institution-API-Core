using Institution.Data;
using Institution.Data.Entities;
using Institution.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Institution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public SectorsController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var sectors = await _context.Sectors.Include(s => s.Municipality).Select(s => new SectorResponseDto
            
                {
                    Id = s.Id,
                    Name = s.Name,
                    MunicipalityName = s.Municipality.Name 
                    
                }).ToListAsync();

            return Ok(sectors);
        }
        
    [HttpPost]
        public async Task<IActionResult> PostAsync(SectorDto sectorDto)
        {
            var municipality = await _context.Municipalities.FindAsync(sectorDto.MunicipalityId);
            if (municipality == null)
            {
                return BadRequest("The municipality does not exist.");
            }

            var sector = new Sector
            {
                Name = sectorDto.Name,
                MunicipalityId = sectorDto.MunicipalityId
            };

            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            
            var response = new SectorResponseDto
            {
                Id = sector.Id,
                Name = sector.Name,
                MunicipalityName = municipality.Name
            };

            return Ok(response);
        }
        

    [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, SectorDto sectorDto)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null) return NotFound();

            var municipality = await _context.Municipalities.FindAsync(sectorDto.MunicipalityId);
            if (municipality == null) return BadRequest("The municipality does not exist.");

            sector.Name = sectorDto.Name;
            sector.MunicipalityId = sectorDto.MunicipalityId;

            _context.Sectors.Update(sector);
            await _context.SaveChangesAsync();

            
            var response = new SectorResponseDto
            {
                Id = sector.Id,
                Name = sector.Name,
                MunicipalityName = municipality.Name
            };

            return Ok(response);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}