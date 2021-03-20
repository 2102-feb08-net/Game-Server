﻿using DataAccess;
using DataAccess.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.IntegrationTests
{
    public class PlayerRepositoryTest
    {

        private Character CreateCharacter()
        {
            var character = new Character
            {
                CharacterName = "Hamza",
                Exp = 10,
                Health = 10,
                Attack = 7,
                Defense = 5,
                Mana = 15
            };
            return character;
        }

        private Player CreatePlayer(int? characterId)
        {
            var player = new Player
            {
                CharacterId = characterId,
                Username = "HamzaB12",
                Password = "password"
            };
            return player;
        }

        private KillStat CreateKillStat(int playerId, int mobId, int quantity)
        {
            var killStat = new KillStat
            {
                PlayerId = playerId,
                MobId = mobId,
                Quantity = quantity
            };
            return killStat;
        }

        private Mob CreateMob(int lootTableId)
        {
            var mob = new Mob
            {
                LootTableId = lootTableId,
                Health = 10,
                Exp = 11,
                Attack = 12,
                Defense = 13,
                Speed = 5
            };
            return mob;
        }

        private LootTable CreateLootTable()
        {
            return new LootTable { };
        }

        [Fact]
        public void GetCharacterStats_GetsExistingCharacterStats()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Character insertedCharacter = CreateCharacter();
            context.Characters.Add(insertedCharacter);
            context.SaveChanges();
            Player insertedPlayer = CreatePlayer(insertedCharacter.Id);
            context.Players.Add(insertedPlayer);
            context.SaveChanges();
            var repo = new PlayerRepository(context);

            //act
            Business.Model.Character character = repo.GetCharacterStats(insertedPlayer.Id);

            //assert
            Assert.Equal(insertedCharacter.Id, character.Id);
            Assert.Equal(insertedCharacter.CharacterName, character.CharacterName);
            Assert.Equal(insertedCharacter.Exp, character.Exp);
            Assert.Equal(insertedCharacter.Health, character.Health);
            Assert.Equal(insertedCharacter.Attack, character.Attack);
            Assert.Equal(insertedCharacter.Mana, character.Mana);
        }

        [Fact]
        public void GetKillStats_GetsExistingKillStats()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Player insertedPlayer = CreatePlayer(null);
            LootTable insertedLootTable = CreateLootTable();
            context.Players.Add(insertedPlayer);
            context.LootTables.Add(insertedLootTable);
            context.SaveChanges();
            Mob insertedMob = CreateMob(insertedLootTable.Id);
            context.Mobs.Add(insertedMob);
            context.SaveChanges();
            KillStat insertedKillStat = CreateKillStat(insertedPlayer.Id, insertedMob.Id, 10);
            context.KillStats.Add(insertedKillStat);
            context.SaveChanges();
            var repo = new PlayerRepository(context);

            //act
            List<Business.Model.KillStat> killStats = repo.GetKillStats(insertedPlayer.Id).ToList();

            //assert
            Assert.Equal(insertedKillStat.Id, killStats[0].Id);
            Assert.Equal(insertedKillStat.PlayerId, killStats[0].PlayerId);
            Assert.Equal(insertedKillStat.MobId, killStats[0].MobId);
            Assert.Equal(insertedKillStat.Quantity, killStats[0].Quantity);
            
        }

        [Fact]
        public void UpdateCharacterStats_UpdatesCharacterStats()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Character characterBeforeUpdate = CreateCharacter();
            Character insertedCharacter = new Character
            {
                Id = characterBeforeUpdate.Id,
                CharacterName = characterBeforeUpdate.CharacterName,
                Exp = characterBeforeUpdate.Exp,
                Health = characterBeforeUpdate.Health,
                Attack = characterBeforeUpdate.Attack,
                Defense = characterBeforeUpdate.Defense,
                Mana = characterBeforeUpdate.Mana

            };
            context.Characters.Add(insertedCharacter);
            context.SaveChanges();
            var characterUpdated = new Business.Model.Character
            {
                Id = insertedCharacter.Id,
                CharacterName = insertedCharacter.CharacterName,
                Exp = 15,
                Health = 12,
                Attack = 8,
                Defense = 6,
                Mana = 18
            };
            var repo = new PlayerRepository(context);

            //act
            repo.UpdateCharacterStats(characterUpdated);

            //assert
            Character character = context.Characters.Local.Single(c => c.Id == characterUpdated.Id);
            Assert.Equal(characterUpdated.Id, character.Id);
            Assert.Equal(characterUpdated.CharacterName, character.CharacterName);
            Assert.Equal(characterUpdated.Exp, character.Exp);
            Assert.Equal(characterUpdated.Health, character.Health);
            Assert.Equal(characterUpdated.Attack, character.Attack);
            Assert.Equal(characterUpdated.Mana, character.Mana);
            Assert.Equal(characterBeforeUpdate.Id, character.Id);
            Assert.Equal(characterBeforeUpdate.CharacterName, character.CharacterName);
            Assert.NotEqual(characterBeforeUpdate.Exp, character.Exp);
            Assert.NotEqual(characterBeforeUpdate.Health, character.Health);
            Assert.NotEqual(characterBeforeUpdate.Attack, character.Attack);
            Assert.NotEqual(characterBeforeUpdate.Mana, character.Mana);
        }

        [Fact]
        public void UpdateKillStat_UpdatesKillStat()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Player insertedPlayer = CreatePlayer(null);
            LootTable insertedLootTable = CreateLootTable();
            context.Players.Add(insertedPlayer);
            context.LootTables.Add(insertedLootTable);
            context.SaveChanges();
            Mob insertedMob = CreateMob(insertedLootTable.Id);
            context.Mobs.Add(insertedMob);
            context.SaveChanges();
            KillStat insertedKillStat = CreateKillStat(insertedPlayer.Id, insertedMob.Id, 10);
            context.KillStats.Add(insertedKillStat);
            context.SaveChanges();
            var repo = new PlayerRepository(context);

            //act
            repo.UpdateKillStat(insertedPlayer.Id, insertedMob.Id);

            //assert
            KillStat killStat = context.KillStats.Local.Single(k => k.Id == insertedKillStat.Id);
            Assert.Equal(insertedKillStat.Id, killStat.Id);
            Assert.Equal(insertedKillStat.PlayerId, killStat.PlayerId);
            Assert.Equal(insertedKillStat.MobId, killStat. MobId);
            Assert.Equal(11, killStat.Quantity);
        }

        [Fact]
        public void UpdateKillStat_CreatesNewKillStat()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Player insertedPlayer = CreatePlayer(null);
            LootTable insertedLootTable = CreateLootTable();
            context.Players.Add(insertedPlayer);
            context.LootTables.Add(insertedLootTable);
            context.SaveChanges();
            Mob insertedMob = CreateMob(insertedLootTable.Id);
            context.Mobs.Add(insertedMob);
            context.SaveChanges();
            var repo = new PlayerRepository(context);

            //act
            repo.UpdateKillStat(insertedPlayer.Id, insertedMob.Id);

            //assert
            KillStat killStat = context.KillStats.Local.Single(k => k.PlayerId == insertedPlayer.Id && k.MobId == insertedMob.Id);
            Assert.InRange(killStat.Id, 1, 10000);
            Assert.Equal(insertedPlayer.Id, killStat.PlayerId);
            Assert.Equal(insertedMob.Id, killStat.MobId);
            Assert.Equal(1, killStat.Quantity);
        }
    }
}