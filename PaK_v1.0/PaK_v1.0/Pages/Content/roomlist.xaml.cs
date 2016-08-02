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
using PaK_v1._0.Models;
using System.Windows.Controls.Primitives;
using PaK_v1._0.utilities;
using System.Windows.Media.Animation;
using System.Collections;


namespace PaK_v1._0.Pages.Content
{
    /// <summary>
    /// Interaction logic for roomlist.xaml
    /// </summary>
    public partial class roomlist : CustomeUserControl, IContent
    {


        private RoomVM vm;

        public roomlist()
        {
            InitializeComponent();
            Binding.AddSourceUpdatedHandler(DG1,OnDataGridSourceUpdated);
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            var filter = int.Parse(e.Fragment); 
            vm = new RoomVM(filter);
            this.DataContext = vm;

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

        private void OnDataGridSourceUpdated(object sender, DataTransferEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            Models.rooms room = dg.SelectedItem as Models.rooms;



            DataGridRow row = GetSelectedDataGridRow(dg);
                row.BeginStoryboard((Storyboard)Application.Current.Resources["changeStoryBoard"]);           

            if (room != null)
            {
                    
                    vm.save(room);
            }                       
        }

        public DataGridRow GetSelectedDataGridRow(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;

            if (itemsSource != null)
            {

                foreach (var item in itemsSource)
                {
                    var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (null != row && row.IsSelected)
                    {
                        return row;
                    }
                }
            }

            return null;
        }

    }
}
