using System.Collections.Generic;

namespace Institution.Application.Dtos
{
    public class MunicipalityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> SectorNames { get; set; } = [];
    }
}