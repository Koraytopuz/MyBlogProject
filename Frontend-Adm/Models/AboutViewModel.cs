using System.Collections.Generic;
using MyBlogProject.WebApı.Dtos.AboutDtos;
using MyBlogProject.WebApı.Dtos.SkillDtos;

namespace Frontend_Adm.Models
{
    public class AboutViewModel
    {
        public List<AboutDto> AboutList { get; set; }
        public List<ResultSkillDto> SkillList { get; set; }
    }
}

