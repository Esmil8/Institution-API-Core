using Institution.Infrastructure.Context;
using Institution.Domain.Entities;
using Institution.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Institution.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Institution.Infrastructure.Exceptions;

namespace Institution.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectorsController(ISectorRepository repository, IMunicipalityRepository muniRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var sectors = await repository.GetSectorsWithMunicipalityAsync();
        
        var response = sectors.Select(s => new SectorResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            MunicipalityName = s.Municipality.Name
        });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(SectorDto sectorDto)
    {
        var municipality = await muniRepository.GetById(sectorDto.MunicipalityId);
        
        if (municipality == null) 
            throw new NotFoundException("Municipality", sectorDto.MunicipalityId);

        var sector = new Sector
        {
            Name = sectorDto.Name,
            MunicipalityId = sectorDto.MunicipalityId
        };

        await repository.AddAsync(sector);

        var response = new SectorResponseDto
        {
            Id = sector.Id,
            Name = sector.Name,
            MunicipalityName = municipality.Name
        };

        return Ok(response);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var sector = await repository.GetById(id);

        if (sector == null) 
            throw new NotFoundException("Sector", id);

        return Ok(sector);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var sector = await repository.GetById(id);

        if (sector == null) 
            throw new NotFoundException("Sector", id);

        await repository.DeleteAsync(sector);
        return NoContent();
    }
}