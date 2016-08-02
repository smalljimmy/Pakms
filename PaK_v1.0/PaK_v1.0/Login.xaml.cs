using System;
using FirstFloor.ModernUI.Windows.Controls;
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
using PaK_v1._0.ViewModels;

namespace PaK_v1._0
{
    /*
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

    }
    */
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : ModernDialog, IView  //UserControl ModernDialog
    {


        public Login(loginVM viewModel)
        {

            ViewModel = viewModel;
            InitializeComponent();

            //remove 'Close (default)' button
            List<Button> buttons = new List<Button>();
            foreach (Button b in Buttons)
            {
                if (!b.IsDefault)
                {
                    buttons.Add(b);
                }
                

            }

            Buttons = buttons;

            btn_login.Focus();
            
            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(() => this.Close());
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
