using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaK_v1._0.Models
{
    public partial class rooms
    {

        public int occupancy
        {
            get
            {
                return this.accounts.Count;
            }
        }

        public string occupants
        {
            get
            {

                string result = "";
                foreach (accounts a in this.accounts){
                    result += a.act_firstname + ",";
                }

                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }

                return result;
            }
        }

        public string comb_occup
        {
            get
            {
                string result = "";
                if (this.accounts.Count == 0)
                    result = "Frei";
                else
                {

                    result = this.accounts.Count.ToString() + " Pers: ";

                    foreach (accounts a in this.accounts)
                    {
                        result += a.act_firstname + " " + a.act_lastname + ",";
                    }

                    if (result.Length > 0)
                    {
                        result = result.Substring(0, result.Length - 1);
                    }
                }

                return result;
            }
        }

        public int roomtypeid
        {
            get
            {
                return room_types == null ? 0 : room_types.roomtype_id;
            }

            set
            {
                this.room_types.roomtype_id = value;
            }
        }


    }
}
