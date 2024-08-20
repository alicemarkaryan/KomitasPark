using KomitasPark.KomitasParkDAL.Data;

namespace KomitasPark.KomitasParkDAL.Repository
{
    public class AbstractRepository
    {
        protected readonly RealEstateContext context;
        protected AbstractRepository(RealEstateContext context)
        {
            this.context = context;
        }
    }
}
