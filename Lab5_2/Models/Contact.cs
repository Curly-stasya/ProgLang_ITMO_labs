using System;
using System.Collections.Generic;
using DevExpress.Mvvm;

namespace Lab5_2.Models
{
    public class Contact : ViewModelBase
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
