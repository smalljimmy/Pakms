using System;
using System.ComponentModel;
using System.Threading;
using System.Linq;
using System.Windows.Controls;
using System.Security;
using System.Windows;
using System.Data.SqlClient;
using PaK_v1._0.Interfaces;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using System.Windows.Media;

namespace PaK_v1._0.ViewModels
{

    public interface IViewModel { }

    public class loginVM : IViewModel, INotifyPropertyChanged
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly DelegateCommand _loginCommand;
        //private readonly DelegateCommand _logoutCommand;
        //private readonly DelegateCommand _showViewCommand;
        //private readonly DelegateCommand _closeViewCommand;

        private string _username;
        private string _status;
        //private bool _isopen;

        public loginVM(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new DelegateCommand(Login, null);
            //_logoutCommand = new DelegateCommand(Logout, CanLogout);

        }

        #region Properties
        public string Username
        {
            get { return _username;}
            set { _username = value; NotifyPropertyChanged("Username"); }
        }
 
        public string AuthenticatedUser 
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                            Thread.CurrentPrincipal.Identity.Name,
                            Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                                : "You are NOT a member of the administrators group.");
 
                return "Not authenticated!";
            }
        }
 
        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }


        #endregion
 
        #region Commands
        public DelegateCommand LoginCommand { get { return _loginCommand; } }
        //public DelegateCommand LogoutCommand { get { return _logoutCommand; } }
        //public DelegateCommand ShowViewCommand { get { return _showViewCommand; } }
        //public DelegateCommand CloseViewCommand { get { return _closeViewCommand; } }
        #endregion
 
        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);
 
                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
 
                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Role, user.Theme, user.Fontsize, user.Color);

                //load theme
                ThemeManager.LoadTheme(customPrincipal.Identity);

                //Update UI
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;
                //_showViewCommand.Execute(parameter);

                ShowAction = new Action(() => ShowView());

                //store userid
                ApplicationState.SetValue("userid", user.UserId);


                ShowAction();
                CloseAction();               

            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                var sqlex = ex.InnerException as SqlException;
                if (sqlex != null && sqlex.Errors.OfType<SqlError>().Any(se => se.Number == 53))
                {
                    Status = string.Format("ERROR: Failed to connect to data base. {0}", ex.Message);
                }
                else if (sqlex != null)
                {
                    Status = string.Format("ERROR: Login failed to to an SQL exception: {0}", ex.Message);
                }
                else
                {
                    Status = string.Format("ERROR: Login failed due to an unhandled exception: {0}", ex.Message);
                }
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        /*
        private void Logout(object parameter)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                NotifyPropertyChanged("AuthenticatedUser");
                NotifyPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                Status = string.Empty;
            }
        }*/

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        public Action CloseAction { get; set; }

        public Action ShowAction { get; set; }

        private void ShowView()
        {
            try
            {

                ModernWindow view = new MainWindow();

                view.Show();
                
            }
            catch (SecurityException)
            {
                Status = "You are not authorized!";
            }
            catch (Exception)
            {
                Status = "You are not authorized!";
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }



}
