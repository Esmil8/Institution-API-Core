using Institution.Application.Contract;
using Institution.Application.Core;
using Institution.Application.Dtos;
using Institution.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Institution.Domain.Entities;
using Institution.Application.Validations;

namespace Institution.Application.Services
{
    public class MunicipalityService(IMunicipalityRepository repository, MunicipalityValidator validator) : IMunicipalityService
    {
        public async Task<ServiceResult> GetAsync()
        {
            var result = new ServiceResult();
            var entities = await repository.GetAsync();

            result.Success = true;
            result.Message = "Data return successful";
            result.Data = entities;
            return result;
        }

        public async Task<ServiceResult> GetByIdAsync(int Id)
        {
            var result = new ServiceResult();
            var entities = await repository.GetById(Id);

            if (entities == null)
            {
                result.Success = false;
                result.Message = $"The Municipality {Id} does not exits";
                return result;
                
            }

            result.Success = true;
            result.Message = "Data return successful";
            result.Data = entities;
            return result;
        }

        public async Task<ServiceResult> PostAsync(MunicipalityDto municipalityDto)
        {
            var result = new ServiceResult();

            try
            {
                var validate = await validator.ValidateAsync(municipalityDto);
                if (!validate.IsValid)
                {
                    result.Success = false;
                    result.Message = string.Join(", ", validate.Errors.Select(x => x.ErrorMessage));
                    return result;
                }
                
                var entity = new Municipality
                {
                    Name = municipalityDto.Name
                };

                await repository.PostAsync(entity);

                result.Success = true;
                result.Message = "Data successfully saved";
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error saving data: {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult> PutAsync(int Id, MunicipalityDto municipalityDto)
        {
            var result = new ServiceResult();

            try
            {
                var validate = await validator.ValidateAsync(municipalityDto);
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
                    result.Message = $"The Municipality {Id} does not exist";
                    return result;
                }

                entity.Name = municipalityDto.Name;
                await repository.UpdateAsync(entity);

                result.Success = true;
                result.Message = "Data successfully updated";
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error updating data: {ex.Message}";
            }

            return result;
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
                    result.Message = $"The Municipality {Id} does not exist";
                    return result;
                }

                await repository.DeleteAsync(entity);

                result.Success = true;
                result.Message = "Data successfully deleted";
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error deleting data: {ex.Message}";
            }

            return result;
        }

    }
}