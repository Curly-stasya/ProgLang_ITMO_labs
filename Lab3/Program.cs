using System.Text.Json;
using System.Xml.Serialization;

namespace Lab3
{
    public class Program
    {
        private static string jsonFileName = "notes.json";
        private static string xmlFileName = "notes.xml";
        public static void Main(string[] args)
        {
            Notebook myNotebook = new Notebook();
            userInterface(myNotebook);
        }
        public static void userInterface(Notebook myNotebook)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("Enter the number of action and press [Enter]. Then follow instructions.");
                    Console.WriteLine("Menu:" + '\n'
                        + "1.View all contacts" + '\n'
                        + "2.Search" + '\n'
                        + "3.New contact" + '\n'
                        + "4.Save" + '\n'
                        + "5.Import" + '\n'
                        + "6.Exit");

                    string? selectedAction = Console.ReadLine();
                    switch (selectedAction)
                    {
                        case "1"://View all contacts
                            if (!myNotebook.IsEmpty())
                            {
                                int i = 1;
                                foreach (Contact c in myNotebook.contacts)
                                {
                                    Console.Write($"#{i} {c}");
                                    Console.WriteLine();
                                    i++;
                                }
                            }
                            else 
                                Console.WriteLine("Your notebook is still empty" + '\n');
                            break;

                        case "2"://Search
                            if (myNotebook.contacts.Count == 0)
                                Console.WriteLine("Your notebook is still empty so it's impossible to find anything in it :(( ");

                            else
                            {
                                //сбор информации от пользователя
                                Console.WriteLine("Search by...(enter the number and press [Enter])" + '\n'
                                + "1. Name" + '\n'
                                + "2. Surname" + '\n'
                                + "3. Name and Surname" + '\n'
                                + "4. Phone" + '\n'
                                + "5. E-mail" + '\n'
                                + "6. All fields");
                                string? selectedSearchingMethod = Console.ReadLine();

                                Console.WriteLine("Recuest: ");
                                string? info = Console.ReadLine();
                                if (info == null)
                                    throw new ArgumentException();

                                //поиск
                                Console.WriteLine("Searching...");

                                //обработка результата
                                IEnumerable<Contact> result = myNotebook.Search(selectedSearchingMethod, info);
                                if (result.Count() == 0)
                                    Console.WriteLine("Nothing was found for your request :( ");
                                else
                                {
                                    Console.WriteLine("Results of searching:");
                                    int j = 1;
                                    foreach (Contact c in result)
                                    {
                                        Console.Write($"#{j} {c}");
                                        Console.WriteLine();
                                        j++;
                                    }
                                    Console.WriteLine();
                                }
                            }
                            break;

                        case "3"://New contact
                            Console.WriteLine("New contact");
                            Console.Write("Name: ");
                            string? name = Console.ReadLine();
                            Console.Write("Surname: ");
                            string? surname = Console.ReadLine();
                            Console.Write("Phone: ");
                            string? phone = Console.ReadLine();
                            Console.Write("E-mail: ");
                            string? email = Console.ReadLine();

                            if (name == null || surname == null || phone == null || email == null)
                                throw new ArgumentException("Not all fields are filled in");

                            myNotebook.AddNewContact(new Contact(name, surname, phone, email));
                            Console.WriteLine('\n' + "Contact seccessfully created"+'\n');

                            //сериализация данных в JSON
                            string fileName = "notes.json";
                            string jsonString = JsonSerializer.Serialize(myNotebook);
                            File.WriteAllText(fileName, jsonString);

                            break;

                        case "6"://Exit
                            exit = true;
                            break;

                        case "4"://Export
                            Console.WriteLine("Save as...(enter the number and press [Enter])" + '\n'
                                + "1. JSON" + '\n'
                                + "2. XML" + '\n'
                                + "3. database SQL");
                            string? selectedSavingMethod = Console.ReadLine();
                            switch (selectedSavingMethod)
                            {
                                case "1"://to JSON
                                    string jsonstringTo = JsonSerializer.Serialize(myNotebook);
                                    File.WriteAllText(jsonFileName, jsonstringTo);
                                    break;

                                case "2": //to XML
                                    NotebookDTO myNotebookDTO = new NotebookDTO(myNotebook);
                                    XmlSerializer mySerializer = new XmlSerializer(typeof(NotebookDTO));

                                    using (FileStream file = new FileStream(xmlFileName, FileMode.OpenOrCreate))
                                    {
                                        mySerializer.Serialize(file, myNotebookDTO);
                                    }

                                    break;
                                case "3": //to SQL

                                    using (var db = new MyAppDbContext())
                                    {
                                        db.Contacts.RemoveRange(db.Contacts);
                                        int idSetter = 1;
                                        db.AddRange(myNotebook.contacts.Select(c => new ContactDb() {
                                            id = idSetter++,
                                            name = c.name,
                                            email = c.email,
                                            surname = c.surname,
                                            phone = c.phone
                                        }));
                                        db.SaveChanges();
                                        break;
                                    }
                            }

                            break;

                        case "5"://Import
                            Console.WriteLine("Import from...(enter the number and press [Enter])" + '\n'
                                + "1. JSON" + '\n'
                                + "2. XML" + '\n'
                                + "3. database SQL");
                            string? selectedImportingMethod = Console.ReadLine();
                            switch (selectedImportingMethod)
                            {
                                case "1"://from JSON
                                    string jsonStringFrom = File.ReadAllText(jsonFileName);
                                    NotebookDTO myNotesDTO = JsonSerializer.Deserialize<NotebookDTO>(jsonStringFrom)!;
                                    myNotebook = new Notebook(myNotesDTO);
                                    break;

                                case "2"://from XML
                                    var mySerializer = new XmlSerializer(typeof(NotebookDTO));
                                    using (var myFileStream = new FileStream(xmlFileName, FileMode.Open))
                                    {
                                        var myObject = (NotebookDTO) mySerializer.Deserialize(myFileStream);
                                    }
                                    break;
                                case "3":
                                    using (var db = new MyAppDbContext())
                                    {
                                        NotebookDTO myNotesDTOFromDB = new NotebookDTO();
                                        myNotesDTOFromDB.contacts = db.Contacts.Select(c => new ContactDTO(c.name, c.surname, c.email, c.phone)).ToList();
                                        myNotebook = new Notebook(myNotesDTOFromDB);
                                        break;
                                    }
                                    break;
                            }

                            break;

                        default:
                            throw new ArgumentException('\n'+"No action selected");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Let's try again"+ '\n');
                }

            }
        }


        private void ToXML(Notebook notebookForSerialize)
        {

        }
        private void TOSQL(Notebook notebookForSerialize)
        {

        }
    }
}