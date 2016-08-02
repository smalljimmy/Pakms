using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;

namespace PaK_v1._0.ViewModels
{
    class BookListVM : VMBase
    {
        private PaKEntities _pak;

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private DateTime _dtfrom;
        public DateTime dtFrom
        {
            get { return _dtfrom; }
            set
            {
                _dtfrom = value;
                RaisePropertyChanged("dtFrom");
            }
        }

        private DateTime _dtto;
        public DateTime dtTo
        {
            get { return _dtto; }
            set
            {
                _dtto = value;
                RaisePropertyChanged("dtTo");
            }
        }

        private ObservableCollection<LBookings> _bkings; // = new ObservableCollection<LBookings>();
        public ObservableCollection<LBookings> Bkings
        {
            get { return _bkings; }
            set
            {
                _bkings = value;
                RaisePropertyChanged("Bkings");
            }
        }


        public BookListVM()
        {
            _pak = new PaKEntities();
            dtTo = DateTime.Now;
            //dtFrom = dtTo.AddMonths(-1);
            search();

            _commands = new CommandMap();
            _commands.AddCommand("search", (o) => search());
        }


        public void search()
        {
            if (dtFrom == DateTime.MinValue || dtFrom == null || dtFrom.ToString() == "")
            {
                dtFrom = DateTime.Now.AddMonths(-1);
                //dtFrom = _pak.bookings.Count() == 0 ? DateTime.Now : _pak.bookings.OrderBy(x => x.bkg_date).First().bkg_date;
            }

            if (dtTo == null || dtTo.ToString() == "")
                dtTo = DateTime.Now.Date;

            var query = from b in _pak.bookings.Where(x => x.bkg_date >= dtFrom && x.bkg_date <= dtTo) select b;
            var query2 = from b in query.AsEnumerable()
                         select new LBookings
                         {
                             DateTime = b.bkg_date,
                             Datum = b.bkg_date.Date.ToShortDateString(),
                             Zeit = b.bkg_date.ToShortTimeString(),
                             Kontonummer = b.accounts.act_id.ToString(),
                             Belastung = b.booking_types.btp_id == 1 ? b.bkg_amount : 0,
                             Gutschrift = b.booking_types.btp_id == 2 ? b.bkg_amount : 0,
                             Zimmer = b.rooms == null ? "" : b.rooms.room_number,
                             User = b.users.usr_name

                         };
            Bkings = new ObservableCollection<LBookings>(query2.ToList());

        }

    }




    //public class Booking : VMBase
    //{
    //    public DateTime DateTime { get; set; }
    //    public string Datum { get; set; }
    //    public string Zeit { get; set; }
    //    public string Kontonummer { get; set; }
    //    public decimal Gutschrift { get; set; }
    //    public decimal Belastung { get; set; }
    //    public string Zimmer { get; set; }
    //    public string User { get; set; }
    //    public bookings _booking { get; set; }

    //    private Boolean _isSelected;
    //    public Boolean IsSelected
    //    {
    //        get
    //        {
    //            return _isSelected;
    //        }
    //        set
    //        {
    //            if (value == _isSelected)
    //                return;

    //            _isSelected = value;
    //            RaisePropertyChanged("IsSelected");
    //        }
    //    }
    //}

}
