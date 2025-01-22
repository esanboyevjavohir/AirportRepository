using Airways.Application.Models.Aicraft;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class AircraftMaping:Profile
    {
        public AircraftMaping()
        {
            CreateMap<CreateAircraftModel, Aircraft>();

            CreateMap<UpdateAicraftModel, Aircraft>().ReverseMap();

            CreateMap<Aircraft, AicraftResponceModel>();
        }
    }
}
