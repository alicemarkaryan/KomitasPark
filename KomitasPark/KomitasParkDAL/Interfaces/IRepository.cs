using KomitasPark.KomitasParkDAL.Entites;

namespace KomitasPark.KomitasParkDAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void SaveChanges();
    }
}
