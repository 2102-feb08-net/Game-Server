using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Project2Context _context;

        public PlayerRepository(Project2Context context)
        {
            _context = context;
        }

        public Business.Model.Character GetCharacterStats(int playerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Business.Model.KillStat> GetKillStats(int playerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCharacterStats(Business.Model.Character character)
        {
            throw new NotImplementedException();
        }

        public void UpdateKillStat(int playerId, int mobId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
