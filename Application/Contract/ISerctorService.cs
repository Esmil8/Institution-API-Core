using Institution.Application.Core;
using Institution.Application.Dtos;


namespace Institution.Application.Contract
{
    public interface ISectorService
    {
        Task<ServiceResult> GetAsync();
        Task<ServiceResult> GetByIdAsync(int Id);
        Task<ServiceResult> PostAsync(SectorDto sectorDto);
        Task<ServiceResult> PutAsync(int Id, SectorDto sectorDto);
        Task<ServiceResult> DeleteAsync(int Id);
        
    }
}