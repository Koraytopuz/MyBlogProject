using AutoMapper;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.CommentDtos;
using MyBlogProject.WebApı.Dtos.ContactDtos;
using MyBlogProject.WebApı.Dtos.PostDtos;
using MyBlogProject.WebApı.Dtos.SocialMediaDtos;
using MyBlogProject.WebApı.Dtos.ToDoListDtos;
using MyBlogProject.WebApı.Dtos.UserDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
using MyBlogProject.WebApı.Dtos.SkillDtos;

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
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Portfolio,ResultPortfolioDto>().ReverseMap();
            CreateMap<PortfolioDetail,ResultPortfolioDetailDto>().ReverseMap();
            CreateMap<Skill,ResultSkillDto>().ReverseMap();
            // Post Entity'yi PostDTO'ya dönüştür
            CreateMap<Post, PostDto>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)); // Users'dan sadece UserName alıyoruz
            CreateMap<PostDto, Post>();
        }
    }
}
