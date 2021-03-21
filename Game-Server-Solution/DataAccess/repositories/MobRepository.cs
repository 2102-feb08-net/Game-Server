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
                LootTableId = m.LootTableId,
                Health = m.Health,
                Exp = m.Exp,
                Attack = m.Attack,
                Defense = m.Defense,
                Speed = m.Speed
            });
    }

        public IEnumerable<Business.Model.LootLine> GetLootTable(int mobId)
        {
            var mob = _context.Mobs
                .First(m => m.Id == mobId);

            var lootTable = _context.LootTables
                .First(lt => lt.Id == mob.LootTableId);

            var lootLines = _context.LootLines
                .Select(ll => ll)
                .Where(ll => ll.LootTableId == lootTable.Id);

            return lootLines.Select(ll => new Business.Model.LootLine
            {
                Id = ll.Id,
                LootTableId = ll.LootTableId,
                WeaponId = ll.WeaponId,
                Quantity = ll.Quantity,
                DropPercentage = ll.DropPercentage
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
    }
}