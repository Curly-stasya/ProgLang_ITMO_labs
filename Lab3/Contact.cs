namespace Lab3
{

    public class Contact
    {
        public string name { get; private set; }
        public string surname { get; private set; }
        public string email { get; private set; }
        public string phone { get; private set; }

        public Contact(string name, string surname, string email, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;

        }
        public Contact(ContactDTO contactDTO)
        {
            this.name = contactDTO.name;
            this.surname = contactDTO.surname;
            this.email = contactDTO.email;
            this.phone = contactDTO.phone;

        }

        public Contact() { }

        override
        public string ToString()
        {
            string s = "";
            s = $"Name: {name}\n Surname: {surname}\n Phone: {phone}\n E-mail: {email}";
            return s;
        }
    }
}

