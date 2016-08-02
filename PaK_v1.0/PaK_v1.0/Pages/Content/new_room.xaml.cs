using FirstFloor.ModernUI.Windows.Controls;
using PaK_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace PaK_v1._0.Pages.Content
{
    /// <summary>
    /// Interaction logic for new_room.xaml
    /// </summary>
    public partial class new_room : UserControl
    {
        public new_room()
        {
            InitializeComponent();

            RoomNewVM vm = new RoomNewVM {
                View = (new_room)this
            };
            Form.DataContext = vm;
        }

    }


}
