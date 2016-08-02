using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;

namespace PaK_v1._0.ViewModels
{
    class CreateArticleVM : VMBase, IDataErrorInfo
    {
        private PaKEntities _pak = new PaKEntities();

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private ObservableCollection<prod_grp> _prdgrpsrc;
        public ObservableCollection<prod_grp> PrdGrpSrc
        {
            get { return _prdgrpsrc; }
            set
            {
                _prdgrpsrc = value;
                RaisePropertyChanged("PrdGrpSrc");
            }
        }

        private ObservableCollection<PriceTypeItem> _pricetypesrc;
        public ObservableCollection<PriceTypeItem> PriceTypeSrc
        {
            get { return _pricetypesrc; }
            set
            {
                _pricetypesrc = value;
                RaisePropertyChanged("PriceTypeSrc");
            }
        }

        public string Article { get; set; }
        public int? ProdGrpId { get; set; }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            { _status = value; RaisePropertyChanged("Status"); }
        }

        private Brush _fgcolor;
        public Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }


        public CreateArticleVM()
        {
            PrdGrpSrc = new ObservableCollection<prod_grp>(_pak.prod_grp);
            Status = "";
            var _items = (from item in _pak.price_type
                          select new PriceTypeItem()
                          {
                              PriceType = item,
                              Price = "0.00"
                          }).ToList();

            PriceTypeSrc = new ObservableCollection<PriceTypeItem>(_items);

            _commands = new CommandMap();
            _commands.AddCommand("add", x => AddArticle());

        }


        public void AddArticle()
        {
            // validation
            if (Article == null || Article == "")
            {
                FgColor = Brushes.Crimson;
                Status = "Der Artikelname muss angegeben werden.";
                return;
            }

            if (ProdGrpId == null || ProdGrpId < 1)
            {
                FgColor = Brushes.Crimson;
                Status = "Es muss eine Produktgruppe ausgewählt werden.";
                return;
            }

            var article_invalid = _pak.articles.Any(a => a.art_name == Article && a.pgr_id == ProdGrpId);

            if(article_invalid)
            {
                FgColor = Brushes.Crimson;
                Status = "Der Artikel '" + Article + "' existiert bereits in der gewählten Produktgruppe.";
                return;
            }

            try
            {
                var marticle = new articles();
                marticle.art_name = Article;
                marticle.pgr_id = Convert.ToInt32(ProdGrpId);
                _pak.articles.AddObject(marticle);
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status = "Artikel konnte nicht gespeichert werden: " + ex.Message;
                return;
            }

            try
            {
                // need the id
                var art_id = _pak.articles.FirstOrDefault(a => a.art_name == Article && a.pgr_id == ProdGrpId).art_id;

                foreach (PriceTypeItem item in PriceTypeSrc)
                {
                    if (!Regex.IsMatch(item.Price, @"^[0-9]{1,6}([.,][0-9]{1,2})?$"))
                    {
                        FgColor = Brushes.Crimson;
                        Status = "Der Betrag für '" + item.PriceType.ptp_name + "' enthält einen ungültigen Wert.";
                        // remove the article again
                        _pak.articles.DeleteObject(_pak.articles.FirstOrDefault(a => a.art_id == art_id));
                        _pak.SaveChanges();
                        return;
                    }

                    c_art_pricetype entry = new c_art_pricetype();
                    entry.art_id = art_id;
                    entry.ptp_id = item.PriceType.ptp_id;
                    entry.apt_price = Convert.ToDecimal(item.Price);
                    _pak.c_art_pricetype.AddObject(entry);
                }
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status = "Artikel konnte nicht gespeichert werden: " + ex.Message;
                return;
            }

            FgColor = Brushes.DeepSkyBlue;
            Status = "Artikel erfolgreich gespeichert.";
        }


        public string Error
        {
            get { return null; }
        }

        public string this[string fieldName]
        {
            get
            {
                if (fieldName == "Article")
                {
                    return string.IsNullOrEmpty(Article) ? "Angabe erforderlich" : null;
                }
                if (fieldName == "ProdGrpId")
                {
                    return !ProdGrpId.HasValue ? "Angabe erforderlich" : null;
                }

                return null;
            }
        }

    }
}
