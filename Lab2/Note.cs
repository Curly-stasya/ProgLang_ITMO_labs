namespace Lab2
{
    public class NoteBook
    {
        public List<Contact> contacts { get; private set; } = new List<Contact>();

        public NoteBook() { }


        public IEnumerable<Contact> Search(string? selectedAction, string? info)
        {
            if(info==null) 
                throw new ArgumentNullException("invalid input");

            if (contacts.Count == 0)
                throw new Exception("Your notebook is still empty so nothing was found :(( ");

            var results = new List<Contact>();

            switch (selectedAction)
            {
                case "1"://by name
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;

                case "2"://by surname
                    foreach (Contact contact in contacts)
                    {
                        if (contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;

                case "3"://by name & surmame
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;

                case "4"://by phone number
                    foreach (Contact contact in contacts)
                    {
                        if (contact.phone.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;

                case "5"://by email
                    foreach (Contact contact in contacts)
                    {
                        if (contact.email.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;
                case "6"://by all fields
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.phone.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.email.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            results.Add(contact);
                        }
                    }
                    break;

                default:
                    throw new ArgumentException("Incorrect input");
            }

            return results;

        }

        public void AddNewContact(Contact contact)
        {

            if (contact == null)
                throw new ArgumentNullException();

            contacts.Add(contact);

        }
        public bool IsEmpty()
        {
            return contacts.Count == 0;
        }
    }
}
