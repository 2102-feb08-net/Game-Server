using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using GameAPI;
using GameAPI.Controllers;
using Business.Interface;
using DataAccess.Entities;
using DataAccess.Repositories;
using System.Linq;

namespace Tests.IntegrationTests
{
    public class MobRepositoryTests
    {

        private LootTable CreateLootTable()
        {
            return new LootTable();
        }

        private Weapon CreateWeapon(string name)
        {
            return new Weapon
            {
                Name = name,
                Description = "Assault Weapon",
                Damage = 3,
                AttackSpeed = 5,
                LevelRequirement = 2,
                Rarity = "rare"
            };
        }

        private Mob CreateMob(int lootTableId)
        {
            return new Mob()
            {
                LootTableId = lootTableId,
                Health = 1,
                Exp = 1,
                Attack = 1,
                Defense = 1,
                Speed = 2
            };
        }

        private LootLine CreateLootLine(int lootTableId, int weaponId)
        {
            return new LootLine()
            {
                LootTableId = lootTableId,
                WeaponId = weaponId,
                Quantity = 1,
                DropPercentage = .25M
            };
        }

        private MobSpawn CreateMobSpawn(int mobId)
        {
            return new MobSpawn()
            {
                ModId = mobId,
                SpawnX = 25.67,
                SpawnY = 10.22
            };
        }

        [Fact]
        public void GetAllMobs_GetsAllMobs()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedLootTable1 = CreateLootTable();
            var insertedLootTable2 = CreateLootTable();
            context.LootTables.Add(insertedLootTable1);
            context.LootTables.Add(insertedLootTable2);
            context.SaveChanges();
            var insertedMob1 = CreateMob(insertedLootTable1.Id);
            var insertedMob2 = CreateMob(insertedLootTable2.Id);
            context.Mobs.Add(insertedMob1);
            context.Mobs.Add(insertedMob2);
            context.SaveChanges();
            var repo = new MobRepository(context);

            // act
            List<Business.Model.Mob> mob = repo.GetAllMobs().ToList();

            // assert
            Assert.Equal(insertedMob1.Id, mob[0].Id);
            Assert.Equal(insertedMob1.LootTableId, mob[0].LootTableId);
            Assert.Equal(insertedMob1.Health, mob[0].Health);
            Assert.Equal(insertedMob1.Exp, mob[0].Exp);
            Assert.Equal(insertedMob1.Attack, mob[0].Attack);
            Assert.Equal(insertedMob1.Defense, mob[0].Defense);
            Assert.Equal(insertedMob1.Speed, mob[0].Speed);
            Assert.Equal(insertedMob2.Id, mob[1].Id);
        }

        [Fact]
        public void GetLootTable_Gets1MobLootTable()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedLootTable = CreateLootTable();
            context.LootTables.Add(insertedLootTable);
            var insertedWeapon1 = CreateWeapon("AK-47");
            var insertedWeapon2 = CreateWeapon("Katana");
            context.Weapons.Add(insertedWeapon1);
            context.Weapons.Add(insertedWeapon2);
            context.SaveChanges();
            var insertedMob = CreateMob(insertedLootTable.Id);
            context.Mobs.Add(insertedMob);
            var insertedLootLine1 = CreateLootLine(insertedLootTable.Id, insertedWeapon1.Id);
            var insertedLootLine2 = CreateLootLine(insertedLootTable.Id, insertedWeapon2.Id);
            context.SaveChanges();
            var repo = new MobRepository(context);

            // act
            List<Business.Model.LootLine> lootLineList = repo.GetLootTable(insertedMob.Id).ToList();

            // assert
            Assert.Equal(insertedLootLine1.Id, lootLineList[0].Id);
            Assert.Equal(insertedLootLine1.LootTableId, lootLineList[0].LootTableId);
            Assert.Equal(insertedLootLine1.WeaponId, lootLineList[0].WeaponId);
            Assert.Equal(insertedLootLine1.Quantity, lootLineList[0].Quantity);
            Assert.Equal(insertedLootLine1.DropPercentage, lootLineList[0].DropPercentage);
            Assert.Equal(insertedLootLine2.Id, lootLineList[1].Id);
            Assert.Equal(insertedLootLine2.LootTableId, lootLineList[1].LootTableId);
        }

        [Fact]
        public void GetMobSpawn_GetsAllMobSpawns()
        {
            // arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            var insertedLootTable1 = CreateLootTable();
            var insertedLootTable2 = CreateLootTable();
            context.LootTables.Add(insertedLootTable1);
            context.LootTables.Add(insertedLootTable2);
            context.SaveChanges();
            var insertedMob1 = CreateMob(insertedLootTable1.Id);
            var insertedMob2 = CreateMob(insertedLootTable2.Id);
            context.Mobs.Add(insertedMob1);
            context.Mobs.Add(insertedMob2);
            context.SaveChanges();
            var insertedMobSpawn1 = CreateMobSpawn(insertedMob1.Id);
            var insertedMobSpawn2 = CreateMobSpawn(insertedMob2.Id);
            var repo = new MobRepository(context);

            // act
            List<Business.Model.MobSpawn> mobSpawns = repo.GetMobSpawns().ToList();

            // assert
            Assert.Equal(insertedMobSpawn1.Id, mobSpawns[0].Id);
            Assert.Equal(insertedMobSpawn1.ModId, mobSpawns[0].ModId);
            Assert.Equal(insertedMobSpawn1.SpawnX, mobSpawns[0].SpawnX);
            Assert.Equal(insertedMobSpawn1.SpawnY, mobSpawns[0].SpawnY);
            Assert.Equal(insertedMobSpawn2.Id, mobSpawns[1].Id);
        }
    }

}
