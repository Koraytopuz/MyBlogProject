using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IToDoListRepository
    {
        Task<bool> BoolAsync(int id);
        Task CreateAsync(ToDoList toDoList);
        Task UpdateAsync(ToDoList toDoList);
        Task DeleteAsync(int id);
        Task<List<ToDoList>> GetAllAsync();
    }
}
