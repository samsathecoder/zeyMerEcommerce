using AutoMapper;

using ZeyMer.Domain.Dtos.User;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Application.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Hashlemeyi serviste yapacağız
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}