using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace PaK_v1._0.utilities
{
    class Bool2VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && targetType == typeof(Visibility))
            {
                bool val = (bool)value;
                if (val)
                    return Visibility.Visible;
                else
                    if (parameter != null && parameter is Visibility)
                        return parameter;
                    else
                        return Visibility.Collapsed;
            }
            throw new ArgumentException("Invalid argument/return type. Expected argument: bool and return type: Visibility");


        }

       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value is Visibility && targetType == typeof(bool))
    		{
    			Visibility val = (Visibility)value;
    			if (val == Visibility.Visible)
    				return true;
    			else
    				return false;
    		}
    		throw new ArgumentException("Invalid argument/return type. Expected argument: Visibility and return type: bool");
    	}


    }
}
