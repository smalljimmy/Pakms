using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace PaK_v1._0.ViewModels
{


    class OccupancyVM : VMBase
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

        private string _today;
        public string Today { 
            get { return _today; }
            set
            { 
                _today = value;
                RaisePropertyChanged("Today");
            }
        }

        //private ObservableCollection<room_occupancy> _occupancy;

        //public ObservableCollection<room_occupancy> Occupancy
        //{
        //    get { return _occupancy; }
        //    set
        //    {
        //        if (value != _occupancy)
        //        {
        //            _occupancy = value;
        //            RaisePropertyChanged("Occupancy");
        //        }
        //    }
        //}

        private ICollectionView _occupancy;

        public ICollectionView Occupancy
        {
            get { return _occupancy; }
            set
            {
                if (value != _occupancy)
                {
                    _occupancy = value;
                    RaisePropertyChanged("Occupancy");
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

        public OccupancyVM()
        {
            _commands = new CommandMap();
            _commands.AddCommand("print", x=> Print());

            Today = "Stand " + DateTime.Today.ToLongDateString();
            Title = "Zimmerbelegung - " + Today;
            var rc = new ObservableCollection<room_occupancy>(db.room_occupancy.Where(o => o.room_number != null && o.room_number != ""));
            Occupancy = CollectionViewSource.GetDefaultView(rc);

        }


        public void Print()
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\Zimmer_" + tdy + ".pdf";

            //use small font
            BaseFont bf_normal
                        = BaseFont.CreateFont("c://windows/fonts/arial.ttf",
                            BaseFont.WINANSI, BaseFont.EMBEDDED);
            Font small = new Font(bf_normal, 8);

            Document doc = new Document(PageSize.A4, 20, 20, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(5);

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase("Zimmer", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Konto", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Künstlername", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Bemerkung", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Tarif", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);


            // define header row
            table.HeaderRows = 1;

            foreach (var c in Occupancy.Cast<room_occupancy>())
            {
                cell = new PdfPCell(new Phrase(c.room_number, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.account_id, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.pseudonym, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.notes, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.tariff, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);
            }

            //Title
            ptitle = Title; // "Zimmerbelegung- Stand " + tdy;
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
}
