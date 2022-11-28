using QLYUSG_HFT_2022231.Models;
using System.Linq;

namespace QLYUSG_HFT_2022231.Logic
{
    public interface IDriverLogic
    {
        void Create(Driver item);
        void Delete(int id);
        Driver Read(int id);
        IQueryable<Driver> ReadAll();
        void Update(Driver item);
    }
}