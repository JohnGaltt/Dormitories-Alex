using AutoMapper;
using Dormitories.Api.ViewModels;
using Dormitories.Core.BusinessLogic.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace Dormitories.Core.DataAccess
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dormitory, DormitoryViewModel>();
            CreateMap<DormitoryViewModel, Dormitory>().ForMember(x => x.Id, y => y.Ignore()); ;

            CreateMap<Room, RoomViewModel>()
                .ForMember(x => x.DormitoryName, opt => opt.MapFrom(x => x.Dormitory.Name))
                .ForMember(x => x.DormitoryAddress, opt => opt.MapFrom(x => x.Dormitory.Address))
                .ForMember(x => x.DormitoryId, opt => opt.MapFrom(x => x.Dormitory.Id));

            CreateMap<RoomViewModel, Room>().ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Dormitory.Name, opt => opt.MapFrom(x => x.DormitoryName))
                .ForMember(x => x.Dormitory.Address, opt => opt.MapFrom(x => x.DormitoryAddress))
                .ForMember(x => x.Dormitory.Id, opt => opt.MapFrom(x => x.DormitoryId));

            CreateMap<Dormitory, Room>().ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Dormitory.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Dormitory.Address, opt => opt.MapFrom(x => x.Address))
                .ForMember(x => x.DormitoryId, opt => opt.MapFrom(x => x.Id));
        }   
    }
}
