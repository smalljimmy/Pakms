using System;
using System.Collections.Generic;
using System.Globalization;
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
using FirstFloor.ModernUI.Windows;
using PaK_v1._0.Models;
using PaK_v1._0.ViewModels;
using System.Data.Entity;
using PaK_v1._0.utilities;
using System.Data.Objects;
using System.Collections.ObjectModel;

namespace PaK_v1._0.Content
{
    /// <summary>
    /// Interaction logic for acct_list.xaml
    /// </summary>
    public partial class acct_list : UserControl, IContent
    {
        private PaKEntities db = new PaKEntities();

        //AcctVM AcctVM = new AcctVM();

        private static int _ifilter;

        public int ifilter
        {
            get { return _ifilter; }
            set { _ifilter = value; }
        }

        // private static bool _gender = false;

        public acct_list()
        {
            InitializeComponent();
            //Loaded += delegate { DataContext = new AcctVM(); };

            CollectionViewSource tariffs = (CollectionViewSource)this.Resources["tariffs"];
            tariffs.Source = new AutoRefreshWrapper<rental_tariffs>(db.rental_tariffs, RefreshMode.StoreWins);
            CollectionViewSource nations = (CollectionViewSource)this.Resources["nations"];
            nations.Source = new AutoRefreshWrapper<nations>(db.nations, RefreshMode.StoreWins);
            CollectionViewSource states = (CollectionViewSource)this.Resources["states"];
            states.Source = new AutoRefreshWrapper<acct_status>(db.acct_status, RefreshMode.StoreWins);
            CollectionViewSource rooms = (CollectionViewSource)this.Resources["rooms"];
            rooms.Source = new AutoRefreshWrapper<rooms>(db.rooms, RefreshMode.StoreWins);

            ifilter = 1;
        }


        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            var filter = int.Parse(e.Fragment); //Can't recall if the # is in here, debug and see

            ifilter = filter;

            CollectionViewSource acctsrc = (CollectionViewSource)this.Resources["AcctSrc"];

            switch (filter)
            {
                case 1:
                    acctsrc.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    acctsrc.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = account.act_active && account.room_id > 1;
                    };
                    break;
                case 2:
                    acctsrc.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    acctsrc.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = account.act_balance < 0 && account.act_active && account.room_id > 1;
                    };
                    break;
                case 3:
                    acctsrc.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    acctsrc.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = true;
                    };
                    break;
                case 4:
                    acctsrc.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    acctsrc.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = !account.act_active;
                    };
                    break;
                default:
                    acctsrc.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    break;
            }
        }


        private void Accounts_Loaded(object sender, RoutedEventArgs e)
        {
            // Register the Bubble Event Handler 
            AddHandler(SearchControl.SearchEvent, new RoutedEventHandler(SearchHandler));
        }

        /*
        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            bool _gender = (radioButton.Content.ToString() == "Male") ? true : false;
        }*/

        public void GuestStateChanged(object sender, RoutedEventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb == null)
                return;

            if (Convert.ToInt32(cb.SelectedValue) != 1) // not a regular guest
            {
                duedotax.IsChecked = false;
                duedotax.Visibility = Visibility.Hidden;
                SvcTab.Visibility = Visibility.Collapsed;
            }
            else
            {
                duedotax.Visibility = Visibility.Visible;
                SvcTab.Visibility = Visibility.Visible;
            }
        }

        public void SearchHandler(object sender, RoutedEventArgs e)
        {
            SearchControl control = (SearchControl)sender;

            //ComboBox combo = (ComboBox)control.FindName("mySearchComboBox");
            TextBox combo = (TextBox)control.FindName("SearchTextBox");

            if (combo != null)
            {
                String search = combo.Text.ToUpper();
                CollectionViewSource accountSource = (CollectionViewSource)this.Resources["AcctSrc"];

                if (!String.IsNullOrEmpty(search))
                {
                    switch (ifilter)
                    {
                        case 1:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;// || account.act_pseudonym.ToString().ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;

                                //if (!string.IsNullOrEmpty(account.act_pseudonym) || (account.rooms != null && !string.IsNullOrEmpty(account.rooms.room_number)) )
                                //{
                                //    if(!string.IsNullOrEmpty(account.act_pseudonym) && (account.rooms != null && !string.IsNullOrEmpty(account.rooms.room_number)))
                                //    {
                                //        ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search) || account.act_pseudonym.ToUpper().Contains(search) || account.rooms.room_number.ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;
                                //    }
                                //    else if (account.rooms != null && !string.IsNullOrEmpty(account.rooms.room_number))
                                //    {
                                //        ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search) || account.rooms.room_number.ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;
                                //    }
                                //    else
                                //    {
                                //        ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search) || account.act_pseudonym.ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;
                                //    }

                                //}
                                //else
                                //{
                                //    ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search))  && account.room_id > 1 && account.act_active;
                                //}

                                // || account.act_pseudonym.ToString().ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;
                            };
                            break;
                        case 2:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search)) && account.room_id > 1 && account.act_active;// || account.act_pseudonym.ToString().ToUpper().Contains(search)) && account.act_balance < 0 && account.act_active && account.room_id > 1;
                            };
                            break;
                        case 3:
                            accountSource.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search));// || account.act_pseudonym.ToString().ToUpper().Contains(search));
                            };
                            break;
                        case 4:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search)) && !account.act_active;// || account.act_pseudonym.ToString().ToUpper().Contains(search)) && !account.act_active;
                            };
                            break;
                        default:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = (account.act_lastname.ToUpper().Contains(search) || account.act_firstname.ToUpper().Contains(search));// || account.act_pseudonym.ToString().ToUpper().Contains(search));
                            };
                            break;
                    }

                }
                else
                {
                    //acctsrc.Filter += (s, ev) =>
                    switch (ifilter)
                    {
                        case 1:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = account.act_active && account.room_id > 1;
                            };
                            break;
                        case 2:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = account.act_balance < 0 && account.act_active && account.room_id > 1;
                            };
                            break;
                        case 4:
                            accountSource.Filter += (s, ev) =>
                            {
                                accounts account = ev.Item as accounts;
                                ev.Accepted = !account.act_active;
                            };
                            break;
                        default:
                            accountSource.Filter += (s, ev) =>
                            {
                                //accounts account = ev.Item as accounts;
                                ev.Accepted = true;
                            };
                            break;
                    }
                    //accountSource.Filter += (s, ev) =>
                    //{
                    //    ev.Accepted = true;
                    //};
                }

            }



            e.Handled = true;
        }


        void tabItemServices_Clicked(object sender, MouseButtonEventArgs e)
        {
            //notifier2.Content = "";
            InitializeServiceTab();
        }

        private void InitializeServiceTab()
        {
             accounts account = (accounts)CollectionViewSource.GetDefaultView(AccountsListView.ItemsSource).CurrentItem;

             if (account != null)
             {
                 var _items = (from item in db.pers_svc
                               select new ServiceItemEntry()
                               {
                                   Svc = item,
                                   IsSelected = db.c_pers_data_svc.Any(x => x.act_id == account.act_id && x.svc_id == item.svc_id)
                               }).ToList();

                 serviceLst.ItemsSource = _items;
             }

        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
        {
            accounts account = (accounts)CollectionViewSource.GetDefaultView(AccountsListView.ItemsSource).CurrentItem;

            try
            {
                /*
                account.act_firstname = FirstName.Text;
                account.act_lastname = LastName.Text;
                account.act_passport_id = TextPassport.Text;
                if (Nation.SelectedValue != null)
                    account.nation_id = Convert.ToInt32(Nation.SelectedValue);
                account.act_gender = (RadioGenderMale.IsChecked == true);
                account.act_birthday = Convert.ToDateTime(DateBirth.ToString());
                account.act_pseudonym = TextPseudonym.Text;
                */
                
                if (AcctState.SelectedValue != null)
                {
                    account.ast_id = Convert.ToInt32(AcctState.SelectedValue);

                    if (account.ast_id == 1)
                    {
                        // "REGULAR_GUEST" that does not exist yet in pers_data
                        if (account.pers_data == null)
                        {
                            pers_data pd = new pers_data();
                            pd.act_id = account.act_id;
                            pd.pdt_duedo_tax = (duedotax.IsChecked == true);
                            db.pers_data.AddObject(pd);

                        }
                        else
                        {
                            account.pers_data.pdt_duedo_tax = (duedotax.IsChecked == true);
                        }
                    }
                    else
                    {
                        if (account.pers_data != null)
                            account.pers_data.pdt_duedo_tax = false;
                    }
                }
                /*
                account.act_active = (Active.IsChecked == true);
                account.act_notes = TextNotes.Text;
                account.act_address = TextAddress.Text;
                account.act_city = TextCity.Text;
                account.act_zip = TextZipCode.Text;
                account.act_email = Email.Text;
                account.act_phone = TextPhone.Text;

                account.room_id = Convert.ToInt32(Room.SelectedValue);

                account.tariff_id = Convert.ToInt32(Rental.SelectedValue);

                account.act_deposit = Convert.ToDecimal(TextDeposit.Text); */

                db.SaveChanges();

                notifier.Foreground = Brushes.DeepSkyBlue;
                notifier.Content = "Daten erfolgreich gespeichert.";

            }
            catch (Exception ex)
            {
                notifier.Foreground = Brushes.Crimson;
                notifier.Content = "Speichern fehlgeschlagen: " + ex.Message;
            }
        }

        private void Save_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                accounts account = (accounts)CollectionViewSource.GetDefaultView(AccountsListView.ItemsSource).CurrentItem;

                var toDelete = db.c_pers_data_svc.Where(w => w.act_id == account.act_id);

                if (toDelete != null)
                {
                    foreach (c_pers_data_svc d in toDelete)
                    {
                        db.c_pers_data_svc.DeleteObject(d);
                    }
                }

                foreach (ServiceItemEntry item in serviceLst.ItemsSource)
                {
                    if (item.IsSelected)
                    {
                        c_pers_data_svc entry = new c_pers_data_svc();
                        entry.act_id = account.act_id;
                        entry.svc_id = item.Svc.svc_id;

                        db.c_pers_data_svc.AddObject(entry);
                    }
                }

                db.SaveChanges();

                notifier2.Foreground = Brushes.DeepSkyBlue;
                notifier2.Content = "Daten erfolgreich gespeichert.";
            }
            catch (Exception ex)
            {
                notifier2.Foreground = Brushes.Crimson;
                notifier2.Content = "Speichern fehlgeschlagen: " + ex.Message;
            }
        }

        private void AccountsListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            accounts account = (accounts)CollectionViewSource.GetDefaultView(AccountsListView.ItemsSource).CurrentItem;
            tabs.SelectedIndex = 0;

            if (account != null)
            {
                if (account.ast_id == 1)
                {
                    duedotax.IsChecked = account.pers_data.pdt_duedo_tax;
                    duedotax.Visibility = Visibility.Visible;
                    SvcTab.Visibility = Visibility.Visible;
                    InitializeServiceTab();
                }
                else
                {
                    duedotax.IsChecked = false;
                    duedotax.Visibility = Visibility.Hidden;
                    SvcTab.Visibility = Visibility.Collapsed;

                }
            }

            notifier.Content = "";
            notifier2.Content = "";
            //InitializeServiceTab();
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
    }

    public class ServiceItemEntry
    {
        public pers_svc Svc { get; set; }
        public bool IsSelected { get; set; }
    }

}
