using System;
using System.Linq;
using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;

namespace QLYUSG_HFT_2022231.Logic
{
    public class DriverLogic
    {
        DriverReposistory driver;

        public DriverLogic(DriverReposistory driver)
        {
            this.driver = driver;
        }

        public void Create(Driver item)
        {
            driver.Create(item);
        }

        public void Delete(int id)
        {
            driver.Delete(id);
        }

        public IQueryable<Driver> ReadAll()
        {
            return driver.ReadAll();
        }

        public Driver Read(int id)
        {
            return driver.Read(id);
        }
        public void Update(Driver item)
        {
            driver.Update(item);
        }
    }
}
