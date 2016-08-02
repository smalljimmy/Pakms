using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using PaK_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaK_v1._0.utilities
{

    public class NavigationService : INavigationService
    {

        /// <summary>
        /// The view model routing.
        /// </summary>
        private static readonly Dictionary<Type, string> viewModelRouting
            = new Dictionary<Type, string>
            {
                { typeof(RoomVM), "/Pages/rooms.xaml#1" },
                { typeof(BookNewVM), "/Pages/bookings.xaml#1" },
                { typeof(AcctNewVM), "/Pages/accounts.xaml" },
                { typeof(TaxRepVM), "/Pages/duedotax.xaml#1" },
                { typeof(UserNewVM), "/Pages/users.xaml#1" }
            };


        ModernFrame mainFrame;

        private static NavigationService Instance
        {
            get; set;        
        }


        public static NavigationService GetInstance()
        {
            if (NavigationService.Instance == null){
                NavigationService.Instance = new NavigationService();
            };
            
            return NavigationService.Instance;
        }

        public NavigationService()
        {
            EnsureMainFrame();
        }

        private void EnsureMainFrame()
        {
            if (mainFrame == null)
            {
                var f = Application.Current.MainWindow;
                mainFrame = GetDescendantFromName(f, "ContentFrame") as ModernFrame;
            }
        }

        /// <summary>
        /// Gets the name of the descendant from.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns>Gets a descendant FrameworkElement based on its name.A descendant FrameworkElement with the specified name or null if not found.</returns>
        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
                return null;

            FrameworkElement fe;

            for (int i = 0; i < count; i++)
            {
                fe = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (fe != null)
                {
                    if (fe.Name == name)
                        return fe;

                    fe = GetDescendantFromName(fe, name);
                    if (fe != null)
                        return fe;
                }
            }

            return null;
        }

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="T">ViewModel type</typeparam>
        /// <param name="parameter">The parameter.</param>
        public void Navigate<T>(object parameter = null)
        {
            EnsureMainFrame();

            var navParameter = string.Empty;

            if (viewModelRouting.ContainsKey(typeof(T)))
            {
                Uri uri = new Uri(viewModelRouting[typeof(T)] + navParameter, UriKind.RelativeOrAbsolute);
                mainFrame.KeepContentAlive = false;
                mainFrame.Source = uri;
            }
        }

        /// <summary>
        /// Invokes the go back.
        /// </summary>
        public void GoBack()
        {
            NavigationCommands.BrowseBack.Execute(null, null);
        }

    }
}
