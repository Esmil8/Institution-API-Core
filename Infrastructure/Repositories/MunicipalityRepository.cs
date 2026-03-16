using Institution.Domain.Entities;
using Institution.Domain.Interfaces;
using Institution.Infrastructure.Context;
using Institution.Infrastructure.Core;

namespace Institution.Infrastructure.Repositories
{
    public class MunicipalityRepository(ApplicationDataContext context) 
        : BaseRepository<Municipality>(context), IMunicipalityRepository
    {
    }
}