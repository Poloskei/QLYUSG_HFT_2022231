using Moq;
using NUnit.Framework;
using QLYUSG_HFT_2022231.Logic;
using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using QLYUSG_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLYUSG_HFT_2022231.Test
{
    [TestFixture]
    public class RaceTester
    {
        RaceLogic logic;

        Mock<IRepository<Race>> mockRaceRepo;
        Mock<IPositionRepository> mockPosRepo;

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

            mockPosRepo = new Mock<IPositionRepository>();
            mockPosRepo.Setup(m => m.ReadAll()).Returns(new List<Position>()
            {
                //spa
                new Position() { RaceId = 2, TeamId = 1, Result = 1, Points = 25 },
                new Position() { RaceId = 2, TeamId = 4, Result = 2, Points = 18 },
                new Position() { RaceId = 2, TeamId = 3, Result = 9, Points = 15 },
               
                //lemans
                new Position() { RaceId = 3, TeamId = 1, Result = 1, Points = 50 },
                new Position() { RaceId = 3, TeamId = 3, Result = 3, Points = 30 },
                new Position() { RaceId = 3, TeamId = 4, Result = 23, Points = 24 },
              
                //monza
                new Position() { RaceId = 4, TeamId = 4, Result = 1, Points = 25 },
                new Position() { RaceId = 4, TeamId = 1, Result = 2, Points = 18 },
                new Position() { RaceId = 4, TeamId = 2, Result = 33, Points = 12 },
                new Position() { RaceId = 4, TeamId = 3, Result = 36, Points = 0 }
            }.AsQueryable());
            logic = new RaceLogic(mockRaceRepo.Object,mockPosRepo.Object);
        }


        [Test]
        public void ChampionTester()
        {
            int result = logic.Champions();
            Assert.That(result, Is.EqualTo(1));
        }



        [Test]
        public void WinningTeamTest()
        {
            int teamid = logic.WinningTeam(4);
            Assert.That(teamid,Is.EqualTo(4));
        }

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
