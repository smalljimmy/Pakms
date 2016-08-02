using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using PaK_v1._0.Models;
using PaK_v1._0.utilities;

namespace PaK_v1._0.ViewModels
{
    class RevenuesVM : VMBase
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

        private DateTime _dtFrom;
        public DateTime dtFrom {
            get { return _dtFrom; }
            set
            {
                _dtFrom = value;
                RaisePropertyChanged("dtFrom");
            }
        }

        private DateTime _dtTo;
        public DateTime dtTo {
            get { return _dtTo; }
            set
            {
                _dtTo = value;
                RaisePropertyChanged("dtTo");
            }
        }

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

        private string _hdrname;
        public string hdrname
        {
            get { return _hdrname; }
            set
            {
                if (value != _hdrname)
                {
                    _hdrname = value;
                    RaisePropertyChanged("hdrname");
                }
            }
        }

        public ObservableCollection<Revenue> Revenues { get; set; }


        private ICollectionView _revView;

        public ICollectionView revView
        {
            get { return _revView; }
            set
            {
                if (value != _revView)
                {
                    _revView = value;
                    RaisePropertyChanged("revView");
                }
            }
        }

        //public ICollectionView revView { get; set; }

        private decimal _totalAmount;
        public decimal totalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                RaisePropertyChanged("totalAmount");
            }
        }


        public RevenuesVM(int f)
        {
            _commands = new CommandMap();
            _commands.AddCommand("search", x => Search(f));
            _commands.AddCommand("print", x => Print(f));


            dtFrom = DateTime.Now.Date;
            dtTo = dtFrom;
            getRevenues(f);
        }


        private void getRevenues(int f)
        {
            IQueryable<Revenue> query;

            if (f == 2)
            {
                query = from r in _pak.revenues
                        where r.bkg_date >= dtFrom.Date && r.bkg_date <= dtTo.Date
                        group r by new { r.pgr_id, r.pgr_name } into g
                        select new Revenue
                        {
                            name = g.Key.pgr_name,
                            number = g.Count(),
                            amount = -1 * g.Sum(x => x.bkg_amount)
                        };

                title = "Umsätze nach Produktgruppe";
                hdrname = "Produktgruppe";
            }
            else
            {
                query = from r in _pak.revenues
                        where r.bkg_date >= dtFrom.Date && r.bkg_date <= dtTo.Date
                        group r by new { r.art_id, r.art_name } into g
                        select new Revenue
                        {
                            name = g.Key.art_name,
                            number = g.Count(),
                            amount = -1 * g.Sum(x => x.bkg_amount)
                        };

                title = "Umsätze nach Artikel";
                hdrname = "Artikel";

            }

            Revenues = new ObservableCollection<Revenue>(query.ToList());
            totalAmount = Revenues.Sum(x => x.amount);
            revView = CollectionViewSource.GetDefaultView(Revenues);

        }

        public void Search(int f)
        {
            getRevenues(f);
        }

        public void Print(int f)
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\Revenue_" + tdy + ".pdf";

            Document doc = new Document(PageSize.A4, 20, 20, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(3);

            //if (f == 2)
            //{
            //    pfilter = "Produktgruppe";
            //}
            //else
            //{
            //    pfilter = "Artikel";
            //}

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase(hdrname));
            cell.HorizontalAlignment = 0;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Anzahl"));
            cell.HorizontalAlignment = 2;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Betrag (EUR)"));
            cell.HorizontalAlignment = 2;
            cell.Padding = 4;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);
            // define header row
            table.HeaderRows = 1;

            foreach (var rev in Revenues)
            {
                cell = new PdfPCell(new Phrase(rev.name));
                cell.HorizontalAlignment = 0;
                cell.Padding = 4;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(rev.number.ToString()));
                cell.HorizontalAlignment = 2;
                cell.Padding = 4;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(rev.amount.ToString()));
                cell.HorizontalAlignment = 2;
                cell.Padding = 4;
                table.AddCell(cell);
            }

            //Title
            ptitle = "Umsätze nach " + hdrname + " vom " + dtFrom.ToShortDateString() + " bis " + dtTo.ToShortDateString();
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
            // total amount
            PdfPTable t3 = new PdfPTable(3);
            cell = new PdfPCell(new Phrase("Umsätze Total (EUR):"));
            cell.HorizontalAlignment = 0;
            cell.Colspan = 2;
            cell.Border = PdfPCell.NO_BORDER;
            t3.AddCell(cell);
            cell = new PdfPCell(new Phrase(totalAmount.ToString()));
            cell.HorizontalAlignment = 2;
            cell.Border = PdfPCell.NO_BORDER;
            t3.AddCell(cell);
            doc.Add(t3);

            // finsish and open
            doc.Close();
            System.Diagnostics.Process.Start(filename);
            

        }

    }
}
