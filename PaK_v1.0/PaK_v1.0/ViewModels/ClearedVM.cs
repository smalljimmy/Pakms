using iTextSharp.text;
using iTextSharp.text.pdf;
using PaK_v1._0.Content;
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
    class ClearedVM : VMBase, INotifyPropertyChanged
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
        public DateTime dtTo { get; set; }

        public int Count
        {
            get
            {
                return _selectedClearance == null ? 0 : _selectedClearance.bookings.Count;
            }
        }

        public Decimal Sum
        {
            get
            {
                return _selectedClearance == null ? 0 : _selectedClearance.bookings.Sum(x => x.bkg_amount);
            }
        }



        private ObservableCollection<clearances> clearances { get; set; }
        private ObservableCollection<bookings> bookings { get; set; }

        public ICollectionView clearanceView { get; set; }
        public ICollectionView bookingView { get; set; }


        private clearances _selectedClearance;

        public clearances selectedClearance
        {
            get
            {
                return _selectedClearance;
            }

            set
            {
                _selectedClearance = value;

                bookings = new ObservableCollection<bookings>();

                if (_selectedClearance != null)
                {
                    bookings = new ObservableCollection<bookings>(_selectedClearance.bookings.ToList());
                    bookingView = CollectionViewSource.GetDefaultView(bookings);
                }
                RaisePropertyChanged("bookingView");
            }
        }

        public ClearedVM()
        {
            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search());
            _commands.AddCommand("printClearences", x => PrintClearences());


            //initialize search list
            dtFrom = db.clearances.Count() == 0 ? DateTime.Now : db.clearances.OrderBy(x => x.clr_date).First().clr_date;
            dtTo = DateTime.Now.Date;
            clearances = new ObservableCollection<clearances>(db.clearances.ToList());
            clearanceView = CollectionViewSource.GetDefaultView(clearances);
        }


        //filter list by dates
        public void Search(){

            clearanceView.Filter = x => ((clearances)x).clr_date.Date >= dtFrom.Date && ((clearances)x).clr_date.Date <= dtTo.Date ;
            clearanceView.Refresh();
        
        }

        public void PrintClearences()
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\Clearence_" + tdy + ".pdf";

            Document doc = new Document(PageSize.A4, 20, 20, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(5);

            //if (f == 2)
            //{
            //    pfilter = "Produktgruppe";
            //}
            //else
            //{
            //    pfilter = "Artikel";
            //}

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase("Nr"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Datum"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Zeit"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Betrag"));
            cell.HorizontalAlignment = 2;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("User"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            // define header row
            table.HeaderRows = 1;

            foreach (var c in clearances)
            {
                cell = new PdfPCell(new Phrase(c.clr_id.ToString()));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.clr_date.ToShortDateString()));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.clr_date.ToShortTimeString()));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.clr_sum.ToString()));
                cell.HorizontalAlignment = 2;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(c.users.usr_name));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);
            }

            //Title
            ptitle = "Abrechnung vom " + dtFrom.ToShortDateString() + " bis " + dtTo.ToShortDateString();
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
