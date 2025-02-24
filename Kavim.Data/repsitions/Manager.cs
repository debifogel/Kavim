using Kavim.Core.repsitory;
using Kavim.Data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Data.repsitions
{
    public class Manager : IManager
    {
        DataContext _context;

        public Manager(DataContext context)
        {
            _context = context;
        }

        public async Task<int> SavechangesAync()
        {
          var r= await _context.SaveChangesAsync();
            return r;
        }
    }
}
