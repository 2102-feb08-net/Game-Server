using System;
using Xunit;
using DataAccess;
using Moq;
using System.Collections.Generic;

namespace UnitTests
{
    public class MobRepositoryTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            List<MobSpawnDTO> mobspawns = new List<MobSpawnDTO>();
            mobspawns.Add(new MobSpawnDTO { SpawnX = 10, SpawnY = 14, Mob = new Mob() { Defense = 1, Exp = 1, Attack = 10, Health = 0, Id = 1, LootTableId = 1, Speed = 10 } });
            mobspawns.Add(new MobSpawnDTO { SpawnX = 12, SpawnY = 30, Mob = new Mob() { Defense = 12, Exp = 11, Attack = 120, Health = 10, Id = 2, LootTableId = 1, Speed = 10 } });
            
            

            var mockRepo = new Mock<IMobRepository>();

            // MobController 

            mockRepo.Setup(r => r.GetMobspawns()).Returns(mobspawns).Verifiable();

            // act

            // assert
            mockRepo.Verify(r => r.GetMobspawns());
    
        
    }

    }

}
