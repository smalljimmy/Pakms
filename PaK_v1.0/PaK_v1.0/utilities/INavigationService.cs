using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.utilities
{
    public interface INavigationService
    {
        void Navigate<T>(object parameter = null);

        void GoBack();
    }
}
