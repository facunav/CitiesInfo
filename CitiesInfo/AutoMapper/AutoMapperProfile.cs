using AutoMapper;

namespace CitiesInfo.AutoMapper
{
    //Used to declare all the entities maps for the automapper
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Common.Entities.City, Dtos.City>();
            CreateMap<Dtos.City, Common.Entities.City>();
            CreateMap<ViewModels.CityVm, Common.Entities.City>();
            CreateMap<Common.Entities.City, ViewModels.CityVm>();
            CreateMap<Common.Entities.PointsOfInterest, Dtos.PointsOfInterest>();
            CreateMap<Common.Entities.PointsOfInterest, ViewModels.PointsOfInterestVm>();
            CreateMap<Dtos.PointsOfInterest, Common.Entities.PointsOfInterest>();
        }
    }
}
