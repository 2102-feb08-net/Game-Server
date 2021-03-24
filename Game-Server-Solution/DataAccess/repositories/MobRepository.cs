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
    /// <summary>
    /// Repository that handles all information related to mobs
    /// </summary>
    public class MobRepository : IMobRepository
    {
        private readonly Project2Context _context;

        public MobRepository(Project2Context context)
        {
            _context = context;
        }

        public IEnumerable<Business.Model.Mob> GetAllMobs()
        {
            var mobs = _context.Mobs
                .Select(m => m);

            return mobs.Select(m => new Business.Model.Mob
            {
                Id = m.Id,
                Name = m.Name,
                LootTableId = m.LootTableId,
                Health = m.Health,
                Exp = m.Exp,
                Attack = m.Attack,
                Defense = m.Defense,
                Speed = m.Speed
            });
        }

        public IEnumerable<Business.Model.MobSpawn> GetMobSpawns()
        {
            var mobSpawns = _context.MobSpawns
                .Select(ms => ms);

            return mobSpawns.Select(ms => new Business.Model.MobSpawn
            {
                Id = ms.Id,
                ModId = ms.ModId,
                SpawnX = ms.SpawnX,
                SpawnY = ms.SpawnY
            });
        }

        public Business.Model.Weapon GetLoot(int mobId)
        {
            var mob = _context.Mobs
                .First(m => m.Mobid == mobId);

            var lootTable = _context.LootTables
                .First(lt => lt.Id == mob.LootTableId);

            var lootLines = _context.Lootlines
                .Select(ll => ll)
                .Where(ll => ll.LootTableId == lootTable.Id).ToList();

            Random rnd = new Random();
            int r = rnd.Next(lootLines.Count);
            Lootline rndLootLine = lootLines[r];

            var weapon = _context.Weapons
                .First(w => w.Id == rndLootLine.WeaponId);

            return new Business.Model.Weapon
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Description = weapon.Description,
                Damage = weapon.Damage,
                AttackSpeed = weapon.AttackSpeed,
                LevelRequirement = weapon.LevelRequirement,
                Rarity = weapon.Rarity
            };
        }
    }
}