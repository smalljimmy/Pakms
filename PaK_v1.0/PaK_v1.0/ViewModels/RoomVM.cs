using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaK_v1._0.Models;
using System.Data;

namespace PaK_v1._0.ViewModels
{
    
    class RoomVM
    {
        private PaKEntities _pakdb;
        private ObservableCollection<rooms> _rooms;
        private int _filter = 1;

        public ObservableCollection<room_types> RoomTypes {
            get{
               return new ObservableCollection<room_types>(_pakdb.room_types.ToList());
            }
            set
            {
            }
        }


        public RoomVM() : this(1) { }
        public RoomVM(int filter)
        {
            _pakdb = new PaKEntities();
            //_rooms = new roomsv();
            _rooms = getrooms(filter);
        }

        private ObservableCollection<rooms> getrooms(int f)
        {
            ObservableCollection<rooms> fl;
            var l = new ObservableCollection<rooms>(_pakdb.rooms);

            switch (f)
            {
                case 1:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.accounts.Count == 0 && x.room_types.type_key == "REGULAR" && x.room_status == true));
                    break;
                case 2:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.accounts.Count == 0 && x.room_types.type_key == "HOTEL" && x.room_status == true));
                    break;
                case 3:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.room_types.type_key == "REGULAR" && x.room_status == true));
                    break;
                case 4:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.room_types.type_key == "HOTEL" && x.room_status == true));
                    break;
                case 5:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.room_status == false));
                    break;
                case 6:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.accounts.Count > 0 && x.room_types.type_key == "REGULAR" && x.room_status == true));
                    break;
                case 7:
                    fl = new ObservableCollection<rooms>(l.Where(x => x.accounts.Count > 0 && x.room_types.type_key == "HOTEL" && x.room_status == true));
                    break;
                default:
                    fl = l; // all rooms
                    break;
            }
            return fl;
        }


        public ObservableCollection<rooms> rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
            }

        }

        public int filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        public void save(rooms room)
        {
            _pakdb.SaveChanges();

        }

    }
}
