using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.utilities
{
    public interface INotifyRefresh : INotifyCollectionChanged
    {
        void OnRefresh();
    }
}
