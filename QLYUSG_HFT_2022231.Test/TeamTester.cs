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
    class TeamTester
    {
        TeamLogic logic;

        Mock<IRepository<Team>> mockTeamRepository;

        [SetUp]
        public void Init()
        {
            Driver d1 = new Driver() { Id = 1, Name = "driv1", Age = 20 };
            Driver d2 = new Driver() { Id = 2, Name = "driv2", Age = 30 };
            Driver d3 = new Driver() { Id = 3, Name = "driv3", Age = 15 };
            Driver d4 = new Driver() { Id = 4, Name = "driv4", Age = 46 };

            mockTeamRepository = new Mock<IRepository<Team>>();
            mockTeamRepository.Setup(r => r.ReadAll()).Returns(new List<Team>()
            {
                new Team() { Id = 1, Name = "team1", Drivers =new List<Driver>() { d1,d2}, Positions= new List<Position>() { new Position() { RaceId = 1, TeamId = 1, Result = 1, Points = 2 },
                                                                                      new Position() { RaceId = 2, TeamId = 1, Result = 2, Points = 1 } } },
                new Team() { Id = 2, Name = "team2", Drivers =new List<Driver>() { d3,d4}, Positions= new List<Position>(){ new Position() { RaceId = 1, TeamId = 2, Result = 2, Points = 1 } } }
            }.AsQueryable());

            logic = new TeamLogic(mockTeamRepository.Object);
        }

        [Test]
        public void AvgAgeTester()
        {
            double result = logic.AvgAge(1);
            Assert.That(result, Is.EqualTo(25));
        }
        
        [Test]
        public void PointsEarnedTester()
        {
            int result = logic.PointsEarned(1);
            Assert.That(result, Is.EqualTo(3));
        }
        
        [Test]
        public void DeleteNonExistingTeamTest()
        {
            try
            {
                logic.Delete(300);
            }
            catch 
            {
            }
            
            mockTeamRepository.Verify(t =>t.Delete(300), Times.Never);
        }
        [Test]
        public void DeleteExistingTeamTest()
        {
            try
            {
                logic.Delete(1);
            }
            catch
            {
            }
            mockTeamRepository.Verify(t => t.Delete(1), Times.Once);
        }
        [Test]
        public void CreateTeamTest()
        {
            int count = logic.ReadAll().Count();
            var team = new Team() { Id = 3, Name = "newTeam", Car = "shitbox"};
            try
            {
                logic.Create(team);
            }
            catch
            {
            }

            mockTeamRepository.Verify(t => t.Create(team), Times.Once);
        }
    }
}
