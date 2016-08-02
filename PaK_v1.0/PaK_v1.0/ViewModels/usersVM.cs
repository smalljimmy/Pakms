using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using FirstFloor.ModernUI.Presentation;

namespace PaK_v1._0.ViewModels
{


    class usersVM : VMBase
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
        

        public usersVM()
        {
            //ModernTab mt = new ModernTab();
            MenuLinks = new LinkCollection();
            CreateMenu();

        }

        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/Content/userlist.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "Alle Benutzer", Source = new Uri("/Pages/Content/userlist.xaml#1", UriKind.Relative) });
            }

            if (rights.has_right("/Pages/Content/newuser.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "Neuer Benutzer", Source = new Uri("/Pages/Content/newuser.xaml", UriKind.Relative) });
            }

            MenuLinks.Add(new Link { DisplayName = "passwort ändern", Source = new Uri("/Pages/Content/chpwd.xaml", UriKind.Relative) });

            if (rights.has_right("/Pages/Content/userlist.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "Deaktivierte Benutzer", Source = new Uri("/Pages/Content/userlist.xaml#2", UriKind.Relative) });
                SelSrc = new Uri("/Pages/Content/userlist.xaml#1", UriKind.Relative);
            }
            else
            {
                SelSrc = new Uri("/Pages/Content/chpwd.xaml", UriKind.Relative);
            }


            //if (Thread.CurrentPrincipal.IsInRole("ADMIN"))
            //{
            //    var l1 = new Link { DisplayName = "Alle Benutzer", Source = new Uri("/Pages/Content/userlist.xaml#1", UriKind.Relative) };
            //    MenuLinks.Add(l1);
            //    var l2 = new Link { DisplayName = "Neuer Benutzer", Source = new Uri("/Pages/Content/newuser.xaml", UriKind.Relative) };
            //    MenuLinks.Add(l2);
            //}
            //var l3 = new Link { DisplayName = "passwort ändern", Source = new Uri("/Pages/Content/chpwd.xaml", UriKind.Relative) };
            //MenuLinks.Add(l3);
            //if (Thread.CurrentPrincipal.IsInRole("ADMIN"))
            //{
            //    var l4 = new Link { DisplayName = "Inaktive Benutzer", Source = new Uri("/Pages/Content/userlist.xaml#2", UriKind.Relative) };
            //    MenuLinks.Add(l4);
            //    SelSrc = new Uri("/Pages/Content/userlist.xaml#1", UriKind.Relative);
            //}
            //else
            //{
            //    SelSrc = new Uri("/Pages/Content/chpwd.xaml", UriKind.Relative);
            //}

        }
        
    }
}
