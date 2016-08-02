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
using PaK_v1._0.Models;
using PaK_v1._0.utilities;


namespace PaK_v1._0.ViewModels
{
    class CashBookVM : VMBase
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

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                RaisePropertyChanged("Comment");
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


        #region constructor
        public CashBookVM()
        {
            _pak = new PaKEntities();
            ST = "Suchtext eingeben";
            Accounts = new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true).OrderBy(o => o.act_pseudonym));
            if (Accounts.Count > 0)
            {
                SelectedAccount = Accounts.First();
            }
            accountsView = CollectionViewSource.GetDefaultView(Accounts);

            _commands = new CommandMap();
            _commands.AddCommand("save", (o) => save());
            _commands.AddCommand("emptybox", (o) => emptybox());
            _searchCommand = new DelegateCommand(search, null);

        }
        #endregion

        public void save()
        {

            if (!Regex.IsMatch(Amount, @"^[-]?[0-9]{1,6}([.,][0-9]{1,2})?$"))
            {
                FgColor = Brushes.Crimson;
                Status = "Der Betrag enthält einen ungültigen Wert. Einzahlung wurde nicht gespeichert.";
                return;
            }

            var amount = Convert.ToDecimal(Amount.Replace(',','.'));

            if(amount == 0)
            {
                FgColor = Brushes.Crimson;
                Status = "Der Betrag darf nicht 0 sein. Einzahlung wurde nicht gespeichert.";
                return;
            }

            if((Comment == null || Comment.Trim() == "") && amount < 0)
            {
                FgColor = Brushes.Crimson;
                Status = "Bei negativ Buchungen muss ein Kommentar angegeben werden. Buchung wurde nicht gespeichert.";
                return;
            }

            if (amount > 0 && (Comment == null || Comment.Trim() == ""))
                Comment = "Bareinzahlung"; // default

            try
            {
                bookings booking = new bookings
                {
                    bkg_date = DateTime.Now,
                    act_id = SelectedAccount.act_id,
                    btp_id = 2, // cash booking
                    bkg_amount = amount, 
                    usr_id = ApplicationState.GetValue<int>("userid"),
                    room_id = (SelectedAccount.room_id == null ? (int?)null : SelectedAccount.room_id),
                    art_id = (int?)null,
                    tariff_id = (int?)null,
                    bkg_comment = Comment //(amount > 0 ? "Bareinzahlung" : "Bareinzahlung Korrektur")
                };
                _pak.bookings.AddObject(booking);
                SelectedAccount.act_balance = SelectedAccount.act_balance + amount;

                // alternative
                //var bsum = _pak.bookings.Where(a => a.act_id == SelectedAccount.act_id).GroupBy(b => b.act_id).Select(s => new { value = s.Sum(x => x.bkg_amount), id = s.Key });      
                //SelectedAccount.act_balance

                _pak.SaveChanges();
                FgColor = Brushes.DeepSkyBlue;
                Comment = "";
                Amount = "";
                Status = "Einzahlung erfolgreich gespeichert.";
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status = "Fehler beim Buchen der Einzahlung: " + ex.Message;
            }
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
