using KomitasPark.KomitasParkBLL.Models;

namespace KomitasPark.KomitasParkBLL.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T model);
        void Update(T model);
        void Delete(int modelId);
    }
}
