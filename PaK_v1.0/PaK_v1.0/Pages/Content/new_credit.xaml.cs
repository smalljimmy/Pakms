using PaK_v1._0.Content;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using PaK_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects;
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
    /// Interaction logic for new_booking.xaml
    /// </summary>
    public partial class new_credit : UserControl
    {

        private PaKEntities db = new PaKEntities();

        public new_credit()
        {
            InitializeComponent();

            //initialize account list
            //initialize account list
            CollectionViewSource acctsrc = (CollectionViewSource)this.Resources["AcctSrc"];
            acctsrc.Source = new AutoRefreshWrapper<Models.accounts>(db.accounts, RefreshMode.StoreWins);
            acctsrc.Filter += (s, ev) =>
            {
                Models.accounts account = ev.Item as Models.accounts;
                ev.Accepted = account.act_active;
            };

            //ComboCurrency.ItemsSource = db.currencies.ToList();
            //ComboCurrency.SelectedValue = 1;

        }


        public Models.accounts selectedAccount { get; set; }

        private void Accounts_Loaded(object sender, RoutedEventArgs e)
        {
            // Register the Bubble Event Handler 
            AddHandler(SearchControl.SearchEvent, new RoutedEventHandler(SearchHandler));
        }


        public void SearchHandler(object sender, RoutedEventArgs e)
        {
            SearchControl control = (SearchControl)sender;

            //ComboBox combo = (ComboBox)control.FindName("mySearchComboBox");
            TextBox combo = (TextBox)control.FindName("SearchTextBox");

            if (combo != null)
            {
                String search = combo.Text;
                CollectionViewSource accountSource = (CollectionViewSource)this.Resources["AcctSrc"];

                if (!String.IsNullOrEmpty(search))
                {
                    accountSource.Filter += (s, ev) =>
                    {
                        PaK_v1._0.Models.accounts account = ev.Item as PaK_v1._0.Models.accounts;

                        ev.Accepted = account.act_lastname.Contains(search) || account.act_firstname.Contains(search);
                    };
                }
                else
                {
                    accountSource.Filter += (s, ev) =>
                    {
                        ev.Accepted = true;
                    };
                }

            }



            e.Handled = true;
        }

        private void AccountsListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            this.selectedAccount = (Models.accounts)CollectionViewSource.GetDefaultView(AccountsListView.ItemsSource).CurrentItem;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Models.bookings booking = new Models.bookings
            {
                bkg_date = DateTime.Now,
                act_id = selectedAccount.act_id,
                btp_id = 2, //Gutschrift
                bkg_amount = Decimal.Parse(TextTotal.Text), //Belastung is always negativ
                usr_id = ApplicationState.GetValue<int>("userid"),
                //cur_id = (int)ComboCurrency.SelectedValue//currency
            };

            db.bookings.AddObject(booking);

            db.SaveChanges();

            db.Refresh(System.Data.Objects.RefreshMode.StoreWins, booking);


            TabVM.Instance.SelectedSource = new Uri("/Pages/Content/booking_list.xaml#1", UriKind.Relative);
            utilities.NavigationService.GetInstance().Navigate<RoomNewVM>(null);
        }




    }
}
