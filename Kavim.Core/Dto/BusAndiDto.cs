using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Dto
{
    public class BusAndiDto
    {
       
        public StatusOfStation Status { get; set; }
        public int InOrder { get; set; }
        public BusDto _Bus { get; set; }
    }
}
