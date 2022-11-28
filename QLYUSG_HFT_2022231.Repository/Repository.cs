using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected RaceDbContext rdc;

        protected Repository(RaceDbContext rdc)
        {
            this.rdc = rdc;
        }

        public void Create(T item)
        {
            rdc.Set<T>().Add(item);
            rdc.SaveChanges();
        }

        public void Delete(int id)
        {
            rdc.Set<T>().Remove(Read(id));
            rdc.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return rdc.Set<T>();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);

    }
}
