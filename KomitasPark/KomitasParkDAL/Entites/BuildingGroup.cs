namespace KomitasPark.KomitasParkDAL.Entites
{
    public class BuildingGroup : BaseEntity
    {
        public BuildingGroup(int id, string name, string code) : base(id, name, code)
        {
        }

        public DateTime ConstructionDate { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public ICollection<Building>? Buildings { get; set; }
    }
}
