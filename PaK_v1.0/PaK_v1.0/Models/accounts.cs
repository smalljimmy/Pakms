using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.Models
{
    public partial class accounts : IDataErrorInfo 
    {
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "act_firstname")
                {
                    return string.IsNullOrEmpty(act_firstname) ? "Angabe erforderlich" : null;
                }
                if (columnName == "act_lastname")
                {
                    return string.IsNullOrEmpty(act_lastname) ? "Angabe erforderlich" : null;
                }
                if (columnName == "act_passport_id")
                {
                    return string.IsNullOrEmpty(act_passport_id) ? "Angabe erforderlich" : null;
                }
                return null;
            }
        }
    }
}
