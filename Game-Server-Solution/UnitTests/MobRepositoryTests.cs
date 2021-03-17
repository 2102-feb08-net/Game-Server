using System;
using Xunit;
using DataAccess;
using Moq;
using System.Collections.Generic;
using GameAPI;
using GameAPI.Controllers;

namespace UnitTests
{
    public class MobRepositoryTests
    {

        private readonly Mock<IMobRepository> mobmock = new Mock<IMobRepository>();

        [Fact]
        public void Test1()
        {
            //arrange

            //LootTable lootTable = new LootTable() {d}

           // Weapon weapon = new Weapon() { Damage = 1, Description = "strong", AttackSpeed = 1, Id = 1, LevelRequirement = 2, Name = "sword", Rarity = "rare" };

           // Lootline lootline = new Lootline() { DropPercentage = .25M, Id = 1, LootTableId = 1, Quantity = 1, WeaponId = 1 };

           // Mob newmob = new Mob() { Defense = 1, Attack = 1, Exp = 1, Health = 1, Speed = 2,LootTableId=1};

          //  MobSpawn mobspawn = new MobSpawn() {ModId=1, SpawnX = 1, SpawnY = 2 };

           // using Project2ContextFactory factory = new Project2ContextFactory();

            //using (Project2Context setcontext = factory.CreateContext())
            {
           
               // setcontext.Mobs.Add(newmob);


               // setcontext.Weapons.Add(weapon);

                

               // setcontext.Lootlines.Add(lootline);

               // setcontext.MobSpawns.Add(mobspawn);

               //setcontext.SaveChanges();

              //  setcontext.MobSpawns.Add(mobspawn);


            }

          //  using var context = factory.CreateContext();
           // var repo = new MobRepository(context);

            // act
          
           // var mobs = repo.GetMobspawns();

            // assert
           // Assert.True(mobs.Count == 0);
  


        }

    }

}
