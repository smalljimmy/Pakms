
using System.Windows.Controls;
using PaK_v1._0.ViewModels;

namespace PaK_v1._0.Pages
{
    /// <summary>
    /// Interaction logic for reports.xaml
    /// </summary>
    public partial class reports : UserControl
    {
        public reports()
        {
            InitializeComponent();
            DataContext = new reportsVM();
        }
    }
}
