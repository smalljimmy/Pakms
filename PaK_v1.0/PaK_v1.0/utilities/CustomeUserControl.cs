using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaK_v1._0.utilities
{
    public class CustomeUserControl : UserControl
    {

        public T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }


        public T FindVisualParent<T>(UIElement element) where T : UIElement
        {

            UIElement parent = element;

            while (parent != null)
            {

                T correctlyTyped = parent as T;

                if (correctlyTyped != null)
                {

                    return correctlyTyped;

                }



                parent = VisualTreeHelper.GetParent(parent) as UIElement;

            }



            return null;

        }

        public DependencyObject GetNextSibling(ItemsControl itemsControl, DependencyObject sibling)
        {
            var n = itemsControl.Items.Count;
            var foundSibling = false;
            for (int i = 0; i < n; i++)
            {
                var child = itemsControl.ItemContainerGenerator.ContainerFromIndex(i);
                if (foundSibling)
                    return child;

                if (child == sibling)
                    foundSibling = true;
            }
            return null;
        }
    }
}
