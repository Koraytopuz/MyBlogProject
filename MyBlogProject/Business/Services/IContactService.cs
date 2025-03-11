using MyBlogProject.Entities;

namespace MyBlogProject.Business.Services
{
    public interface IContactService
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task CreateContactAsync(Contact Contact);
        Task DeleteContactAsync(int id);
        Task UpdateContactAsync(Contact Contact);
    }
}
