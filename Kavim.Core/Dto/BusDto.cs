using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Dto
{
    public class BusDto
    {
        public int Id { get; set; }
        public string BusName { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }

        public CompanyName Company { get; set; }
        public bool IsActive { get; set; }
        public List<ScheduleDto> Timings { get; set; }
    }
}
