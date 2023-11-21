namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                NoteBook myNoteBook = new NoteBook();
                myNoteBook.UserInterface();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}