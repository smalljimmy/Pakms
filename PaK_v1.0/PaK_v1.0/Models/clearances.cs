using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PaK_v1._0.Models
{
    public partial class clearances
    {
        public ListCollectionView bookingListCollectionView
        {
            get
            {
                return new ListCollectionView(bookings.ToList());
            }
        }
        

    }
}
