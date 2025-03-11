using MyBlogProject.Entities;

namespace MyBlogProject.Business.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact Contact);
        Task UpdateAsync(Contact Contact);
        Task DeleteContactAsync(int id);
    }
}
