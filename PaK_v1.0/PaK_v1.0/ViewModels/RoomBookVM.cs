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
    class RoomBookVM : VMBase
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

        private readonly DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand { get { return _searchCommand; } }

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
                    resetboxes();
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
        // rooms
        private ObservableCollection<rooms> _rooms;
        public ObservableCollection<rooms> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                RaisePropertyChanged("Rooms");
            }
        }

        // selected room
        private rooms _selectedroom;
        public rooms SelectedRoom
        {
            get
            {
                return _selectedroom;
            }

            set
            {
                _selectedroom = value;
                RaisePropertyChanged("SelectedRoom");
            }
        }
        // tariffs
        private ObservableCollection<rental_tariffs> _tariffs;
        public ObservableCollection<rental_tariffs> Tariffs
        {
            get { return _tariffs; }
            set
            {
                _tariffs = value;
                RaisePropertyChanged("Tariffs");
            }
        }
        // selected tariff
        private rental_tariffs _selectedtariff;
        public rental_tariffs SelectedTariff
        {
            get { return _selectedtariff; }
            set
            {
                _selectedtariff = value;
                RaisePropertyChanged("SelectedTariff");
                refreshPrice();
            }
        }

        // nights source
        private List<int> _nights;
        public List<int> Nights
        {
            get { return _nights; }
            set
            {
                _nights = value;
                RaisePropertyChanged("Nights");
            }
        }
        //selected nights
        private int _selectednight;
        public int SelectedNight
        {
            get { return _selectednight; }
            set
            {
                _selectednight = value;
                RaisePropertyChanged("SelectedNight");
                refreshPrice();
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



        public RoomBookVM()
        {
            _pak = new PaKEntities();
            ST = "Suchtext eingeben";
            // populate account list
            Accounts = new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true).OrderBy(o => o.act_pseudonym));
            ////populate combobox
            Rooms = new ObservableCollection<rooms>(_pak.rooms.OrderBy(r => r.room_number));
            //SelectedRoom = Rooms.First();
            Tariffs = new ObservableCollection<rental_tariffs>(_pak.rental_tariffs.OrderBy(t => t.tar_order));
            //SelectedTariff = Tariffs.First(t => t.tariff_id == 900);
            Nights = new List<int>(Enumerable.Range(1, 10).ToList());
            //SelectedNight = 1;
            if (Accounts.Count > 0)
            {
                SelectedAccount = Accounts.First();
            }
            accountsView = CollectionViewSource.GetDefaultView(Accounts);

            //resetboxes();
            Status = "";
            _commands = new CommandMap();
            _commands.AddCommand("save", x => save());
            _searchCommand = new DelegateCommand(search, null);
        }

        private void resetboxes()
        {
            //Rooms = new ObservableCollection<rooms>(_pak.rooms.OrderBy(r => r.room_number));
            SelectedRoom = Rooms.First(r => r.room_types.roomtype_id == 0);
//            Tariffs = new ObservableCollection<rental_tariffs>(_pak.rental_tariffs.OrderBy(t => t.tar_order));
            SelectedTariff = Tariffs.First(t => t.tariff_id == 900);
//            Nights = new List<int>(Enumerable.Range(1, 10).ToList());
            SelectedNight = 1;
        }

        private void refreshPrice()
        {
            total = SelectedNight * SelectedTariff.tar_amount;
        }



        void save()
        {

            // validation?

            try
            {
                bookings booking = new bookings
                {
                    bkg_date = DateTime.Now,
                    act_id = SelectedAccount.act_id,
                    btp_id = 1, //debit
                    bkg_amount = (-1) * total, // always negativ
                    usr_id = ApplicationState.GetValue<int>("userid"),
                    room_id = SelectedRoom.room_id,
                    art_id = null,
                    tariff_id = (SelectedTariff == null ? (int?)null : SelectedTariff.tariff_id),
                    bkg_comment = "Manuelle Zimmerbuchung"
                };

                _pak.bookings.AddObject(booking);
                SelectedAccount.act_balance += (-1) * total;
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
            SelectedRoom = Rooms.First();
            SelectedTariff = Tariffs.First(t => t.tariff_id == 900);
            SelectedNight = 1;
            refreshPrice();
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
