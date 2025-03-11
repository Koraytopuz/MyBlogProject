using MyBlogProject.Business.Repositories;
using MyBlogProject.Business.Services;
using MyBlogProject.Entities;

namespace MyBlogProject.Business.Interfaces
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _ContactRepository;
        public ContactService(IContactRepository ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _ContactRepository.GetAllContactAsync();
        }

        public async Task CreateContactAsync(Contact Contact)
        {
            await _ContactRepository.AddAsync(Contact);
        }
        public async Task UpdateContactAsync(Contact Contact)
        {
            var existingContact = await _ContactRepository.GetByIdAsync(Contact.Id);
            if (existingContact != null)
            {
                existingContact.Subject = Contact.Subject;
                existingContact.Email = Contact.Email;
                existingContact.Message = Contact.Message;
                existingContact.Name = Contact.Name;
                await _ContactRepository.UpdateAsync(existingContact);
            }
        }
        public async Task DeleteContactAsync(int id)
        {
            var Contact = await _ContactRepository.GetByIdAsync(id);
            if (Contact != null)
            {
                await _ContactRepository.DeleteContactAsync(id);
            }
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _ContactRepository.GetByIdAsync(id);
        }
    
    }
}
