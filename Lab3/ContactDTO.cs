namespace Lab3
{
    public class ContactDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public ContactDTO(string name, string surname, string email, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
        }

        public ContactDTO(Contact contactToCreateDTO)
        {
            this.name = contactToCreateDTO.name;
            this.surname = contactToCreateDTO.surname;
            this.email = contactToCreateDTO.email;
            this.phone = contactToCreateDTO.phone;
        }
        public ContactDTO() { }
    }
}
