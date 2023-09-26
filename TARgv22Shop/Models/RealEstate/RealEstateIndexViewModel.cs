namespace TARgv22Shop.Models.RealEstate
{
    public class RealEstateIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public float SizeSqrtM { get; set; }
        public int RoomCount { get; set; }
        public int Floor { get; set; }
        public string BuildingType { get; set; }
        public DateTime BuiltInYear { get; set; }
    }
}
