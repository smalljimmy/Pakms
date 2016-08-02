using iTextSharp.text;
using iTextSharp.text.pdf;
//using PaK_v1._0.Content;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PaK_v1._0.ViewModels
{
    class OverviewRepVM : VMBase
    {
        private PaKEntities db = new PaKEntities();
        private CommandMap _commands;

        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        public DateTime dtFrom { get; set; }
        //public DateTime dtTo { get; set; }

        private ObservableCollection<Persdata> loverview { get; set; }

        private ICollectionView _persView;

        public ICollectionView persView
        {
            get { return _persView; }
            set
            {
                if (value != _persView)
                {
                    _persView = value;
                    RaisePropertyChanged("persView");
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }



        public OverviewRepVM()
        {
            //ifilter = f;
            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search());
            _commands.AddCommand("print", x => Print());

            dtFrom = DateTime.Today;
            Title = "Mieterübersicht für PP Köln KK26 - Stand " + dtFrom.ToShortDateString();
            loverview = getlist();
            // init item source and notify view
            persView = CollectionViewSource.GetDefaultView(loverview);
        }


        private ObservableCollection<Persdata> getlist()
        {
            // conditions for PP list:
            // i.   account is active
            // ii.  account is of type "REGULAR_GUEST", "TABLE_DANCE" or "CLUB_11"
            // iii. account is checked-in (room_id > 0)
            // iv   room type is "REGULAR" or "PRIVATE"(= Arbeitszimmer/Privatzimmer)
            // iv.  tariff?
            // where a.room_id != null && a.room_id > 0 && a.act_active == true


            if (dtFrom == DateTime.Today)
            {
                var q = (from a in db.accounts
                         where (
                            a.room_id != null && a.room_id > 0 && a.act_active == true
                            && (a.rooms.room_types.type_key == "REGULAR" || a.rooms.room_types.type_key == "PRIVATE")
                            && (a.acct_status.ast_key == "REGULAR_GUEST" || a.acct_status.ast_key == "TABLE_DANCE" || a.acct_status.ast_key == "CLUB_11")
                         )
                         select
                             new Persdata()
                             {
                                 Room = a.rooms.room_number,
                                 Lastname = a.act_lastname,
                                 Firstname = a.act_firstname,
                                 Pseudonym = a.act_pseudonym,
                                 Birthday = (DateTime)a.act_birthday,
                                 Birthplace = a.act_birthplace,
                                 Countrycode = a.nations.iso_2,
                                 Passportid = a.act_passport_id
                             });

                return new ObservableCollection<Persdata>(q.ToList());
            }
            else
            {
                var t = db.daily_run.FirstOrDefault(d => d.day == dtFrom.Date);
                int day_id = (t == null ? 0 : t.day_id);

                var q = (from a in db.acct_bookings where
                            a.day_id == day_id && (a.type_key == "REGULAR" || a.type_key == "PRIVATE")
                            && (a.tariff_id !=1 || a.tariff_id != 900) 
                            && (a.ast_key == "REGULAR_GUEST" || a.ast_key == "TABLE_DANCE" || a.ast_key == "CLUB_11")
                        select
                        new Persdata()
                            {
                                Room = a.room_number,
                                Lastname = a.act_lastname,
                                Firstname = a.act_firstname,
                                Pseudonym = a.act_pseudonym,
                                Birthday = (DateTime)a.act_birthday,
                                Birthplace = a.act_birthplace,
                                Countrycode = a.iso_2,
                                Passportid = a.act_passport_id
                            });

                return new ObservableCollection<Persdata>(q.ToList());
            }
                       
        }
        

        //filter list by dates
        public void Search(){

            Title = "Mieterübersicht für PP Köln KK26 - Stand " + dtFrom.ToShortDateString();
            loverview = getlist();
            persView = CollectionViewSource.GetDefaultView(loverview);

        }

        public void Print()
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\OverviewRep_" + tdy + ".pdf";

            //use small font
            BaseFont bf_normal
                        = BaseFont.CreateFont("c://windows/fonts/arial.ttf",
                            BaseFont.WINANSI, BaseFont.EMBEDDED);
            Font small = new Font(bf_normal, 8);


            Document doc = new Document(PageSize.A4, 0, 0, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(8);

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase("Zimmer", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Name", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Vorname", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Pseudonym", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Geburtstag", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Geburtsort", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Nation", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Passnummer", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);


            // define header row
            table.HeaderRows = 1;

            foreach (var l in loverview)
            {
                cell = new PdfPCell(new Phrase(l.Room, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Lastname, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Firstname, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Pseudonym, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Birthday.ToShortDateString(), small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Birthplace, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Countrycode, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(l.Passportid, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);
            }

            //Title
            ptitle = "Mieterübersicht für PP Köln KK26 - Stand " + dtFrom.ToShortDateString(); 
            PdfPTable t2 = new PdfPTable(1);
            t2.DefaultCell.Border = PdfPCell.NO_BORDER;
            t2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            t2.AddCell(new Phrase(ptitle));
            doc.Add(t2);

            // a little space
            doc.Add(new Paragraph(new Phrase(" ")));
            // Table
            doc.Add(table);
            // a little space
            doc.Add(new Paragraph(new Phrase(" ")));

            // finsish and open
            doc.Close();

            PrinterManager.Print(filename);


        }


    }



       public class Persdata : INotifyPropertyChanged
        {
           public string Room { get; set; }
           public string Lastname { get; set; }
           public string Firstname { get; set; }
           public string Pseudonym { get; set; }
           public DateTime Birthday { get; set; }
           public string Birthplace { get; set; }
           public string Countrycode { get; set; }
           public string Passportid { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {

                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    var e = new PropertyChangedEventArgs(propertyName);
                    handler(this, e);
                }
            }
        }
      

}
