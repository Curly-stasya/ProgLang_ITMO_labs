namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NoteBook myNoteBook = new NoteBook();
            userInterface(myNoteBook);
        }
        public static void userInterface(NoteBook myNoteBook)
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
                        + "4.Exit");

                    string? selectedAction = Console.ReadLine();
                    switch (selectedAction)
                    {
                        case "1"://View all contacts
                            if (!myNoteBook.IsEmpty())
                            {
                                int i = 1;
                                foreach (Contact c in myNoteBook.contacts)
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
                            if (myNoteBook.contacts.Count == 0)
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
                                IEnumerable<Contact> result = myNoteBook.Search(selectedSearchingMethod, info);
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

                            myNoteBook.AddNewContact(new Contact(name, surname, phone, email));
                            Console.WriteLine('\n' + "Contact seccessfully created"+'\n');

                            break;

                        case "4"://Exit
                            exit = true;
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
    }
}