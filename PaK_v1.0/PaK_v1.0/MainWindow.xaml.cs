using FirstFloor.ModernUI.Windows.Controls;
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
using System.Security.Permissions;
using PaK_v1._0.ViewModels;
using PaK_v1._0.Models;

namespace PaK_v1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [PrincipalPermission(SecurityAction.Demand)]
    public partial class MainWindow : ModernWindow, IView
    {
        public MainWindow()
        {
            InitializeComponent();

            Application.Current.MainWindow = this;
        }

        #region IView Members
        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }
        #endregion

    }

}
