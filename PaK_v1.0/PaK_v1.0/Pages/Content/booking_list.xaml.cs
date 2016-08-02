using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows;
using PaK_v1._0.Models;
using PaK_v1._0.ViewModels;
using System.Data.Entity;
using System.Collections.ObjectModel;
using PaK_v1._0.utilities;
using System.ComponentModel;
using System.Data.Objects;

namespace PaK_v1._0.Content
{

    public class Booking : INotifyPropertyChanged
    {
        public DateTime DateTime { get; set; }
        public string Datum { get; set; }
        public string Zeit { get; set; }
        public string Kontonummer { get; set; }
        public decimal Gutschrift { get; set; }
        public decimal Belastung { get; set; }
        public string Zimmer { get; set; }
        public string User { get; set; }
        public bookings _booking { get; set; }

        private Boolean _isSelected;
        public Boolean IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

    }




    /// <summary>
    /// Interaction logic for acct_list.xaml
    /// </summary>
    public partial class booking_list : UserControl, IContent
    {
        private PaKEntities db = new PaKEntities();

        ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();


        public booking_list()
        {
            InitializeComponent();

            btnSearch.Command = new DelegateCommand(Search, null);
        }


        private void Search(object parameter)
        {
            var source = CollectionViewSource.GetDefaultView(DG1.ItemsSource);
            source.Filter = x => ((Booking)x).DateTime.Date >= dtFrom.SelectedDate && ((Booking)x).DateTime.Date <= dtTo.SelectedDate;
            source.Refresh();
        }




        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            var filter = int.Parse(e.Fragment); //Can't recall if the # is in here, debug and see


            dtFrom.SelectedDate = db.bookings.Count() == 0 ? DateTime.Now : db.bookings.OrderBy(x=>x.bkg_date).First().bkg_date;
            dtTo.SelectedDate = DateTime.Now.Date;

            switch (filter)
            {
                case 1: // Alle
                    var query = from b in db.bookings select b;
                    var query2 = from b in query.AsEnumerable()
                               select new Booking
                               {
                                   DateTime = b.bkg_date,
                                   Datum = b.bkg_date.Date.ToShortDateString(),
                                   Zeit = b.bkg_date.ToShortTimeString(),
                                   Kontonummer = b.accounts.act_id.ToString(),
                                   Belastung = b.booking_types.btp_id == 1 ? b.bkg_amount : 0,
                                   Gutschrift = b.booking_types.btp_id == 2 ? b.bkg_amount : 0,
                                   Zimmer = b.rooms == null ? "" : b.rooms.room_number

                               };
                    bookings = new ObservableCollection<Booking>(query2.ToList());

                    break;
                case 2: //Tagessumme
                    var q = from b in db.bookings
                            group b by EntityFunctions.TruncateTime(b.bkg_date) into total
                            //where total.Key >= dtFrom.SelectedDate && total.Key <= dtTo.SelectedDate
                            select new { date = total.Key, total = total };

                     var q2 = from b in q.AsEnumerable()
                               select new Booking
                               {
                                   DateTime = b.date.Value,
                                   Datum = b.date.Value.ToShortDateString(),
                                   Belastung = b.total.Where(x=>x.booking_types.btp_id == 1).Sum(x=>x.bkg_amount),
                                   Gutschrift = b.total.Where(x => x.booking_types.btp_id == 2).Sum(x => x.bkg_amount)
                               };

                    bookings = new ObservableCollection<Booking>(q2.ToList());
                    break;
                case 3:
                    
                    break;
                case 4:
                    break;
                default:
                    break;
            }

            DG1.DataContext = bookings;

        }
            
        
        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }

}
