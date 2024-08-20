using KomitasPark.KomitasParkDAL.Entites;

namespace KomitasPark.KomitasParkBLL.Models
{
    public class ProjectModel : AbstractModel
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<BuildingGroup> BuildingGroups { get; set; }

        public ProjectModel(int id, string name, string code) : base(id)
        {
            Id = id;
            Name = name;
            Code = code;
        }

    }
}
