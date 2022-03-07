using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CAME_API.Entities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Forecast, ForecastSL>();  // .ReverseMap();
            CreateMap<Forecast, ForecastItem>();
            CreateMap<NewWork, Work>();
        }
    }
}

