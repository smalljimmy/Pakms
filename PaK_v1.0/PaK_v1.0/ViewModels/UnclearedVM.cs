using PaK_v1._0.Content;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;



namespace PaK_v1._0.ViewModels
{
    class UnclearedVM : VMBase, INotifyPropertyChanged
    {
        private PaKEntities db = new PaKEntities();
        private CommandMap _commands;

        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        public DateTime dtFrom { get; set; }
        public DateTime dtTo { get; set; }

        public ObservableCollection<Booking> bookings { get; set; }

        public ICollectionView bookingView { get; set; }

        private DelegateCommand clearCommand;

        //return the total booking amount from the selected bookings
        public decimal totalSelectedAmount
        {
            get
            {
                return this.bookings.Sum(
                    x => x.IsSelected ? x.Gutschrift : 0);
            }
        }


        public UnclearedVM()
        {
            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search());
            clearCommand = new DelegateCommand(x => Clear(), x => CanClear());
            _commands.AddCommand("clear", clearCommand);

            //initialize search list
            dtFrom = db.bookings.Count() == 0 ? DateTime.Now : db.bookings.OrderBy(x => x.bkg_date).First().bkg_date;
            dtTo = DateTime.Now.Date;

            //var query = from b in db.bookings where b.clearances == null && b.booking_types.btp_id == 2 && b.bkg_amount > 0 select b;
            var query = from b in db.bookings where b.clearances == null && b.booking_types.btp_id == 2 select b;
            var query2 = from b in query.AsEnumerable()
                         select new Booking
                         {
                             DateTime = b.bkg_date,
                             Datum = b.bkg_date.Date.ToShortDateString(),
                             Zeit = b.bkg_date.ToShortTimeString(),
                             Kontonummer = b.accounts.act_id.ToString(),
                             Belastung = b.booking_types.btp_id == 1 ? b.bkg_amount : 0,
                             Gutschrift = b.booking_types.btp_id == 2 ? b.bkg_amount : 0,
                             Zimmer = b.rooms == null ? "" : b.rooms.room_number,
                             _booking = b,
                             IsSelected = false
                         };
            bookings = new ObservableCollection<Booking>(query2.ToList());
            foreach (Booking b in bookings){
                b.PropertyChanged += this.OnViewModelPropertyChanged;
            }

            bookingView = CollectionViewSource.GetDefaultView(bookings);

        }



        //filter list by dates
        public void Search(){

            bookingView.Filter = x => ((Booking)x).DateTime.Date >= dtFrom.Date && ((Booking)x).DateTime.Date <= dtTo.Date;
            bookingView.Refresh();
        
        }

        public void Clear()
        {
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            clearances c = new clearances()
            {
                clr_date = DateTime.Now,
                clr_sum = totalSelectedAmount,
                usr_id = ApplicationState.GetValue<int>("userid"),
                station_id = 1
            };


            this.bookings.Where(x => x.IsSelected).ToList().ForEach(b => clearBooking(b, c));

            
            // prepare the pdf template for printing:
            // get the latest clearance id
            string clr_id = db.clearances.OrderByDescending(x => x.clr_id).FirstOrDefault().clr_id.ToString();
            string usr = db.users.SingleOrDefault(u => u.usr_id == c.usr_id).usr_name;
            List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();
            keys.Add(new KeyValuePair<string, string>("Today", DateTime.Now.ToShortDateString()));
            keys.Add(new KeyValuePair<string, string>("ClearanceNumber", clr_id));
            keys.Add(new KeyValuePair<string, string>("ClearanceTime", c.clr_date.ToString()));
            keys.Add(new KeyValuePair<string, string>("Amount", c.clr_sum.ToString()));
            keys.Add(new KeyValuePair<string, string>("User", usr));
            keys.Add(new KeyValuePair<string, string>("Date", DateTime.Now.ToString()));

            string filename = "Abrechnungsprotokoll_" + usr + DateTime.Now.ToFileTimeUtc().ToString() + ".pdf";
            PDFTemplate.ReplacePdfForm(keys, "clearance_prot_tpl.pdf", filename );

            System.Diagnostics.Process.Start(appRootDir + "\\" + filename);

            RaisePropertyChanged("totalSelectedAmount");
        }

        public Boolean CanClear()
        {
            return this.bookings.Any(x => x.IsSelected);
        }


        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";
            if (e.PropertyName == IsSelected)
                RaisePropertyChanged("totalSelectedAmount");

            clearCommand.RaiseCanExecuteChanged();
        }

        private void clearBooking(Booking b, clearances c)
        {             
            b._booking.clearances = c;
            db.SaveChanges();
            bookings.Remove(b);
        }
    }
}
