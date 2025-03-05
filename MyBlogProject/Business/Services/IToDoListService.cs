using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IToDoListService
    {
        Task CreateToDoListAsync(ToDoList toDoList);
        Task<bool> BoolAsync(int id);
        Task DeleteToDoListAsync(int id);
        Task<List<ToDoList>> GetAllAsync();

        Task UpdateToDoListAsync(ToDoList toDoList);
    }
}
