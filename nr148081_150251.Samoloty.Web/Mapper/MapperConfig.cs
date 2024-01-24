using AutoMapper;
using nr148081_150251.Samoloty.Core;
using nr148081_150251.Samoloty.Interfaces;
using nr148081_150251.Samoloty.Web.Models;
using nr148081_150251.Samoloty.Web.Models.Company;
using nr148081_150251.Samoloty.Web.Models.Plane;

namespace nr148081_150251.Samoloty.Web.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            MapCompanies();
            MapPlanes();
        }


        private void MapPlanes()
        {
            CreateMap<IPlane, PlaneViewModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
            CreateMap<IPlane, PlaneEditViewModel>();

            CreateMap<PlaneType, PlaneTypeViewModel>().ReverseMap();

        }

        private void MapCompanies()
        {
            CreateMap<ICompany, CompanyViewModel>()
                .ReverseMap()
                .ForMember(x => x.Id, _ => _.UseDestinationValue());          
            CreateMap<ICompany, EntityViewModel>();
        }

    }
}
