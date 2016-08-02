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
using PaK_v1._0.ViewModels;
using FirstFloor.ModernUI.Windows;
using PaK_v1._0.utilities;

namespace PaK_v1._0.Content
{
    /// <summary>
    /// Interaction logic for pers_list.xaml
    /// </summary>
    public partial class pers_list : UserControl, IContent
    {

        public pers_list()
        {
            InitializeComponent();
            this.DataContext = new AcctVM(1);
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            var filter = int.Parse(e.Fragment); //Can't recall if the # is in here, debug and see
            this.DataContext = new AcctVM(filter);

        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Scan_Click_1(object sender, RoutedEventArgs e)
        {
            var img = ScanManager.ScanImage();

        }

        private void SearchTextBox_KeyUp_1(object sender, KeyEventArgs e)
        {

        }
    }
}
