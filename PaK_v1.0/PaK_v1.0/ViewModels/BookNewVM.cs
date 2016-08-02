using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;

namespace PaK_v1._0.ViewModels
{
    class BookNewVM : VMBase
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


        private ObservableCollection<accounts> _accounts;
        public ObservableCollection<accounts> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
            }
        }

        private ICollectionView _accountsview;
        public ICollectionView accountsView
        {
            get { return _accountsview; }
            set
            {
                _accountsview = value;
                RaisePropertyChanged("accountsView");
            }
        }

        private accounts _SelectedAccount;
        public accounts SelectedAccount
        {
            get
            {
                return _SelectedAccount;
            }

            set
            {
                _SelectedAccount = value;
                if (_SelectedAccount != null)
                {
                    RaisePropertyChanged("SelectedAccount");
                    Status = "";
                    Amount = "";
                }
            }
        }

        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged("Amount");
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


        // combo boxes
        // product groups
        private ObservableCollection<prod_grp> _prdgrp;
        public ObservableCollection<prod_grp> PrdGrp
        {
            get { return _prdgrp; }
            set
            {
                _prdgrp = value;
                RaisePropertyChanged("PrdGrp");
            }
        }
        // selected product group
        private prod_grp _selectedProdGroup;
        public prod_grp SelectedProdGroup
        {
            get
            {
                return _selectedProdGroup;
            }

            set
            {
                _selectedProdGroup = value;
                this.Articles = new ObservableCollection<articles>(_selectedProdGroup.articles);
                SelectedArticle = Articles.First();
                RaisePropertyChanged("SelectedProdGroup");
                RaisePropertyChanged("SelectedArticle");
            }
        }
        // articles
        private ObservableCollection<articles> _articles;
        public ObservableCollection<articles> Articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
                RaisePropertyChanged("Articles");
            }
        }
        // selected article
        private articles _selectedArticle;
        public articles SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                _selectedArticle = value;
                refreshArticlePrice();
            }
        }

        // price categories
        private ObservableCollection<price_type> _pcats;
        public ObservableCollection<price_type> Pcats
        {
            get { return _pcats; }
            set
            {
                _pcats = value;
                RaisePropertyChanged("Pcats");
            }
        }
        // selected price category
        private int _priceTypeId;
        public int PriceTypeId
        {
            get { return _priceTypeId; }
            set
            {
                _priceTypeId = value;
                refreshArticlePrice();
            }
        }
        // number of selected article
        private List<int> _nums;
        public List<int> Nums
        {
            get { return _nums; }
            set
            {
                _nums = value;
                RaisePropertyChanged("Nums");
            }
        }
        // selected number
        private int _num;
        public int Num
        {
            get { return _num; }
            set
            {
                _num = value;
                RaisePropertyChanged("Num");
                refreshArticlePrice();
            }
        }


        private decimal _unitprice;
        public decimal unitprice
        {
            get { return _unitprice; }
            set
            {
                _unitprice = value;
                RaisePropertyChanged("unitprice");
            }
        }

        private decimal _total;
        public decimal total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("total");
            }
        }


        public BookNewVM()
        {
            // init
            _pak = new PaKEntities();
            ST = "Suchtext eingeben";
            
            // populate account list
            Accounts = new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true).OrderBy(o => o.act_pseudonym));
            if (Accounts.Count > 0)
            {
                SelectedAccount = Accounts.First();
            }
            accountsView = CollectionViewSource.GetDefaultView(Accounts);

            //populate combobox
            PrdGrp = new ObservableCollection<prod_grp>(_pak.prod_grp);
            SelectedProdGroup = PrdGrp.OrderBy(g => g.pgr_name).FirstOrDefault();
            SelectedArticle = Articles.OrderBy(a => a.art_id).FirstOrDefault();
            Nums = new List<int>(Enumerable.Range(1, 10).ToList());
            Pcats = new ObservableCollection<price_type>(_pak.price_type);

            //set default selected element
            PriceTypeId = 1;
            Num = 1;

            _commands = new CommandMap();
            _commands.AddCommand("save", x => save());
            _searchCommand = new DelegateCommand(search, null);
        }


        private void refreshArticlePrice()
        {
            c_art_pricetype apt = null;
            if(SelectedArticle != null)
                apt = _pak.c_art_pricetype.SingleOrDefault(x => x.art_id == SelectedArticle.art_id && x.ptp_id == PriceTypeId);
            unitprice = (apt == null ? 0 : apt.apt_price);
            total = unitprice * Num;
        }

        void save()
        {

            try
            {
                bookings booking = new bookings
                {
                    bkg_date = DateTime.Now,
                    act_id = SelectedAccount.act_id,
                    btp_id = 1, // debit
                    bkg_amount = (-1) * total, //debit is always negativ
                    usr_id = ApplicationState.GetValue<int>("userid"),
                    room_id = null, //SelectedAccount.room_id, 
                    art_id = (SelectedArticle == null ? (int?)null : SelectedArticle.art_id),
                    tariff_id = null, //(_selectedTarif == null ? (int?)null : _selectedTarif.tariff_id)
                    bkg_comment = "Manuelle Artikelbuchung"
                };

                SelectedAccount.act_balance += (-1) * total;
                _pak.bookings.AddObject(booking);
                _pak.SaveChanges();
                //_pak.Refresh(System.Data.Objects.RefreshMode.StoreWins, booking);

                Status = "Buchung wurde erfolgreich durchgeführt.";
                FgColor = Brushes.DeepSkyBlue;
            }
            catch (Exception ex)
            {
                Status = "Buchung konnte nicht durchgeführt werden: " + ex.Message;
                FgColor = Brushes.Crimson;
                return;
            }

            // reset form
            SelectedProdGroup = PrdGrp.First();
            SelectedArticle = Articles.First();
            Num = 1;
            refreshArticlePrice();
        }

        public void search(object parameter)
        {

            KeyEventArgs e = parameter as KeyEventArgs;
            TextBox searchBox = (TextBox)e.OriginalSource;
            string txt = searchBox.Text.ToUpper();

            if (Accounts.Count > 0)
            {

                var _faccts = Accounts.Where(a => a.act_lastname.ToUpper().Contains(txt) || a.act_firstname.ToUpper().Contains(txt) || a.act_pseudonym.ToUpper().Contains(txt) || a.rooms.room_number.ToUpper().Contains(txt));

                ObservableCollection<accounts> AcctFiltered = new ObservableCollection<accounts>(_faccts);

                accountsView = CollectionViewSource.GetDefaultView(AcctFiltered);

                if (AcctFiltered.Count > 0)
                {
                    SelectedAccount = AcctFiltered.First();
                }
                else
                {
                    SelectedAccount = null;
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
