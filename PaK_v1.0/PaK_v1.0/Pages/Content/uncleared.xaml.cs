using PaK_v1._0.Content;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using PaK_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PaK_v1._0.Pages.Content
{
    /// <summary>
    /// Interaction logic for uncleared.xaml
    /// </summary>
    public partial class uncleared : UserControl
    {

        public uncleared()
        {
            InitializeComponent();

            UnclearedVM vm = new UnclearedVM();
            this.DataContext = vm;
        }

    }
}
