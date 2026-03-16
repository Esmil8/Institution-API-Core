using System.ComponentModel.DataAnnotations;
using Institution.Domain.Core;
namespace Institution.Domain.Entities
{
    public class Sector : BaseEntity
    {
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; } = null!;
    }
}