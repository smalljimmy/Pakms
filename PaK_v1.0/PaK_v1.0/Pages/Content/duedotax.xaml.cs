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
//using System.Windows.Navigation;
using System.Windows.Shapes;
using PaK_v1._0.ViewModels;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace PaK_v1._0.Pages.Content
{
    /// <summary>
    /// Interaction logic for duedotax.xaml
    /// </summary>
    public partial class duedotax : UserControl, IContent
    {


        //private TaxRepVM vm;

        public duedotax()
        {
            InitializeComponent();

            /*TaxRepVM vm = new TaxRepVM();
            this.DataContext = vm;*/

        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            var filter = int.Parse(e.Fragment);
            DataContext = new TaxRepVM(filter);
//            this.DataContext = vm;

        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

    }
}
