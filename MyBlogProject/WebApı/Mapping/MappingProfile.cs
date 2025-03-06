using AutoMapper;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.CommentDtos;
using MyBlogProject.WebApı.Dtos.PostDtos;
using MyBlogProject.WebApı.Dtos.ToDoListDtos;
using MyBlogProject.WebApı.Dtos.UserDtos;

namespace MyBlogProject.WebApi.Mapping  // Burada Mapping klasörüne yerleştiriyoruz
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Entity'yi UserDTO'ya dönüştür
            CreateMap<User, UserDto>();
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<ToDoList, ToDoListDto>().ReverseMap();
            // Post Entity'yi PostDTO'ya dönüştür
            CreateMap<Post, PostDto>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)); // Users'dan sadece UserName alıyoruz
            CreateMap<PostDto, Post>();
        }
    }
}
