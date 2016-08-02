using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace PaK_v1._0.Content
{
    public partial class SearchControl
    {

        public static readonly RoutedEvent SearchEvent =
            EventManager.RegisterRoutedEvent("SearchEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(SearchControl));


        public event RoutedEventHandler SearchHandler
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }


        public SearchControl()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }


        protected void OnKeyUp(object sender, KeyEventArgs e)
        {
            var newEventArgs = new RoutedEventArgs(SearchEvent);
                   
            // Raises the custom to parent window
            RaiseEvent(newEventArgs);
        
        }

        protected void Search(object sender, RoutedEventArgs e)
        {
            RaiseEvent(e);
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;

            var newEventArgs = new RoutedEventArgs(SearchEvent);
            // Raises the custom to parent window
            RaiseEvent(newEventArgs);
        }


    
    }
}