namespace Frontend_Adm.Models;
using MyBlogProject.WebApı.Dtos.PortfolioDtos;
using MyBlogProject.WebApı.Dtos.PortfolioDetailDtos;
    public class PortfolioViewModel
    {
        public List<ResultPortfolioDto> PortfolioList { get; set; }
        public List<ResultPortfolioDetailDto> PortfolioDetailList { get; set; }
    }