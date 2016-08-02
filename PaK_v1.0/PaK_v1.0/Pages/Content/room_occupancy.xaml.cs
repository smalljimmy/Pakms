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
    public partial class room_occupancy : UserControl
    {


        private OccupancyVM vm;

        public room_occupancy()
        {
            InitializeComponent();
            vm = new OccupancyVM();
            this.DataContext = vm;

            /*TaxRepVM vm = new TaxRepVM();
            this.DataContext = vm;*/

        }

    }
}
