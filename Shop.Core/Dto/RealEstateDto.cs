using Microsoft.AspNetCore.Http;
using Shop.Core.Domain;

namespace Shop.Core.Dto
{
    public class RealEstateDto
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public float SizeSqrtM { get; set; }
        public int RoomCount { get; set; }
        public int Floor { get; set; }
        public string BuildingType { get; set; }
        public DateTime BuiltInYear { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        //only in database
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
