using AutoMapper;
using Gol.Api.ViewModels;
using Gol.Business.Models;

namespace Gol.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<TravelViewModel, Travel>().ReverseMap();

            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}