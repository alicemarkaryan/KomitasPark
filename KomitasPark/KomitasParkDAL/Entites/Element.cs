namespace KomitasPark.KomitasParkDAL.Entites
{
    public class Element : BaseEntity
    {
        public Element(int id, string name, string code) : base(id, name, code)
        {
        }

        public DateTime IntroductionDate { get; set; }
        public int Count { get; set; }
        public string? Unit { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
