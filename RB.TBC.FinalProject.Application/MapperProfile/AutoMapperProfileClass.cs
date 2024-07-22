using AutoMapper;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Domain.Entitites;

namespace RB.TBC.FinalProject.Application.MapperProfile
{
    public class AutoMapperProfileClass : Profile
    {

        public AutoMapperProfileClass()
        {
            CreateMap<Feadback, FeadbackModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
