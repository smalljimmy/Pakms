using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
namespace PaK_v1._0.ViewModels
{
    class birthdaysVM : VMBase
    {
        private PaKEntities _pak = new PaKEntities();

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        public DateTime dtFrom { get; set; }

        private ObservableCollection<birthdays> lbirthdays { get; set; }


        private ICollectionView _birthdays;

        public ICollectionView Birthdays
        {
            get { return _birthdays; }
            set
            {
                if (value != _birthdays)
                {
                    _birthdays = value;
                    RaisePropertyChanged("Birthdays");
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        public birthdaysVM()
        {

            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search());
            dtFrom = DateTime.Today;
//            Today = DateTime.Today.ToLongDateString();
            Title = "Geburtsage  Stand " + dtFrom.ToLongDateString();
            lbirthdays = getlist();
            Birthdays = CollectionViewSource.GetDefaultView(lbirthdays);

        }


        private ObservableCollection<birthdays> getlist()
        {
            var q = _pak.birthdays.Where(b => b.bday != null && b.bday.Value.Month == dtFrom.Month && b.bday.Value.Day == dtFrom.Day);

            //todo: date is displayed as mm/dd/yyyy plus time. change it to german format and show pnly the day.
            // var p = from b in _pak.birthdays where (b.birthday != null && b.birthday.Value.Month == dtFrom.Month && b.birthday.Value.Day == dtFrom.Day)
            //        select Convert.ToDateTime(b.birthday.Value,

            return new ObservableCollection<birthdays>(q.ToList());
        }


        public void Search(){

            Title = "Geburtsage  Stand " + dtFrom.ToLongDateString();
            lbirthdays = getlist();
            Birthdays = CollectionViewSource.GetDefaultView(lbirthdays);

        }

    }
}
