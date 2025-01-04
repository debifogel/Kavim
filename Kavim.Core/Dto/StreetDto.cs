using Kavim.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.classes
{
    public class StreetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        //one to many
        public List<StationDto> ListOfStation { get; set; }
    }
}
