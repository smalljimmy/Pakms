using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//using FirstFloor.ModernUI.Windows.Navigation;
//using FirstFloor.ModernUI.Windows.Controls;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
using PaK_v1._0.Pages.Content;
//using System.Windows.Automation.Peers;
//using System.Windows.Navigation;
//using System.Windows;

namespace PaK_v1._0.ViewModels
{
    public class RoomNewVM : VMBase, IDataErrorInfo
    {

        private PaKEntities _pak = new PaKEntities();

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private ObservableCollection<room_types> _roomtypes;


        public RoomNewVM()
        {
            _roomtypes = new ObservableCollection<room_types>(_pak.room_types);
            _commands = new CommandMap();
            _commands.AddCommand("add", x => AddRoom());

        }

        public bool roomstatus { get; set; }
        public string roomnumber { get; set; }
        public int? roomtypeid { get; set; }

        public new_room View { get; set; }

        public ObservableCollection<room_types> RoomTypeSource
        {
            get
            {
                return _roomtypes;
            }
        }
        

        public void AddRoom()
        {
            var mroom = new rooms();

            mroom.room_number = roomnumber;
            mroom.room_status = roomstatus;
            mroom.roomtype_id = roomtypeid.Value;
            _pak.rooms.AddObject(mroom);
            _pak.SaveChanges();

        }


        public string Error
        {
            get { return null; }
        }

        public string this[string fieldName]
        {
            get
            {
                if (fieldName == "roomnumber")
                {
                    return string.IsNullOrEmpty(this.roomnumber) ? "Angabe erforderlich" : null;
                }
                if (fieldName == "roomtypeid")
                {
                    return  !this.roomtypeid.HasValue ? "Angabe erforderlich" : null;
                }

                return null;
            }
        }

       
    }
}
