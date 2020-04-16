using AutoMapper;
using Dormitories.Api.ViewModels;

namespace Dormitories.Core.DataAccess
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dormitory, DormitoryViewModel>();
        }
    }
}
