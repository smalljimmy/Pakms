using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.Models
{
    public partial class users : IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "usr_name")
                {
                    return string.IsNullOrEmpty(usr_name) ? "Angabe erforderlich" : null;
                }
                if (columnName == "usr_firstname")
                {
                    return string.IsNullOrEmpty(usr_firstname) ? "Angabe erforderlich" : null;
                }
                if (columnName == "usr_lastname")
                {
                    return string.IsNullOrEmpty(usr_lastname) ? "Angabe erforderlich" : null;
                }
                if (columnName.Equals("usr_passwd") && (usr_passwd == null || usr_passwd.Length < 3))
                    return "Angabe von mindestens 3 Zeichen erforderlich";


                return null;
            }
        }
    }
}
