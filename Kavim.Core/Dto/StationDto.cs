using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Dto
{
    public class StationDto
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public string City { get; set; }
        //many to many
        public List<StationAndi> BusInStation { get; set; }
    }
}
