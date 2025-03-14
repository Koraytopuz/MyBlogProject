using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.AboutDtos;

namespace Frontend_Adm.Services
{
    public interface IPortfolioService
    {
        Task<List<AboutDto>> GetAboutsAsync();
        Task<List<Skill>> GetSkillsAsync();
        Task<List<PortfolioDetail>> GetPortfolioDetailsAsync();
        Task<List<Contact>> GetContactsAsync();
    }
}

