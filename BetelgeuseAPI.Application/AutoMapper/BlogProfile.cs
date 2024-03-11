
using AutoMapper;
using BetelgeuseAPI.Application.DTOs.Response;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.AutoMapper
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogAppUserDto, AppUser>();
            CreateMap<MetaDataResponseDto, MetaData>().ReverseMap();
        }
    }
}
