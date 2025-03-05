using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.DataAccess.Repositories.Implementations;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task CreateToDoListAsync(Entities.ToDoList toDoList)
        {
            await _toDoListRepository.CreateAsync(toDoList);
        }

        public async Task UpdateToDoListAsync(Entities.ToDoList toDoList)
        {
            await _toDoListRepository.UpdateAsync(toDoList);
        }

        public async Task DeleteToDoListAsync(int id)
        {
            await _toDoListRepository.DeleteAsync(id);
        }

        public async Task<bool> BoolAsync(int id)
        {
            return await _toDoListRepository.BoolAsync(id);
        }

        public async Task<List<ToDoList>> GetAllAsync()
        {

            return await _toDoListRepository.GetAllAsync();
        }
    }
}
