using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.utilities;
using PaK_v1._0.Interfaces;
using PaK_v1._0.Models;
using System.Threading;
using System.Windows.Controls;

namespace PaK_v1._0.ViewModels
{
    class ChPwdVM : VMBase
    {
        private PaKEntities _pak = new PaKEntities();
        private readonly IAuthenticationService _authenticationService;

        private users _user;
        public users User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("Status"); }
        }

        private System.Windows.Media.Brush _fgcolor;
        public System.Windows.Media.Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }

        #region Commands
        private readonly DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand { get { return _saveCommand; } }
        #endregion

        public ChPwdVM()
        {
            _authenticationService = new AuthenticationService();
            _saveCommand = new DelegateCommand(save, null);
        }

        public void save(object parameter)
        {
            var pwdboxes = parameter as List<object>;

            PasswordBox p0 = new PasswordBox();
            p0 = (PasswordBox)pwdboxes[0];
            PasswordBox p1 = new PasswordBox();
            p1 = (PasswordBox)pwdboxes[1];
            PasswordBox p2 = new PasswordBox();
            p2 = (PasswordBox)pwdboxes[2];

            User = _pak.users.Single(u => u.usr_name == Thread.CurrentPrincipal.Identity.Name);

            if (User.usr_passwd != _authenticationService.CalculateHash(p0.Password, User.usr_name))
            {
                Status = "Das alte Passwort war nicht korrekt. Passwort wurde nicht geändert.";
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            if (p1.Password != p2.Password)
            {
                Status = "Die wiederholte Eingabe des neuen Passworts stimmt nicht überein. Passwort wurde nicht geändert.";
                FgColor = System.Windows.Media.Brushes.Crimson;
                return;
            }

            User.usr_passwd = _authenticationService.CalculateHash(p1.Password, User.usr_name);
            try
            {
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                Status = "Passwort konnte nicht geändert werden: " + ex.Message;
                FgColor = System.Windows.Media.Brushes.Crimson;
            }
            
            Status = "Passwort wurde erfolgreich geändert.";
            FgColor = System.Windows.Media.Brushes.DarkTurquoise;
        }
    }
}
