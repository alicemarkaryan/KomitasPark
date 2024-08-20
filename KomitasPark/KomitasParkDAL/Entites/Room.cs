using System.Xml.Linq;

namespace KomitasPark.KomitasParkDAL.Entites
{
    public class Room : BaseEntity
    {
        public Room(int id, string name, string code) : base(id, name, code)
        {
        }

        public string? Description { get; set; }
        public int RoomNumber { get; set; }
        public double FloorArea { get; set; }

        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public ICollection<Element>? Elements { get; set; }
    }
}
