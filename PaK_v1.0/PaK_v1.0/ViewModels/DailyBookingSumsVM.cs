using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using PaK_v1._0.Content;

namespace PaK_v1._0.ViewModels
{
    class DailyBookingSumsVM : VMBase
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

        private ObservableCollection<LBookings> _bkings;
        public ObservableCollection<LBookings> Bkings
        {
            get { return _bkings; }
            set
            {
                _bkings = value;
                RaisePropertyChanged("Bkings");
            }
        }


        public DailyBookingSumsVM()
        {
            _pak = new PaKEntities();
            dtTo = DateTime.Now;
            //dtFrom = dtTo.AddMonths(-1);
            search();

            _commands = new CommandMap();
            _commands.AddCommand("search", (o) => search());

        }

        //filter list by dates
        public void search()
        {
            if (dtFrom == DateTime.MinValue || dtFrom == null || dtFrom.ToString() == "")
            {
                dtFrom = DateTime.Now.AddMonths(-1);
                //dtFrom = _pak.bookings.Count() == 0 ? DateTime.Now : _pak.bookings.OrderBy(x => x.bkg_date).First().bkg_date;
            }

            if (dtTo == null || dtTo.ToString() == "")
                dtTo = DateTime.Now.Date;

            //var query = from b in _pak.bookings.Where(x => x.bkg_date >= dtFrom && x.bkg_date <= dtTo) select b;
            var q = from b in _pak.bookings.Where(x => x.bkg_date >= dtFrom && x.bkg_date <= dtTo)
                    group b by EntityFunctions.TruncateTime(b.bkg_date) into total
                    select new { date = total.Key, total = total };

            var q2 = from b in q.AsEnumerable()
                     select new LBookings
                     {
                         DateTime = b.date.Value,
                         Datum = b.date.Value.ToShortDateString(),
                         Belastung = b.total.Where(x => x.booking_types.btp_id == 1).Sum(x => x.bkg_amount),
                         Gutschrift = b.total.Where(x => x.booking_types.btp_id == 2).Sum(x => x.bkg_amount)
                     };
            Bkings = new ObservableCollection<LBookings>(q2.ToList());


        }

    }
}
