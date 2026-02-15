using System.Collections.Generic;

namespace Institution.Models.Dtos
{
    public class MunicipalityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> SectorNames { get; set; } 
    }
}