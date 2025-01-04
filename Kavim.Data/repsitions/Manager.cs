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

        public void Savechanges()
        {
            _context.SaveChanges();
        }
    }
}
