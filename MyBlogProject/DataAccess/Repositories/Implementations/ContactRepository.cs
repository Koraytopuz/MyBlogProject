using Microsoft.EntityFrameworkCore;
using MyBlogProject.Business.Repositories;
using MyBlogProject.DataAccess.Context;
using MyBlogProject.Entities;

namespace MyBlogProject.DataAccess.Repositories.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyBlogDbContext _myBlogDbContext;

        public ContactRepository(MyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task AddAsync(Contact Contact)
        {
            await _myBlogDbContext.Contacts.AddAsync(Contact);
            await _myBlogDbContext.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var Contact = await _myBlogDbContext.Contacts.FindAsync(id); // Kullanıcıyı bul
            if (Contact != null) // Eğer kullanıcı varsa sil
            {
                _myBlogDbContext.Contacts.Remove(Contact);
                await _myBlogDbContext.SaveChangesAsync();
            }
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _myBlogDbContext.Contacts.FindAsync(id);
        }

        public async Task UpdateAsync(Contact Contact)
        {
            _myBlogDbContext.Contacts.Update(Contact);
            _myBlogDbContext.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _myBlogDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Contact>> GetAllContactAsync()
        {
            return await _myBlogDbContext.Contacts.ToListAsync();
        }
    
    }
}
