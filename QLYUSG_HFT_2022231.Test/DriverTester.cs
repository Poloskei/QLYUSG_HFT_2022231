using Moq;
using NUnit.Framework;
using QLYUSG_HFT_2022231.Logic;
using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYUSG_HFT_2022231.Test
{
    [TestFixture]
    class DriverTester
    {
        DriverLogic logic;

        Mock<IRepository<Driver>> mockDriverRepo;

        [SetUp]
        [Obsolete]
        public void Init()
        {
            mockDriverRepo = new Mock<IRepository<Driver>>();
            mockDriverRepo.Setup(m => m.ReadAll()).Returns(new List<Driver>()
            {
                new Driver() { Age = 30, Name = "André Negrão",         Id = 1,TeamId=4},
                new Driver() { Age = 38, Name = "Nicolas Lapierre",     Id = 2,TeamId=4},
                new Driver() { Age = 27, Name = "Matthieu Vaxiviere",   Id = 3,TeamId=4},
                new Driver() { Age = 41, Name = "Olivier Pla",          Id = 4,TeamId=3},
                new Driver() { Age = 44, Name = "Romain Dumas",         Id = 5,TeamId=3}
            }.AsQueryable());
            logic = new DriverLogic(mockDriverRepo.Object);
        }

        [Test]
        public void CreateDriverTesterInvalidName()
        {
            var driver = new Driver() { Name = "", Age = 25 };

            //act
            try
            {
                logic.Create(driver);
            }
            catch 
            {

                
            }

            //assert
            mockDriverRepo.Verify(d => d.Create(driver), Times.Never);
        }

        [Test]
        public void CreateDriverTesterInvalidAge()
        {
            var driver = new Driver() { Name = "David Peterson", Age = -3 };

            //act
            try
            {
                logic.Create(driver);
            }
            catch 
            {

            }
            //assert
            mockDriverRepo.Verify(d => d.Create(driver), Times.Never);
        }
        [Test]
        public void CreateDriverTesterValid()
        {
            var driver = new Driver() { Name = "David Peterson", Age = 43 };

            //act
            try
            {
                logic.Create(driver);
            }
            catch 
            {

                
            }
            //assert
            mockDriverRepo.Verify(d => d.Create(driver), Times.Once);
        }
        [Test]
        public void DeleteDriverTest()
        {
            try
            {
                logic.Delete(3);
            }
            catch 
            {

            }

            mockDriverRepo.Verify(m => m.Delete(3), Times.Once);
        }
    }
}
