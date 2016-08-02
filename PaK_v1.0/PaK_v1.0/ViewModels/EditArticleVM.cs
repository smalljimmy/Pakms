using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;

namespace PaK_v1._0.ViewModels
{
    class EditArticleVM : VMBase
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

        private string _article;
        public string Article 
        {
            get { return _article; }
            set
            {
                _article = value;
                RaisePropertyChanged("Article");
            }
        }

        private int? _prodgrpid;
        public int? ProdGrpId 
        {
            get { return _prodgrpid; }
            set
            {
                _prodgrpid = value;
                RaisePropertyChanged("ProdGrpId");
            }
        }

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

        private string _st;
        public string ST
        {
            get { return _st; }
            set
            {
                _st = value;
                RaisePropertyChanged("ST");
            }
        }

        private readonly DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand { get { return _searchCommand; } }


        private ObservableCollection<articles> _articles;
        public ObservableCollection<articles> Articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
            }
        }

        private ICollectionView _articlesview;
        public ICollectionView articlesView
        {
            get { return _articlesview; }
            set
            {
                _articlesview = value;
                RaisePropertyChanged("articlesview");
            }
        }

        private articles _selectedarticle;
        public articles SelectedArticle
        {
            get
            {
                return _selectedarticle;
            }

            set
            {
                _selectedarticle = value;
                if (_selectedarticle != null)
                {
                    Article = _selectedarticle.art_name;
                    ProdGrpId = _selectedarticle.pgr_id;

                    RaisePropertyChanged("SelectedArticle");
                    Status = "";

                    List<PriceTypeItem> pil = new List<PriceTypeItem>();
                    var _items = from item in _pak.price_type select item;
                    string pr = "";
                    foreach (price_type p in _items)
                    {
                        pr = _pak.c_art_pricetype.Single(x => x.ptp_id == p.ptp_id && x.art_id == _selectedarticle.art_id).apt_price.ToString();
                        pil.Add(new PriceTypeItem()
                                  {
                                      PriceType = p,
                                      Price = pr
                                  });
                    }
                    PriceTypeSrc = new ObservableCollection<PriceTypeItem>(pil);
                }
            }
        }


        public EditArticleVM()
        {
            _pak = new PaKEntities();
            ST = "Suchtext eingeben";
            Articles = new ObservableCollection<articles>(_pak.articles.OrderBy(a => a.prod_grp.pgr_name).ThenBy(b => b.art_name));
            if (Articles.Count > 0)
            {
                SelectedArticle = Articles.First();
            }
            articlesView = CollectionViewSource.GetDefaultView(Articles);
            PrdGrpSrc = new ObservableCollection<prod_grp>(_pak.prod_grp);
            _commands = new CommandMap();
            _commands.AddCommand("save", (o) => save());
            _commands.AddCommand("emptybox", (o) => emptybox());
            _searchCommand = new DelegateCommand(search, null);

        }

        public void save()
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

            if (article_invalid)
            {
                FgColor = Brushes.Crimson;
                Status = "Der Artikel '" + Article + "' existiert bereits in der gewählten Produktgruppe.";
                return;
            }

            try
            {
                var marticle = _pak.articles.Single(a => a.art_id == SelectedArticle.art_id);
                marticle.art_name = Article;
                marticle.pgr_id = Convert.ToInt32(ProdGrpId);

                foreach (PriceTypeItem item in PriceTypeSrc)
                {
                    if (!Regex.IsMatch(item.Price, @"^[0-9]{1,6}([.,][0-9]{1,2})?$"))
                    {
                        FgColor = Brushes.Crimson;
                        Status = "Der Betrag für '" + item.PriceType.ptp_name + "' enthält einen ungültigen Wert.";
                        return;
                    }

                    c_art_pricetype entry = _pak.c_art_pricetype.Single(p => p.art_id == SelectedArticle.art_id && p.ptp_id == item.PriceType.ptp_id);
                    entry.apt_price = Convert.ToDecimal(item.Price);
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

        public void search(object parameter)
        {

            KeyEventArgs e = parameter as KeyEventArgs;
            TextBox searchBox = (TextBox)e.OriginalSource;
            string txt = searchBox.Text.ToUpper();

            if (Articles.Count > 0)
            {

                var _farts = Articles.Where(a => a.art_name.ToUpper().Contains(txt) || a.prod_grp.pgr_name.ToUpper().Contains(txt));

                ObservableCollection<articles> ArtFiltered = new ObservableCollection<articles>(_farts);

                articlesView = CollectionViewSource.GetDefaultView(ArtFiltered);

                if (ArtFiltered.Count > 0)
                {
                    SelectedArticle = ArtFiltered.First();
                }
                else
                {
                    SelectedArticle = null;
                }

            }

            return;
        }

        public void emptybox()
        {
            if (ST.ToUpper().Contains("SUCHTEXT"))
                ST = "";
        }

    }
}
