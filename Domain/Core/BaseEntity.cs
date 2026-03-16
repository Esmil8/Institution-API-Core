using System.ComponentModel.DataAnnotations;

namespace Institution.Domain.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

         [Required]
        [MaxLength(80)]
        public string Name {get; set;} = string.Empty;
    }
}