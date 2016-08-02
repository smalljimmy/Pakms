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

namespace PaK_v1._0.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class bookings : UserControl
    {
        public bookings()
        {
            InitializeComponent();
            DataContext = new TabVM();
            //PaK_v1._0.ViewModels.TabVM vm = new ViewModels.TabVM("/Pages/Content/booking_list.xaml#1");
            //gridTab.DataContext = vm;
        }
    }
}
