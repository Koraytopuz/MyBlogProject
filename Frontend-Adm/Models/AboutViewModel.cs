using System.Collections.Generic;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.CommentDtos;
using MyBlogProject.WebApı.Dtos.ContactDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using MyBlogProject.WebApı.Dtos.PostDtos;
using MyBlogProject.WebApı.Dtos.SkillDtos;
using MyBlogProject.WebApı.Dtos.SocialMediaDtos;
using MyBlogProject.WebApı.Dtos.ToDoListDtos;
using MyBlogProject.WebApı.Dtos.UserDtos;

namespace Frontend_Adm.Models
{
    public class AboutViewModel
    {

        public List<AboutDto> AboutList { get; set; }
        public List<ResultSkillDto> SkillList { get; set; }
        public List<ResultPortfolioDto> PortfolioList { get; set; }
        public List<ResultPortfolioDetailDto> PortfolioDetailList { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ResultContactDto> ResultContacts { get; set; }
        public List<PostDto> Posts { get; set; }
        public List<SocialMediaDto> SocialMedias { get; set; }
        public List<ToDoListDto> ToDoLists { get; set; }
        public List<UserDto> Users { get; set; }
    }
}

