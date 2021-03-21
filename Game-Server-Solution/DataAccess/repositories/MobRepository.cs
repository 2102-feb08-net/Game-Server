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

    public class MobRepository : IMobRepository
    {
        private readonly Project2Context _context;
        public MobRepository(Project2Context context)
        {
            _context = context;
        }

        public IEnumerable<Business.Model.Mob> GetAllMobs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Business.Model.LootLine> GetLootTable(int mobId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Business.Model.MobSpawn> GetMobSpawns()
        {
            throw new NotImplementedException();
            //var results = _context.MobSpawns.Include(x => x.Mod); ;

            //List<Business.Model.MobSpawn> mobspawns = new List<Business.Model.MobSpawn>();

            //foreach (var result in results)
            //{
            //    mobspawns.Add(new Business.Model.MobSpawn() { MobId = result.ModId, SpawnX = result.SpawnX, SpawnY = result.SpawnY });
            //}

            //return mobspawns;
        }
    }
}