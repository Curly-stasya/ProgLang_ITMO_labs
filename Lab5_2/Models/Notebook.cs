using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2.Models
{
    class Notebook
    {
        public static List<Contact> Contacts { get; set; }
        public static List<Contact> InitialContacts()
        {

            Contacts=new List<Contact>
            {
                new Contact
                {
                    name = "Nastasya",
                    surname = "Smirnyagina",
                    phone = "89609693816",
                    email = "nassmir03@gmail.com"
                },
                new Contact
                {
                    name = "Irina",
                    surname = "Smirnyagina",
                    phone = "89069477589",
                    email = "siv.tomsk@rambler.ru"
                },
                new Contact
                {
                    name = "Polina",
                    surname = "Antropova",
                    phone = "89138575690",
                    email = "antropova@gmail.com"
                },
                new Contact
                {
                    name = "Goorge",
                    surname = "Gavlyatshin",
                    phone = "89061926410",
                    email = "DGjhbejw@gmail.com"
                }
            };
            return Contacts;
        }
        public static void AddNewContact(Contact c)
        {
            if (Contacts != null)
                Contacts.Append(c);
        }

    }
}
