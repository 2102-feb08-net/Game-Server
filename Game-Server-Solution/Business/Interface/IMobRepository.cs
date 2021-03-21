﻿using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IMobRepository
    {
        IEnumerable<Mob> GetAllMobs();
        IEnumerable<LootLine> GetLootTable(int mobId);
        public IEnumerable<MobSpawn> GetMobSpawns();
    }
}
