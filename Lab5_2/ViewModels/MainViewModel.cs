using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Lab5_2.Models;
using System.Collections.ObjectModel;

namespace Lab5_2.ViewModels
{
    class MainViewModel: ViewModelBase
    {

        public static ObservableCollection<ContactDb> Contacts { get; set; }
        public ContactDb SelectedContact { get; set; }
        public MainViewModel()
        {
            MyAppDbContext db = new MyAppDbContext();
            Contacts = new ObservableCollection<ContactDb>(db.Contacts.ToList());
        }
        
    }
}
