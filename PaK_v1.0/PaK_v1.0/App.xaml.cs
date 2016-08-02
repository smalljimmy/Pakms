using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PaK_v1._0.ViewModels;
using PaK_v1._0.Interfaces;
using PaK_v1._0.Models;
using FirstFloor.ModernUI.Windows.Controls;
using System.Threading;
using PaK_v1._0.utilities;


namespace PaK_v1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));

            base.OnStartup(e);

            //Show the login view
            loginVM viewModel = new loginVM(new AuthenticationService());
            //ModernDialog loginWindow = new Login(viewModel);
            ModernDialog loginWindow = new Login_alt(viewModel);
            //loginWindow.ShowDialog();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            ThemeManager.SaveTheme(customPrincipal.Identity);
            base.OnExit(e);
        }

    }
}
