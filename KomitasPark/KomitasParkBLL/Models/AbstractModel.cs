namespace KomitasPark.KomitasParkBLL.Models
{
    public abstract class AbstractModel
    {
        public int Id { get; set; }
        protected AbstractModel(int Id)
        {
            this.Id = Id;
        }
    }
}
