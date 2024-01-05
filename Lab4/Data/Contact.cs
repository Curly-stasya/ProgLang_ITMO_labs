using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebookLib
{
    public class Contact
    {
        public int id { get; set; }
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
}
