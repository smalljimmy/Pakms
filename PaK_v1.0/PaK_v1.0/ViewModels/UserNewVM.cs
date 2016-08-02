using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using PaK_v1._0.Interfaces;

namespace PaK_v1._0.ViewModels
{

    class UserNewVM : VMBase
    {

        private PaKEntities _pak = new PaKEntities();
        private readonly IAuthenticationService _authenticationService; 

        private users _user;
        public users User
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

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; 
                RaisePropertyChanged("Status"); }
        }

        private System.Windows.Media.Brush _fgcolor;
        public System.Windows.Media.Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }

        public UserNewVM()
        {
            Roles = new ObservableCollection<roles>(_pak.roles);
            User.role_id = 1;
            _authenticationService = new AuthenticationService();
            _commands = new CommandMap();
            _commands.AddCommand("save", (o) => save());
        }

        public void save()
        {
            //var pwdboxes = parameter as List<object>;
            var user = User as IDataErrorInfo;

            foreach (var property in user.GetType().GetProperties())
            {
                if (!string.IsNullOrEmpty(user[property.Name]))
                {
                    Status = "Alle rot markierte Felder müssen ausgefüllt werden.";
                    FgColor = System.Windows.Media.Brushes.Crimson;
                    return;
                }
            }

            User.usr_passwd = _authenticationService.CalculateHash(User.usr_passwd, User.usr_name);

            try
            {
                _pak.users.AddObject(User);
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                var sqlex = ex.InnerException as SqlException;
                if(sqlex != null && sqlex.Errors.OfType<SqlError>().Any(se => se.Number == 2627))
                {
                    Status = "Der Benutzername " + User.usr_name + " existiert bereits. Bitte einen anderen Benutzernamen wählen.";
                }
                else
                {
                    Status = sqlex.Message;
                }
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            Status = "Benutzer wurde erfolgreich angelegt.";
            FgColor = System.Windows.Media.Brushes.DarkTurquoise;
            // reset the UI
            resetUI();
        }

        private void resetUI()
        {
            User = new users();
            User.role_id = 1;
        }

    }

}
