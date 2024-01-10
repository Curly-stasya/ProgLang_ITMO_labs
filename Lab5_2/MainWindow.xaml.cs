using Lab5_2.ViewModels;
using System.Windows;


namespace Lab5_2
{
    public partial class MainWindow : Window
    {
        MyAppDbContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new MyAppDbContext();

        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            string inputName = name.Text;
            string inputSurname = surname.Text;
            string inputPhone = phone.Text;
            string inputEmail = email.Text;
            ContactDb newContact = new ContactDb(inputName, inputSurname, inputEmail, inputPhone);
            db.Contacts.Add(newContact);
            db.SaveChanges();
            MainViewModel.Contacts.Clear();
            foreach (ContactDb contact in db.Contacts)
                MainViewModel.Contacts.Add(contact);
            name.IsEnabled = true;
            name.Text = "";
            surname.IsEnabled = true;
            surname.Text = "";
            phone.IsEnabled = true;
            phone.Text = "";
            email.IsEnabled = true;
            email.Text = "";
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            name.IsEnabled = true;
            name.Text = "";
            surname.IsEnabled = true;
            surname.Text = "";
            phone.IsEnabled = true;
            phone.Text = "";
            email.IsEnabled = true;
            email.Text = "";
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
