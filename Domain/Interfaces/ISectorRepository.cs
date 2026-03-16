using Institution.Domain.Core;
using Institution.Domain.Entities;

namespace Institution.Domain.Interfaces
{
    public interface ISectorRepository : IRepository<Sector>
    {
        Task<IEnumerable<Sector>> GetSectorsWithMunicipalityAsync();
    }

}