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
    class SettingsVM : VMBase
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


        public SettingsVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }


        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/Content/app_settings.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "Einstellungen", Source = new Uri("/Pages/Content/app_settings.xaml", UriKind.Relative) });
                SelSrc = new Uri("/Pages/Content/app_settings.xaml", UriKind.Relative);
            }
            MenuLinks.Add(new Link { DisplayName = "erscheinung", Source = new Uri("/Pages/Content/SettingsAppearance.xaml", UriKind.Relative) });
            MenuLinks.Add(new Link { DisplayName = "info", Source = new Uri("/Pages/Content/About.xaml", UriKind.Relative) });
            if (!rights.has_right("/Pages/Content/app_settings.xaml"))
            {
                SelSrc = new Uri("/Pages/Content/SettingsAppearance.xaml", UriKind.Relative);
            }
        }
    }
}
