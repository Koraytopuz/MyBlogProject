using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public ToDoListRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }
        public async Task AddAsync(ToDoList toDoList)
        {

            // Burada manuel olarak Id değeri atanmamalı, SQL Server otomatik olarak arttıracak.
            await _myBlogDbContext.ToDoLists.AddAsync(toDoList);
            await _myBlogDbContext.SaveChangesAsync();

        }
        public async Task<bool> BoolAsync(int id)
        {
            var toDoList = await _myBlogDbContext.ToDoLists.FindAsync(id);
            return toDoList != null;
        }

        public async Task CreateAsync(ToDoList toDoList)
        {
            await _myBlogDbContext.ToDoLists.AddAsync(toDoList);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var toDoList = await _myBlogDbContext.ToDoLists.FindAsync(id);
            if (toDoList != null)
            {
                _myBlogDbContext.ToDoLists.Remove(toDoList);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }
        public async Task<List<ToDoList>> GetAllAsync()
        {

            return await _myBlogDbContext.ToDoLists.ToListAsync();
        }
        public async Task<ToDoList> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.ToDoLists.FirstOrDefaultAsync(x => x.ToDoListId == id);
        }
        public async Task UpdateAsync(ToDoList toDoList)
        {
            _myBlogDbContext.ToDoLists.Update(toDoList);
            await _myBlogDbContext.SaveChangesAsync();
        }
    }
}
