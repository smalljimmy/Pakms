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
    class PersonVM : VMBase
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


        public PersonVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }


        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/Content/pers_list.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "im haus", Source = new Uri("/Pages/Content/pers_list.xaml#1", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "hotel", Source = new Uri("/Pages/Content/pers_list.xaml#2", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "abwesend", Source = new Uri("/Pages/Content/pers_list.xaml#3", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "alle", Source = new Uri("/Pages/Content/pers_list.xaml#4", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "block", Source = new Uri("/Pages/Content/pers_list.xaml#5", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "inaktive", Source = new Uri("/Pages/Content/pers_list.xaml#6", UriKind.Relative) });
            }
            if (rights.has_right("/Pages/Content/new_acct.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "neues konto", Source = new Uri("/Pages/Content/new_acct.xaml", UriKind.Relative) });
            }

            if (rights.has_right("/Pages/Content/pers_list.xaml"))
            {
                SelSrc = new Uri("/Pages/Content/pers_list.xaml#1", UriKind.Relative);
            }
        }
    }
}
