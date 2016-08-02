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
    class workrepVM : VMBase
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


        public workrepVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }


        private void CreateMenu()
        {
            MenuLinks.Clear();

            //if (rights.has_right("/Pages/Content/room_occupancy.xaml"))
            //{
            MenuLinks.Add(new Link { DisplayName = "zimmerbelegung", Source = new Uri("/Pages/Content/room_occupancy.xaml", UriKind.Relative) });
            
            //}

            if (rights.has_right("/Pages/Content/duedotax.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "düsseldorfer tax", Source = new Uri("/Pages/Content/duedotax.xaml#1", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "düsseldorfer tax alle", Source = new Uri("/Pages/Content/duedotax.xaml#2", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "vergnügungssteuer", Source = new Uri("/Pages/Content/duedotax.xaml#3", UriKind.Relative) });
            }

            if (rights.has_right("/Pages/Content/ppoverview.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "mieterübersicht PP", Source = new Uri("/Pages/Content/ppoverview.xaml", UriKind.Relative) });
            }

            if (rights.has_right("/Pages/Content/blocklist.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "blockliste", Source = new Uri("/Pages/Content/blocklist.xaml", UriKind.Relative) });
            }

            SelSrc = new Uri("/Pages/Content/room_occupancy.xaml", UriKind.Relative);
        }
    }
}
