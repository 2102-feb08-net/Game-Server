using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.IntegrationTests
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

        private List<Character> Create10Characters()
        {
            var character1 = CreateCharacter();
            var character2 = CreateCharacter();
            var character3 = CreateCharacter();
            var character4 = CreateCharacter();
            var character5 = CreateCharacter();
            var character6 = CreateCharacter();
            var character7 = CreateCharacter();
            var character8 = CreateCharacter();
            var character9 = CreateCharacter();
            var character10 = CreateCharacter();
            var character11 = CreateCharacter();
            character1.Exp = 1;
            character2.Exp = 2;
            character3.Exp = 3;
            character4.Exp = 4;
            character5.Exp = 5;
            character6.Exp = 6;
            character7.Exp = 7;
            character8.Exp = 8;
            character9.Exp = 9;
            character10.Exp = 10;
            character11.Exp = 11;
            List<Character> characters = new() { character1 , character2 , character3 , character4 , character5 , character6 ,
                character7, character8, character9 , character10, character11};
            return characters;
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
                Name = "Goblin",
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
        public void GetPlayer_GetsExistingPlayer()
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
            Business.Model.Player player = repo.GetPlayer(insertedPlayer.Username, insertedPlayer.Password);

            //assert
            Assert.Equal(insertedPlayer.Id, player.Id);
            Assert.Equal(insertedPlayer.CharacterId, player.CharacterId);
            Assert.Equal(insertedPlayer.Username, player.Username);
            Assert.Equal(insertedPlayer.Password, player.Password);
        }

        [Fact]
        public void CreatePlayer_Creates1PlayerAndCharacter()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            Player insertedPlayer = CreatePlayer(1);
            Business.Model.Player insertedPlayerB = new Business.Model.Player
            {
                CharacterId = insertedPlayer.CharacterId,
                Username = insertedPlayer.Username,
                Password = insertedPlayer.Password
            };
            var repo = new PlayerRepository(context);

            //act
            Business.Model.Player placeholder = repo.CreatePlayer(insertedPlayerB, "Hamza");

            //assert
            Player player = context.Players.Local.Single(p => p.Username == insertedPlayerB.Username);
            Character character = context.Characters.Local.Single(c => c.CharacterName == "Hamza");
            Assert.Equal(1, player.Id);
            Assert.Equal(insertedPlayerB.CharacterId, player.CharacterId);
            Assert.Equal(insertedPlayerB.Username, player.Username);
            Assert.Equal(insertedPlayerB.Password, player.Password);
            Assert.Equal(1, character.Id);
            Assert.Equal("Hamza", character.CharacterName);
            Assert.Equal(1, character.Exp);
            Assert.Equal(10, character.Health);
            Assert.Equal(1, character.Attack);
            Assert.Equal(1, character.Defense);
            Assert.Equal(10, character.Mana);
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
            characterBeforeUpdate.Id = insertedCharacter.Id;
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
        public async Task UpdateCharacterExpAsync_UpdatesCharacterExp()
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
            characterBeforeUpdate.Id = insertedCharacter.Id;
            var repo = new PlayerRepository(context);

            //act
            await repo.UpdateCharacterExpAsync(insertedCharacter.Id, 20);

            //assert
            Character character = context.Characters.Local.Single(c => c.Id == insertedCharacter.Id);
            Assert.Equal(insertedCharacter.Id, character.Id);
            Assert.Equal(insertedCharacter.CharacterName, character.CharacterName);
            Assert.Equal(characterBeforeUpdate.Exp + 20, character.Exp);
            Assert.Equal(insertedCharacter.Health, character.Health);
            Assert.Equal(insertedCharacter.Attack, character.Attack);
            Assert.Equal(insertedCharacter.Mana, character.Mana);
            Assert.Equal(characterBeforeUpdate.Id, character.Id);
            Assert.Equal(characterBeforeUpdate.CharacterName, character.CharacterName);
            Assert.NotEqual(characterBeforeUpdate.Exp, character.Exp);
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
            Assert.Equal(insertedKillStat.MobId, killStat.MobId);
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
            Assert.Equal(insertedPlayer.Id, killStat.PlayerId);
            Assert.Equal(insertedMob.Id, killStat.MobId);
            Assert.Equal(1, killStat.Quantity);
        }

        [Fact]
        public void GetLeaderboard_GetsTop10Characters()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context context = contextFactory.CreateContext();
            List<Character> insertedCharacters = Create10Characters();
            foreach(var character in insertedCharacters)
            {
                context.Characters.Add(character);
            }
            context.SaveChanges();
            var repo = new PlayerRepository(context);

            //act
            List<Business.Model.Character> characters = repo.GetLeaderboard().ToList();

            //assert
            Assert.Equal(11, characters[0].Exp);
            Assert.Equal(10, characters[1].Exp);
            Assert.Equal(3, characters[8].Exp);
            Assert.Equal(2, characters[9].Exp);
        }

        [Fact]
        public void Save_SavesCreateKillStat()
        {
            //arrange
            using var contextFactory = new Project2ContextFactory();
            using Project2Context arrangeActContext = contextFactory.CreateContext();
            Player insertedPlayer = CreatePlayer(null);
            LootTable insertedLootTable = CreateLootTable();
            arrangeActContext.Players.Add(insertedPlayer);
            arrangeActContext.LootTables.Add(insertedLootTable);
            arrangeActContext.SaveChanges();
            Mob insertedMob = CreateMob(insertedLootTable.Id);
            arrangeActContext.Mobs.Add(insertedMob);
            arrangeActContext.SaveChanges();
            var repo = new PlayerRepository(arrangeActContext);
            repo.UpdateKillStat(insertedPlayer.Id, insertedMob.Id);

            //act
            repo.Save();

            //assert
            using var assertContext = contextFactory.CreateContext();
            KillStat killStat = assertContext.KillStats.Single(k => k.PlayerId == insertedPlayer.Id && k.MobId == insertedMob.Id);
            Assert.InRange(killStat.Id, 1, 10000);
            Assert.Equal(insertedPlayer.Id, killStat.PlayerId);
            Assert.Equal(insertedMob.Id, killStat.MobId);
            Assert.Equal(1, killStat.Quantity);
        }
    }
}
