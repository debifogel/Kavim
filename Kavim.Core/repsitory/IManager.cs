using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.repsitory
{
    public interface IManager
    {
        Task<int> SavechangesAync();
    }
}
