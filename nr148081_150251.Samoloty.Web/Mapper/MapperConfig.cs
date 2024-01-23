using AutoMapper;
using nr148081_150251.Samoloty.Interfaces;
using nr148081_150251.Samoloty.Web.Models.Plane;

namespace nr148081_150251.Samoloty.Web.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            MapPlanes();
        }


        private void MapPlanes()
        {
            CreateMap<IPlane, PlaneViewModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
        }

        private void MapCompanies()
        {            
        }

    }
}
