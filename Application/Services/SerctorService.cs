using Institution.Application.Contract;
using Institution.Application.Dtos;
using Institution.Application.Core;
using Institution.Domain.Interfaces;
using Institution.Domain.Entities;
using Institution.Application.Validations;

namespace Institution.Application.Services
{
    public class SectorService(ISectorRepository repository, SerctorValidator validator) : ISectorService
    {
        public async Task<ServiceResult> GetAsync()
        {
            var result = new ServiceResult();
            var entity = await repository.GetAsync();

        if (entity == null || !entity.Any())
        {
            result.Success = true;
            result.Message  = "No data found";
            return result;
        }

        result.Success = true;
        result.Message = "Data return successful";
        result.Data = entity;
        return result;
        
    }

    public async Task<ServiceResult> GetByIdAsync(int Id)
    {
        var result = new ServiceResult();
        var entity = await repository.GetById(Id);

        if (entity == null)
        {
            result.Success = false;
            result.Message = $"The Sector {Id} does not exist";
            return result;
        }

        result.Success = true;
        result.Message = "Data return successful";
        result.Data = entity;
        return result;

        
    }

    public async Task<ServiceResult> PostAsync(SectorDto sectorDto)
    {
        var result = new ServiceResult();
        
        try
        {
            var validate = await validator.ValidateAsync(sectorDto);
            if (!validate.IsValid)
            {
                result.Success = false;
                result.Message = string.Join(", ", validate.Errors.Select(x => x.ErrorMessage));
                return result;
            }

            var entity = new Sector
            {
                Name = sectorDto.Name,
            };
            await repository.PostAsync(entity);

            result.Success = true;
            result.Message = "Data successfully saved";
            result.Data = entity;
            return result;
        }
        catch (Exception)
        {
            result.Success = false;
            result.Message = "Error saving data";
            return result;
        }
    }

    public async Task<ServiceResult> PutAsync(int Id, SectorDto sectorDto)
    {
        var result = new ServiceResult();
            
            try
            {
                var validate = await validator.ValidateAsync(sectorDto);
                if (!validate.IsValid)
                {
                    result.Success = false;
                    result.Message = string.Join(", ", validate.Errors.Select(x => x.ErrorMessage));
                    return result;
                }
                
                var entity = await repository.GetById(Id);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = $"The Sector {Id} does not exist";
                    return result;
                }

                entity.Name = sectorDto.Name;
                await repository.UpdateAsync(entity);

                result.Success = true;
                result.Message = "Data successfully updated";
                result.Data = entity;
                return result;
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Error updating data";
                return result;
            }
        }
        
    public async Task<ServiceResult> DeleteAsync(int Id)
    {
        var result = new ServiceResult();
        try
        {
            var entity = await repository.GetById(Id);
            if (entity == null)
            {
                result.Success = false;
                result.Message = $"The Sector {Id} does not exist";
                return result;
            }

            await repository.DeleteAsync(entity);

            result.Success = true;
            result.Message = "Data successfully deleted";
            result.Data = entity;
            return result;
        }
        catch (Exception)
        {
            result.Success = false;
            result.Message = "Error deleting data";
            return result;
        }
    }
    
  }
}