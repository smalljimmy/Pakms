using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
using FirstFloor.ModernUI.Presentation;

namespace PaK_v1._0.ViewModels
{
    class RoomsVM : VMBase
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


        public RoomsVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }


        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/Content/new_room.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "neues zimmer", Source = new Uri("/Pages/Content/new_room.xaml", UriKind.Relative) });
                SelSrc = new Uri("/Pages/Content/new_room.xaml", UriKind.Relative);
            }

            if (rights.has_right("/Pages/Content/roomlist.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "belegte zimmer", Source = new Uri("/Pages/Content/roomlist.xaml#6", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "belegt hotel", Source = new Uri("/Pages/Content/roomlist.xaml#7", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "alle zimmer", Source = new Uri("/Pages/Content/roomlist.xaml#3", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "alle hotel", Source = new Uri("/Pages/Content/roomlist.xaml#4", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "alle", Source = new Uri("/Pages/Content/roomlist.xaml#8", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "inaktive zimmer", Source = new Uri("/Pages/Content/roomlist.xaml#5", UriKind.Relative) });
                SelSrc = new Uri("/Pages/Content/roomlist.xaml#3", UriKind.Relative);
            }
            
        }
    }
}
