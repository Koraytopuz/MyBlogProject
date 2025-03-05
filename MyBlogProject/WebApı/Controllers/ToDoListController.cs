using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Interfaces;
using MyBlogProject.Business.Services;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;
using MyBlogProject.WebApı.Dtos.PostDtos;
using MyBlogProject.WebApı.Dtos.ToDoListDtos;

namespace MyBlogProject.WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoListService toDoListService, IMapper mapper)
        {
            _toDoListService = toDoListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toDoList = await _toDoListService.GetAllAsync();
            var toDoListDtos = _mapper.Map<List<ToDoListDto>>(toDoList);
            return Ok(toDoListDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoListDto toDoListDto)
        {
            if (toDoListDto == null)
                return BadRequest();

            var toDoList = _mapper.Map<ToDoList>(toDoListDto); 
            await _toDoListService.CreateToDoListAsync(toDoList);

            return Ok("ToDoList Created Successful");
        }
        // Görev güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoList toDoList)
        {
            if (id != toDoList.ToDoListId)
                return BadRequest("ToDoList ID mismatch");

            await _toDoListService.UpdateToDoListAsync(toDoList);
            return Ok("ToDoList Updated Successful");
        }

        // Görev sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoListService.DeleteToDoListAsync(id);
            return Ok("ToDoList Deleted Successful");
        }
    }
}
