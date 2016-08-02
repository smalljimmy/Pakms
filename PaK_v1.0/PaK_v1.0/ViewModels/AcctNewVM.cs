using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;

namespace PaK_v1._0.ViewModels
{

    public class AcctNewVM : VMBase
    {
        
        private PaKEntities _pak;
        private ObservableCollection<acct_status> _acctstates;
        private ObservableCollection<nations> _nations;
        private accounts _account;
        private nations _selected_nation;
        private int _selected_status;

        
        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private bool _duedo_visible;
        public bool Duedo_Visible
        {
            get { return _duedo_visible; }
            set
            {
                _duedo_visible = value;
                if (_duedo_visible == false)
                    Duedo_Checked = false;
                RaisePropertyChanged("Duedo_Visible");
            }
        }

        private bool _save_visible;
        public bool Save_Visible
        {
            get { return _save_visible; }
            set
            {
                _save_visible = value;
                RaisePropertyChanged("Save_Visible");
            }
        }

        private bool _duedo_checked;
        public bool Duedo_Checked
        {
            get { return _duedo_checked; }
            set
            {
                _duedo_checked = value;
                RaisePropertyChanged("Duedo_Checked");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        private System.Windows.Media.Brush _fgcolor;
        public System.Windows.Media.Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }

        public accounts Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new accounts();
                }

                return _account;
            }
            set
            {
                _account = value;
                RaisePropertyChanged("Account");
            }
        }


        public AcctNewVM()
        {
            _pak = new PaKEntities();
            _acctstates = new ObservableCollection<acct_status>(_pak.acct_status);
            _nations = new ObservableCollection<nations>(_pak.nations);
            AcctState = _acctstates.FirstOrDefault(x => x.ast_key.Equals("REGULAR_GUEST")).ast_id;
            _selected_nation = _nations.FirstOrDefault(x => x.iso_2.Equals("DE"));
            //Save_Visible = true;

            _commands = new CommandMap();
            _commands.AddCommand("save", (o) => save());
//            _commands.AddCommand("print", (o) => print());

        }

        //public void print()
        //{

        //}

        public void save()
        {
            int id_border = 999;

            var dei = Account as IDataErrorInfo;

            foreach (var property in dei.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(dei[property.Name]))
                {
                    Status = "Alle rot markierte Felder müssen ausgefüllt werden.";
                    FgColor = System.Windows.Media.Brushes.Crimson;
                    return;
                }
            }

            // act_id is not defined as an auto identity
            // staff member should have an id from 1...999
            // regular guest should have an id > 999
            // new accounts are active by default
            var highest = _pak.accounts.OrderByDescending(i => i.act_id).FirstOrDefault();
            
            if (AcctState == 901) // staff member
            {
                var last = _pak.accounts.Where(a => a.act_id < id_border).OrderByDescending(i => i.act_id).FirstOrDefault();
                if (last == null)
                {
                    if (highest == null) // there is no account yet
                    {
                        Account.act_id = 1;
                    }
                    else
                    {
                        Account.act_id = highest.act_id + 1;
                    }
                }
                else
                {
                    Account.act_id = last.act_id + 1;
                }
            }
            else
            {
                var last = _pak.accounts.Where(a => a.act_id > id_border).OrderByDescending(i => i.act_id).FirstOrDefault();
                if (last == null) // there is no account with an id > 999 yet.
                {
                    Account.act_id = 1000;
                }
                else
                {
                    Account.act_id = last.act_id + 1;
                }
            }

            Account.ast_id = AcctState;
            Account.act_active = true;  // active by default
            Account.tariff_id = 900; // 900 == no tariff
            Account.act_balance = 0;
            Account.room_id = _pak.rooms.SingleOrDefault(r => r.roomtype_id == 0).room_id;

            _pak.accounts.AddObject(Account);

            if (Account.ast_id == 1 || Account.ast_id == 2 || Account.ast_id == 3) // "REGULAR_GUEST"
            {
                pers_data pd = new pers_data();
                pd.act_id = Account.act_id;
                pd.pdt_duedo_tax = Duedo_Checked;
                _pak.pers_data.AddObject(pd);
            }
       
            _pak.SaveChanges();

            //Save_Visible = false;

            // todo: reset form
            // show message
            Status = "Konto wurde erfolgreich angelegt.";
            FgColor = System.Windows.Media.Brushes.DarkTurquoise;
            resetUI();


            // utilities.NavigationService.GetInstance().Navigate<AcctNewVM>(null);
        }

        private void resetUI()
        {
            Account = new accounts();
            AcctState = _acctstates.FirstOrDefault(x => x.ast_key.Equals("REGULAR_GUEST")).ast_id;
            _selected_nation = _nations.FirstOrDefault(x => x.iso_2.Equals("DE"));
        }


        public ObservableCollection<nations> Nations
        {
            get { return _nations; }

        }


        public ObservableCollection<acct_status> AcctStates
        {
            get
            {
                return _acctstates;
            }

        }

        public int AcctState
        {
            get { return _selected_status; }
            set
            {
                _selected_status = value;
                if (_selected_status == 1 || _selected_status == 2 || _selected_status == 3)
                    Duedo_Visible = true;
                else
                    Duedo_Visible = false;

                RaisePropertyChanged("AcctState");
            }
        }

        public nations Nation
        {
            get { return _selected_nation; }
            set
            {
                _selected_nation = value;
                //OnPropertyChanged("Nation");
                RaisePropertyChanged("Nation");
            }
        }

        /*
        public void ManageControls(bool OnOff)
        {
            for (int i = 0; i < App.Current.Windows.Count; i++)
            { Window w = App.Current.Windows[i]; if (w.Title == "Prospects") { (w as frmProspects).Enabler(OnOff); } }
        }
         * */

/*
        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (this._firstName != value)
                {
                    this._firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (this._lastName != value)
                {
                    this._lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Pseudonym
        {
            get { return _pseudonym; }
            set
            {
                if (this._pseudonym != value)
                {
                    this._pseudonym = value;
                    OnPropertyChanged("Pseudonym");
                }
            }
        }

        public string Passport
        {
            get { return this._passport; }
            set
            {
                if (this._passport != value)
                {
                    this._passport = value;
                    OnPropertyChanged("Passport");
                }
            }
        }

        public ObservableCollection<nations> Nations
        {
            get { return _nations; }

        }

        public nations Nation
        {
            get { return _selected_nation; }
            set
            {
                _selected_nation = value;
                OnPropertyChanged("Nation");
            }
        }



        public bool Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public bool Duedo
        {
            get { return _duedo; }
            set
            {
                if (_duedo != value)
                {
                    _duedo = value;
                    OnPropertyChanged("Dueso");
                }
            }
        }
       
        public string Birthday
        {
            get { return this._birthday; }
            set
            {
                if (this._birthday != value)
                {
                    this._birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public string Address
        {
            get { return this._address; }
            set
            {
                if (this._address != value)
                {
                    this._address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string Zip
        {
            get { return this._zip; }
            set
            {
                if (this._zip != value)
                {
                    this._zip = value;
                    OnPropertyChanged("Zip");
                }
            }
        }

        public string City
        {
            get { return this._city; }
            set
            {
                if (this._city != value)
                {
                    this._city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public ObservableCollection<acct_status> AcctStates
        {
            get
            {
                return _acctstates;
            }
        }

        public acct_status AcctState
        {
            get { return _selected_status; }
            set
            {
                _selected_status = value;
                OnPropertyChanged("AcctState");
            }
        }

        */

    }
}
