using System.Linq;

namespace QLYUSG_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
    }
}