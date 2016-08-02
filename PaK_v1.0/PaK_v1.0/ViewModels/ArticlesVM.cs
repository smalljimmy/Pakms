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
    class ArticlesVM : VMBase
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

        public ArticlesVM()
        {
            MenuLinks = new LinkCollection();
            CreateMenu();
        }

        private void CreateMenu()
        {
            MenuLinks.Clear();

            if (rights.has_right("/Pages/articles.xaml"))
            {
                MenuLinks.Add(new Link { DisplayName = "artikel erfassen", Source = new Uri("/Pages/Content/create_article.xaml", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "artikel editieren", Source = new Uri("/Pages/Content/edit_article.xaml", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "produktgruppe erfassen", Source = new Uri("/Pages/Content/create_prdgrp.xaml", UriKind.Relative) });
                MenuLinks.Add(new Link { DisplayName = "produktgruppe editieren", Source = new Uri("/Pages/Content/edit_prdgrp.xaml", UriKind.Relative) });
                SelSrc = new Uri("/Pages/Content/edit_article.xaml", UriKind.Relative);
            }
        }


    }
}
