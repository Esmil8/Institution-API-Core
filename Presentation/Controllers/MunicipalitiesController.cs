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
public class MunicipalitiesController(IMunicipalityRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var municipalities = await repository.GetAsync();
        return Ok(municipalities);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var municipality = await repository.GetById(id);

        if (municipality == null) 
            throw new NotFoundException("Municipality", id);

        return Ok(municipality);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(MunicipalityDto municipalityDto)
    {
        var municipality = new Municipality
        {
            Name = municipalityDto.Name
        };
        await repository.AddAsync(municipality);

        return Ok(municipality);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync(int id, MunicipalityDto municipalityDto)
    {
        var municipality = await repository.GetById(id);

        if (municipality == null) 
            throw new NotFoundException("Municipality", id);

        municipality.Name = municipalityDto.Name;
        await repository.UpdateAsync(municipality);

        return Ok(municipality);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var municipality = await repository.GetById(id);

        if (municipality == null) 
            throw new NotFoundException("Municipality", id);

        await repository.DeleteAsync(municipality);

        return NoContent();
    }
}