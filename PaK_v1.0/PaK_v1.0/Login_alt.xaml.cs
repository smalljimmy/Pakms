using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Controls;
using PaK_v1._0.ViewModels;

namespace PaK_v1._0
{
    
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Interaction logic for Login_alt.xaml
    /// </summary>
    public partial class Login_alt : ModernDialog, IView
    {
        public Login_alt(loginVM viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();

            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            Binding b = new Binding();
            b.Path = new PropertyPath("LoginCommand");
            Binding p = new Binding();
            p.ElementName = "passwordBox";
            OkButton.SetBinding(Button.CommandProperty, b);
            OkButton.SetBinding(Button.CommandParameterProperty, p);

            OkButton.Content = "Login";
            CancelButton.Content = "Abbrechen";

            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(() => this.Close());
            
            this.ShowDialog();
        }

        #region IView Members
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
        #endregion

    }
}
