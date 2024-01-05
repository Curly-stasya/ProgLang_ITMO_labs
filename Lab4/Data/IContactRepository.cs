namespace Lab4.Data
{
    public interface IContactRepository : IDisposable
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> GetContactAsync(int contactId);
        Task<List<Contact>> GetContactByNameAsync(string name);
        Task<List<Contact>> GetContactBySurnameAsync(string surname);
        Task<List<Contact>> GetContactByPhoneAsync(string phone);
        Task<List<Contact>> GetContactByEmailAsync(string email);
        Task InsertContactAsync(ContactCreateModel newContact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
        Task SaveAsync();
    }
}
