namespace KomitasPark.KomitasParkDAL.Entites
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }


        public BaseEntity(int id, string name, string code)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
        }
    }
}
