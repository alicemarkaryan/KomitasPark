namespace KomitasPark.KomitasParkDAL.Entites
{
    public class Project : BaseEntity
    {
        public ICollection<BuildingGroup>? BuildingGroups { get; set; }

        public Project(int id, string name, string code) : base(id, name, code)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
        }
    }
}
