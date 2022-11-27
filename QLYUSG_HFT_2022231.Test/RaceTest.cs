using NUnit.Framework;
using QLYUSG_HFT_2022231.Models;
using QLYUSG_HFT_2022231.Repository;
using System;

namespace QLYUSG_HFT_2022231.Test
{
    [TestFixture]
    public class TesterClass
    {
        
    }

    public class FakeRaceRepository : Repository<Race>
    {
        public FakeRaceRepository(RaceDbContext rdc) : base(rdc)
        {
        }

        public override Race Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Race item)
        {
            throw new NotImplementedException();
        }
    }
}
