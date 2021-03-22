using Business.Interface;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Project2Context _context;

        public PlayerRepository(Project2Context context)
        {
            _context = context;
        }

        public Business.Model.Player CreatePlayer(Business.Model.Player player, string characterName)
        {
            var newCharacter = new Character
            {
                CharacterName = characterName
            };
            _context.Characters.Add(newCharacter);
            _context.SaveChanges();

            
            var newPlayer = new Player
            {
                CharacterId = newCharacter.Id,
                Username = player.Username,
                Password = player.Password
            };
            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            return new Business.Model.Player
            {
                Id = newPlayer.Id,
                CharacterId = newPlayer.CharacterId,
                Username = newPlayer.Username,
                Password = newPlayer.Password
            };
        }

        public Business.Model.Player GetPlayer(Business.Model.Player player)
        {
            var playerDB = _context.Players
                .Select(p => p)
                .Where(p => p.Username == player.Username && p.Password == player.Password);

            var playerList = playerDB.ToList();

            if (playerList.Count == 0)
            {
                throw new ArgumentException("No player with that username and password");
            }

            return new Business.Model.Player
            {
                Id = playerList[0].Id,
                CharacterId = playerList[0].CharacterId,
                Username = playerList[0].Username,
                Password = playerList[0].Password
            };
        }

        public Business.Model.Character GetCharacterStats(int playerId)
        {
            var player = _context.Players
                .First(p => p.Id == playerId);

            var character = _context.Characters
                .First(c => c.Id == player.CharacterId);

            return new Business.Model.Character
            {
                Id = character.Id,
                CharacterName = character.CharacterName,
                Exp = character.Exp,
                Health = character.Health,
                Attack = character.Attack,
                Defense = character.Defense,
                Mana = character.Mana
            };
        }

        public IEnumerable<Business.Model.KillStat> GetKillStats(int playerId)
        {
            var killStats = _context.KillStats
                .Include(k => k.Player)
                .Include(k => k.Mob)
                .Select(k => k)
                .Where(k => k.PlayerId == playerId);

            return killStats.Select(ks => new Business.Model.KillStat
            {
                Id = ks.Id,
                PlayerId = ks.PlayerId,
                MobId = ks.MobId,
                Quantity = ks.Quantity
            });
        }

        public void UpdateCharacterStats(Business.Model.Character character)
        {
            Character currentEntity = _context.Characters.Find(character.Id);

            var newEntity = new Character
            {
                Id = character.Id,
                CharacterName = character.CharacterName,
                Exp = character.Exp,
                Health = character.Health,
                Attack = character.Attack,
                Defense = character.Defense,
                Mana = character.Mana
            };

            _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        public void UpdateKillStat(int playerId, int mobId)
        {
            List<KillStat> currentEntityList = _context.KillStats
                .Select(ks => ks)
                .Where(ks => ks.PlayerId == playerId && ks.MobId == mobId)
                .ToList();

            if (currentEntityList.Count == 0)
            {
                var newEntity = new KillStat
                {
                    PlayerId = playerId,
                    MobId = mobId,
                    Quantity = 1
                };
                _context.Add(newEntity);
            }
            else
            {
                var currentEntity = currentEntityList[0];

                var newEntity = new KillStat
                {
                    Id = currentEntity.Id,
                    PlayerId = playerId,
                    MobId = mobId,
                    Quantity = currentEntity.Quantity + 1
                };
                _context.Entry(currentEntity).CurrentValues.SetValues(newEntity);
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
