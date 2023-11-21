namespace Lab2
{
    public class NoteBook
    {
        private List<Contact> contacts;
        public class Contact
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public string phone { get; set; }

            public Contact(string name, string surname, string email, string phone)
            {
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.phone = phone;
              
            }

            override
            public string ToString()
            {
                string s = "";
                s = $"Name: {name}\n Surname: {surname}\n Phone: {phone}\n E-mail: {email}";
                return s;
            }

        }

        public NoteBook()
        {
            contacts = new List<Contact>();
        }

        public void UserInterface()
        {
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                string? selectedAction = Console.ReadLine();
                switch (selectedAction)
                {
                    case "1":
                        PrintAllNotes();
                        break;

                    case "2":
                        Search();
                        break;

                    case "3":
                        Console.WriteLine("New contact");
                        Console.Write("Name: ");
                        string? name = Console.ReadLine();
                        Console.Write("Surname: ");
                        string? surname = Console.ReadLine();
                        Console.Write("Phone: ");
                        string? phone = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string? email = Console.ReadLine();
                        Contact contact = new Contact(name, surname, phone, email);

                        AddNewContact(contact);
                            
                        break;

                    case "4":
                        exit=true;
                        break;

                    default:
                        throw new ArgumentException("Incorrect input");
                }
            }
            
        }

        private void PrintMenu()
        {
            Console.WriteLine("Enter the number of action and press [Enter]. Then follow instructions.");
            Console.WriteLine("Menu:" + '\n'
                + "1.View all contacts" + '\n'
                + "2.Search" + '\n'
                + "3.New contact" + '\n'
                + "4.Exit");

        }
        public void PrintAllNotes()
        {
            if (contacts.Count!=0)
            {
                int i = 1;
                foreach (Contact c in contacts)
                {
                    Console.Write($"#{i} {c}");
                    Console.WriteLine();
                    i++;
                }
            }
            else Console.WriteLine("Your notebook is still empty"+'\n');
            
        }
        public void Search()
        {
            Console.WriteLine("Search by..." + '\n'
                + "1. Name" + '\n' 
                + "2. Surname" + '\n' 
                + "3. Name and Surname" + '\n' 
                + "4. Phone" + '\n' 
                + "5. E-mail" + '\n' 
                + "6. All fields");
            string? selectedAction = Console.ReadLine();

            Console.WriteLine("Recuest: ");
            string? info = Console.ReadLine();

            if (info == null) throw new ArgumentException();
            Console.WriteLine("Searching...");
            NoteBook FoundContacts = new NoteBook();

            switch (selectedAction)
            {
                case "1":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;

                case "2":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;

                case "3":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;

                case "4":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.phone.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;

                case "5":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.email.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;
                case "6":
                    foreach (Contact contact in contacts)
                    {
                        if (contact.name.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.surname.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.phone.Contains(info, StringComparison.OrdinalIgnoreCase) ||
                            contact.email.Contains(info, StringComparison.OrdinalIgnoreCase))
                        {
                            FoundContacts.AddNewContact(contact);
                        }
                    }
                    break;

                default:
                    throw new ArgumentException("Incorrect input");
            }
            FoundContacts.PrintAllNotes();

        }
        //private NoteBook SearchByName(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");

        //    foreach (Contact contact in contacts)
        //    {
        //        if (contact.name.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;
        //}
        //private NoteBook SearchBySurname(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");

        //    foreach (Contact contact in contacts)
        //    {
        //        if (contact.surname.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;
        //}
        //private NoteBook SearchByNameSurname(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");
        //    // TODO: Поиск контакта по имени и фамилии
        //    foreach (Contact contact in contacts)
        //    {
        //        if (contact.name.Contains(info) ||
        //            contact.surname.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;

        //}
        //private NoteBook SearchByPhone(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");
        //    foreach(Contact contact in contacts)
        //    {
        //        if (contact.phone.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;
        //}
        //private NoteBook SearchByEmail(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");
        //    foreach(Contact contact in contacts)
        //    {
        //        if (contact.email.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;
        //}
        //private NoteBook SearchByAllFields(string info)
        //{
        //    NoteBook FoundContacts = new NoteBook("only creating");
        //    foreach (Contact contact in contacts)
        //    {
        //        if (contact.name.Contains(info) ||
        //            contact.surname.Contains(info)||
        //            contact.phone.Contains(info)||
        //            contact.email.Contains(info))
        //        {
        //            FoundContacts.AddNewContact(contact);
        //        }
        //    }

        //    return FoundContacts;
        //}

        public void AddNewContact(Contact contact)
        {

            if (contact == null)
                throw new ArgumentNullException();

            contacts.Add(contact);
            Console.WriteLine("Contact seccessfully created");

        }
    }
}
