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
    class TaxRepVM : VMBase
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


        private string _title;


        public string title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("title");
                }
            }
        }

        private static int _ifilter;

        public int ifilter
        {
            get { return _ifilter; }
            set { _ifilter = value; }
        }

        /*
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

        */

        private ObservableCollection<Taxdata> ltax { get; set; }

        private ICollectionView _taxView;
 
        public ICollectionView taxView {
            get { return _taxView;  }
            set
            {
                if (value != _taxView)
                {
                    _taxView = value;
                    RaisePropertyChanged("taxView");
                }
            }
        }


        public TaxRepVM() : this(1) { }

        public TaxRepVM(int f)
        {
            ifilter = f;
            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search());
            _commands.AddCommand("print", x => Print(f));

            title = "Düsseldorfer Verfahren";
            // initialize search list
            // get first day of last month
            //dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            dtFrom = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
            // get last day of last month
            dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

            ltax = getlist();
            // init item source and notify view
            taxView = CollectionViewSource.GetDefaultView(ltax);
        }


        private ObservableCollection<Taxdata> getlist()
        {
            IQueryable<Bookings> q;
            
            switch (ifilter)
            {
                case 1:
                    title = "Düsseldorfer Verfahren";
                    q = (from b in db.bookings
                         where b.daily_run.day >= dtFrom && b.daily_run.day <= dtTo && b.bkg_comment == "Düsseldorfer Verfahren"
                         select new Bookings()
                         {
                             AccountId = b.act_id,
                             Lastname = b.accounts.act_lastname,
                             Firstname = b.accounts.act_firstname,
                             Pseudonym = b.accounts.act_pseudonym,
                             Amount = -b.bkg_amount,
                             Night = 1
                         });
                    break;
                case 3:
                    title = "Vergnügungssteuer";
                    decimal etax = Convert.ToDecimal(db.settings.FirstOrDefault(t => t.set_key == "ENTERTAINMENT_TAX").set_value);
                    q = (from b in db.bookings
                         where b.daily_run.day >= dtFrom && b.daily_run.day <= dtTo && (1 == 1) // tbd
                         select new Bookings()
                         {
                             AccountId = b.act_id,
                             Lastname = b.accounts.act_lastname,
                             Firstname = b.accounts.act_firstname,
                             Pseudonym = b.accounts.act_pseudonym,
                             Amount = -etax,
                             Night = 1
                         });
                    break;
                default:
                    title = "Düsseldorfer Verfahren (Aufstellung alle)";
                     q = (from b in db.bookings
                     where b.daily_run.day >= dtFrom && b.daily_run.day <= dtTo
                     select new Bookings()
                     {
                         AccountId = b.act_id,
                         Lastname = b.accounts.act_lastname,
                         Firstname = b.accounts.act_firstname,
                         Pseudonym = b.accounts.act_pseudonym,
                         Amount = (b.bkg_comment == "Düsseldorfer Verfahren") ? -b.bkg_amount : 0,
                         Night = (b.bkg_comment == "Düsseldorfer Verfahren") ? 1 : 0
                     });
                    break;
            }

            var q2 = q.GroupBy(t => new { t.AccountId, t.Lastname, t.Firstname, t.Pseudonym })
                    .Select(g => new Taxdata()
                    {
                        Account = g.Key.AccountId,
                        Lastname = g.Key.Lastname,
                        Firstname = g.Key.Firstname,
                        Pseudonym = g.Key.Pseudonym,
                        Amount = g.Sum(x => x.Amount),
                        Number = g.Sum(x => x.Night)
                    });

            return new ObservableCollection<Taxdata>(q2.ToList());
        }
        

        //filter list by dates
        public void Search(){

            ltax = getlist();
            taxView = CollectionViewSource.GetDefaultView(ltax);

        }

        public void Print(int f)
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\Tax_" + tdy + ".pdf";

            Document doc = new Document(PageSize.A4, 20, 20, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(6);

            //if (f == 2)
            //{
            //    pfilter = "Produktgruppe";
            //}
            //else
            //{
            //    pfilter = "Artikel";
            //}

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase("Konto"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Name"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Vorname"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Pseudonym"));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("#Tage"));
            cell.HorizontalAlignment = 2;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Steuer(EUR)"));
            cell.HorizontalAlignment = 2;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            // define header row
            table.HeaderRows = 1;

            foreach (var t in ltax)
            {
                cell = new PdfPCell(new Phrase(t.Account));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(t.Lastname));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(t.Firstname));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(t.Pseudonym));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(t.Number));
                cell.HorizontalAlignment = 2;
                cell.Padding = 4;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(t.Amount.ToString()));
                cell.HorizontalAlignment = 2;
                cell.Padding = 4;
                table.AddCell(cell);
            }

            //Title
            ptitle = title + " vom " + dtFrom.ToShortDateString() + " bis " + dtTo.ToShortDateString();
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

    public class Bookings
    {
        public int AccountId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Pseudonym { get; set; }
        public decimal Amount { get; set; }
        public int Night { get; set; }
    }

       public class Taxdata : INotifyPropertyChanged
        {
            public int Account { get; set; }
            public string Lastname { get; set; }
            public string Firstname { get; set; }
            public string Pseudonym { get; set; }
            public decimal Amount { get; set; }
            public int Number { get; set; }

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
       /* 
           public class Taxdata
           {
               public int Account { get; set; }
               public string Lastname { get; set; }
               public string Firstname { get; set; }
               public string Pseudonym { get; set; }
               public decimal Amount { get; set; }
               public int Number { get; set; }
           }*/

}
