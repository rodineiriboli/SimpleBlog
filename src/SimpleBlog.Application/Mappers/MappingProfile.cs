using AutoMapper;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, CreateUserViewModel>();
            CreateMap<CreateUserViewModel, Users>();

            CreateMap<Users, UserViewModelResponse>();
        }
    }
}
