//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MyBlogProject.Business.Interfaces;
//using MyBlogProject.Business.Services;
//using MyBlogProject.Entities;
//using MyBlogProject.WebApı.Dtos.SocialMediaDtos;

//namespace MyBlogProject.WebApı.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SocialMediaController : ControllerBase
//    {
//        private readonly ISocialMediaService _socialMediaService;
//        private readonly IMapper _mapper;

//        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
//        {
//            _socialMediaService = socialMediaService;
//            _mapper = mapper;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var socialMedias = await _socialMediaService.GetAllAsync();
//            return Ok(socialMedias);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var socialMedias = await _socialMediaService.GetByIdAsync(id);
//            if (socialMedias == null)
//                return NotFound();
//            return Ok(socialMedias);
//        }

//        [HttpPost]
//        //[Authorize(Roles ="Admin")]
//        public async Task<IActionResult> Create([FromBody] SocialMedia socialMediaDto)
//        {
//            if (socialMediaDto == null)
//                return BadRequest();

//            var socialMedias = _mapper.Map<SocialMedia>(socialMediaDto);
//            await _socialMediaService.AddAsync(socialMedias);

//            return Ok("SocialMedia Created Successful");
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] SocialMedia socialMedia)
//        {
//            if (id != socialMedia.SocialMediaId)
//                return BadRequest("SocialMedia ID mismatch");

//            await _socialMediaService.UpdateAsync(socialMedia);
//            return Ok("SocialMedia Updated Successful");
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _socialMediaService.DeleteAsync(id);
//            return Ok("SocialMedia Deleted Successful");
//        }

//    }
//}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.SocialMediaDtos;

namespace MyBlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socialMedias = await _socialMediaService.GetAllAsync();
            return Ok(socialMedias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var socialMedia = await _socialMediaService.GetByIdAsync(id);
            if (socialMedia == null)
                return NotFound();
            return Ok(socialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SocialMediaDto socialMediaDto)
        {
            if (socialMediaDto == null)
                return BadRequest();

            var socialMedia = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.AddAsync(socialMedia);

            return Ok("SocialMedia Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SocialMediaDto socialMediaDto)
        {
            if (id != socialMediaDto.SocialMediaId)
                return BadRequest("SocialMedia ID mismatch");

            var socialMedia = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.UpdateAsync(socialMedia);
            return Ok("SocialMedia Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _socialMediaService.DeleteAsync(id);
            return Ok("SocialMedia Deleted Successfully");
        }
    }
}
