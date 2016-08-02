using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
//using FirstFloor.ModernUI.Presentation;

namespace PaK_v1._0.ViewModels
{
    public class TabVM : VMBase
    {
        private usr_access_rights rights = new usr_access_rights();

        private LinkCollection _menulinks;

        public LinkCollection MenuLinks
        {
            get { return _menulinks; }
            set
            {
                _menulinks = value;
                RaisePropertyChanged("MenuLinks");
            }
        }

        private Uri _selrrc;

        public Uri SelSrc
        {
            get { return _selrrc; }
            set
            {
                _selrrc = value;
                RaisePropertyChanged("SelSrc");
            }
        }

        
        public TabVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }

        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/Content/booking_list.xaml"))
            {
                //MenuLinks.Add(new Link { DisplayName = "alle buchungen", Source = new Uri("/Pages/Content/booking_list.xaml#1", UriKind.Relative) });
                //MenuLinks.Add(new Link { DisplayName = "tagessummen", Source = new Uri("/Pages/Content/booking_list.xaml#2", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "alle buchungen", Source = new Uri("/Pages/Content/book_list.xaml", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "tagessummen", Source = new Uri("/Pages/Content/daily_booking_sums.xaml", UriKind.Relative) });
            }
            if (rights.has_right("/Pages/Content/cash_booking.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "bar einzahlung", Source = new Uri("/Pages/Content/cash_booking.xaml", UriKind.Relative) });
            }
            if (rights.has_right("/Pages/Content/new_booking.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "artikel buchung", Source = new Uri("/Pages/Content/new_booking.xaml", UriKind.Relative) });
            }
            if (rights.has_right("/Pages/Content/room_booking.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "zimmer buchung", Source = new Uri("/Pages/Content/room_booking.xaml", UriKind.Relative) });
            }
            if (rights.has_right("/Pages/Content/free_booking.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "freie buchung", Source = new Uri("/Pages/Content/free_booking.xaml", UriKind.Relative) });
            }

            if (rights.has_right("/Pages/Content/booking_list.xaml"))
            {
                SelSrc = new Uri("/Pages/Content/booking_list.xaml#1", UriKind.Relative);
            }

            if (rights.has_right("/Pages/Content/cash_booking.xaml"))
            {
                SelSrc = new Uri("/Pages/Content/cash_booking.xaml", UriKind.Relative);
            }

        }
    }
}
