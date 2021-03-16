using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class MobRepository : IMobRepository
    {
        private readonly Project2Context _context;
        public MobRepository(Project2Context context)
        {
            _context = context;
        }

        public List<Mobspawn> GetMobspawns()
        {
            var results = _context.Mo
            return new List<Mobspawn>();
        }
    }
}