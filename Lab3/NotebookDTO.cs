namespace Lab3
{
    public class NotebookDTO
    {
        public List<ContactDTO> contacts { get; set; } = new List<ContactDTO>();
        public NotebookDTO() { }
        public NotebookDTO(Notebook notebookToCreateDTO)
        {
            foreach (Contact c in notebookToCreateDTO.contacts)
            {
                contacts.Add(new ContactDTO(c));

            }
        }
    }
}
