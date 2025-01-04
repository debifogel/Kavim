using AutoMapper;
using Kavim.Core.classes;
using Kavim.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Bus, BusDto>().ReverseMap();
            CreateMap<Schdule, ScheduleDto>().ReverseMap();
            CreateMap<StationAndi, StationAndIDto>().ReverseMap();
            CreateMap<StationAndi, BusAndiDto>().ReverseMap();
            CreateMap<Street, StreetDto>().ReverseMap();
            CreateMap<Station, StationDto>().ReverseMap();
        }
    }
}
