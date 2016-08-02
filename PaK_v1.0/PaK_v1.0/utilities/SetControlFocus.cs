using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PaK_v1._0.utilities
{
    public class SetControlFocus
    {
        public static readonly DependencyProperty SetFocusProperty = DependencyProperty.RegisterAttached("SetFocus",
                                                                               typeof(Boolean),
                                                                               typeof(SetControlFocus),
                                                                               new PropertyMetadata(OnSetFocusChanged));

        private static void OnSetFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null && d is Control)
            {
                if ((bool)e.NewValue)
                {
                    (d as Control).GotFocus += OnLostFocus;
                    (d as Control).Focus();
                }
                else
                {
                    (d as Control).GotFocus -= OnLostFocus;
                }
            }
        }

        private static void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is Control)
            {
                (sender as Control).SetValue(SetFocusProperty, false);
            }
        }

        public static Boolean GetSetFocus(DependencyObject target)
        {
            return (Boolean)target.GetValue(SetFocusProperty);
        }

        public static void SetSetFocus(DependencyObject target, Boolean value)
        {
            target.SetValue(SetFocusProperty, value);
        }
    }
}
