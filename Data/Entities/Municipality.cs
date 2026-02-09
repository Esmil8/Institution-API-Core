using System.ComponentModel.DataAnnotations;

namespace Institution.Data.Entities
{
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        public ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    }
    
}