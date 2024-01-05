using MyNotebookLib;
using Microsoft.EntityFrameworkCore;

namespace NoteBookProject.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(new object[] { contactId });
            if (contact == null) return;
            _context.Contacts.Remove(contact);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Contact> GetContactAsync(int contactId) => await _context.Contacts.FindAsync(new object[] { contactId });//поиск по первичному ключу

        public async Task<List<Contact>> GetContactsAsync() => await _context.Contacts.ToListAsync();

        public async Task InsertContactAsync(ContactCreateModel newContact) => await _context.Contacts.AddAsync(new Contact(
            newContact.name, newContact.surname, newContact.email, newContact.phone));

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task UpdateContactAsync(Contact contact)
        {
            var contactFromDb = await _context.Contacts.FindAsync(new object[] { contact.id });
            if (contactFromDb == null) return;

            contactFromDb.name = contact.name;
            contactFromDb.surname = contact.surname;
            contactFromDb.email = contact.email;
            contactFromDb.phone = contact.phone;

            _context.Contacts.Update(contactFromDb);
        }

        public async Task<List<Contact>> GetContactByNameAsync(string name)
        {
            var contacts = await _context.Contacts.ToListAsync();
            var res = contacts.Where(c => c.name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return res;
        }

        public async Task<List<Contact>> GetContactBySurnameAsync(string surname)
        {
            var contacts = await _context.Contacts.ToListAsync();
            var res = contacts.Where(c => c.surname.Contains(surname, StringComparison.OrdinalIgnoreCase)).ToList();
            return res;
        }
        public async Task<List<Contact>> GetContactByPhoneAsync(string phone)
        {
            var contacts = await _context.Contacts.ToListAsync();
            var res = contacts.Where(c => c.phone.Contains(phone, StringComparison.OrdinalIgnoreCase)).ToList();
            return res;
        }
        public async Task<List<Contact>> GetContactByEmailAsync(string email)
        {
            var contacts = await _context.Contacts.ToListAsync();
            var res = contacts.Where(c => c.email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
            return res;
        }
    }
}
