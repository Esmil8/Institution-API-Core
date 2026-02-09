using System.ComponentModel.DataAnnotations;

namespace Institution.Data.Entities
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; } = null!;
    }
}