namespace KomitasPark.KomitasParkDAL.Entites
{
    public class Building : BaseEntity
    {
        public Building(int id, string name, string code) : base(id, name, code)
        {
        }

        public DateTime ConstructionDate { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public double FloorArea { get; set; }

        public int BuildingGroupId { get; set; }
        public BuildingGroup? BuildingGroup { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
