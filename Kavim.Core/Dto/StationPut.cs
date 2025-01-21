using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Dto
{
    public class StationPut
    {
        public StatusOfStation Status { get; set; }
        public int InOrder { get; set; }
        public int Stop { get; set; }
    }
}
