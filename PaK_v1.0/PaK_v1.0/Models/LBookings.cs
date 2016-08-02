using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PaK_v1._0.Models
{
    public class LBookings
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
        //private Boolean _isSelected;
        //public Boolean IsSelected
        //{
        //    get
        //    {
        //        return _isSelected;
        //    }
        //    set
        //    {
        //        if (value == _isSelected)
        //            return;

        //        _isSelected = value;
        //        OnPropertyChanged("IsSelected");
        //    }
        //}
    }
}
