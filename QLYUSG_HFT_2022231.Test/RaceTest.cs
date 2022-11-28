using Moq;
using NUnit.Framework;
using QLYUSG_HFT_2022231.Logic;
using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLYUSG_HFT_2022231.Test
{
    [TestFixture]
    public class TesterClass
    {
        RaceLogic logic;

        Mock<IRepository<Race>> mockRaceRepo;
        public Mock IRepository { get; private set; }

        [SetUp]
        public void Init()
        {
            mockRaceRepo = new Mock<IRepository<Race>>();
            mockRaceRepo.Setup(m => m.ReadAll()).Returns(new List<Race>()
            {
                new Race() { Country="Belgium", Name="6 hours of Spa-Francorchamps", Id = 2},
                new Race() { Country="France", Name="24 hours of Le Mans",      Id = 3},
                new Race() { Country="Italy", Name="6 hours of Monza",          Id = 4}
            }.AsQueryable());
            logic = new RaceLogic(mockRaceRepo.Object);
        }

        //[Test]
        //public void WinningTeamTest()
        //{

        //}

        [Test]
        public void CreateRaceTestWithCorrectInput()
        {
            var race = new Race() { Name = "24hrs of Nordschleife" , Id=7};
            //act
            logic.Create(race);


            //assert
            mockRaceRepo.Verify(r => r.Create(race), Times.Once);
        }

        [Test]
        public void CreateRaceTestWithWrongId()
        {
            var race = new Race() { Name = "qualifying", Id = 0 };
            try
            {

                //act
                logic.Create(race);
            }
            catch { }
            

            //assert
            mockRaceRepo.Verify(r => r.Create(race), Times.Never);
        }
    }

    
}
