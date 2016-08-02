using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using System.ComponentModel;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using PaK_v1._0.Interfaces;

namespace PaK_v1._0.ViewModels
{
    class UserListVM : VMBase
    {
        private PaKEntities _pak = new PaKEntities();
        private ObservableCollection<users> _users { get; set; }
        private readonly IAuthenticationService _authenticationService;

        private users _user;
        public users lUser
        {
            get
            {
                if (_user == null)
                {
                    _user = new users();
                }

                return _user;
            }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        private users _selectedUser;
        public users selectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;

                if (_selectedUser != null)
                {
                    lUser = new users();
                    lUser = _selectedUser;
                    Status = "";
                }
                RaisePropertyChanged("lUser");
                RaisePropertyChanged("Status");
            }
        }

        public ICollectionView userView { get; set; }

        private ObservableCollection<roles> _roles;
        public ObservableCollection<roles> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                RaisePropertyChanged("Roles");
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

        private readonly DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand { get { return _saveCommand; } }


        // constructor
        public UserListVM() : this(1) { }

        public UserListVM(int f)
        {
            //_users = new ObservableCollection<users>(_pak.users.OrderBy(u => u.usr_name).ToList());
            _users = getusers(f);
            if( _users.Count > 0 ) 
                selectedUser = _users.First();
            userView = CollectionViewSource.GetDefaultView(_users);
            Roles = new ObservableCollection<roles>(_pak.roles);
            _authenticationService = new AuthenticationService();
            _saveCommand = new DelegateCommand(save, null);
        }

        private ObservableCollection<users> getusers(int i)
        {
            switch (i)
            {
                case 1:
                    return new ObservableCollection<users>(_pak.users.Where(u => u.role_id > 1 && u.role_id < 900).OrderBy(o => o.usr_name).ToList());
                case 2:
                    return new ObservableCollection<users>(_pak.users.Where(u => u.role_id == 1).OrderBy(o => o.usr_name).ToList());
                default:
                    return new ObservableCollection<users>(_pak.users.Where(u => u.role_id < 900).OrderBy(o => o.usr_name).ToList());
            }
        }

        public void save(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            Status = "";

            if (lUser == null || lUser.usr_id == 0)
            {
                Status = "Es wurde kein Benutzer ausgewählt.";
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            if (clearTextPassword != "" && clearTextPassword.Length < 3)
            {
                Status = "Das Passwort muss mindestens drei Zeichen haben. Benutzer wurde nicht gespeichert.";
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            if (lUser.usr_firstname == "" || lUser.usr_lastname == "")
            {
                Status = "Vor- und Nachname dürfen nicht leer sein. Benutzer wurde nicht gespeichert.";
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            if (clearTextPassword != "")
                lUser.usr_passwd = _authenticationService.CalculateHash(clearTextPassword, lUser.usr_name);

            try
            {
                //_pak.users.AddObject(lUser);
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                var sqlex = ex.InnerException as SqlException;
                if (sqlex != null && sqlex.Errors.OfType<SqlError>().Any(se => se.Number == 2627))
                {
                    Status = "Der Benutzername '" + lUser.usr_name + "' existiert bereits. Bitte einen anderen Benutzernamen wählen.";
                }
                else
                {
                    Status = sqlex.Message;
                }
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            Status = "Benutzer erfolgreich gespeichert.";
            FgColor = System.Windows.Media.Brushes.DarkTurquoise;

            return;
        }


    }
}
