using Institution.Application.Core;
using Institution.Application.Dtos;

namespace Institution.Application.Contract
{
    public interface IMunicipalityService
    {
        public Task<ServiceResult> GetAsync();
        public Task<ServiceResult> GetByIdAsync(int Id);
        public Task<ServiceResult> PostAsync(MunicipalityDto municipalityDto);
        public Task<ServiceResult> PutAsync(int Id, MunicipalityDto municipalityDto);
        public Task<ServiceResult> DeleteAsync(int Id);
    }
}