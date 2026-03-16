using System.ComponentModel.DataAnnotations;
using Institution.Domain.Core;
namespace Institution.Domain.Entities
{
    public class Municipality : BaseEntity
    {
        
        public ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    }
    
}