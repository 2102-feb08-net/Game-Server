using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IPlayerRepository
    {
        IEnumerable<KillStat> GetKillStats(int playerId);
        void UpdateKillStat(int playerId, int mobId);
        Character GetCharacterStats(int playerId);
        void UpdateCharacterStats(Character character);
        void Save();
    }
}
