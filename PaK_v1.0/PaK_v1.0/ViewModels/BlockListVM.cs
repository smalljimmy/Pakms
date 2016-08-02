using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace PaK_v1._0.ViewModels
{
    class BlockListVM : VMBase
    {
        private PaKEntities _pak;

        private string _today;
        public string Today
        {
            get { return _today; }
            set
            {
                _today = value;
                RaisePropertyChanged("Today");
            }
        }

        private CommandMap _commands;

        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private ICollectionView _blocklist;

        public ICollectionView BlockList
        {
            get { return _blocklist; }
            set
            {
                if (value != _blocklist)
                {
                    _blocklist = value;
                    RaisePropertyChanged("BlockList");
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

        public BlockListVM()
        {
            _pak = new PaKEntities();
            var dv = new ObservableCollection<block_list>(_pak.block_list);
            BlockList = CollectionViewSource.GetDefaultView(dv);
            Today = DateTime.Today.ToLongDateString();
            Title = "Blockliste  Stand " + Today;

            _commands = new CommandMap();
            _commands.AddCommand("print", x => Print());
        }

        public void Print()
        {
            string ptitle = "";
            string tdy = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString();
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filename = appRootDir + "\\pdf\\Blocklist_" + tdy + ".pdf";

            //use small font
            BaseFont bf_normal
                        = BaseFont.CreateFont("c://windows/fonts/arial.ttf",
                            BaseFont.WINANSI, BaseFont.EMBEDDED);
            Font small = new Font(bf_normal, 8);

            Document doc = new Document(PageSize.A4, 0, 0, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(6);

            // column headers:
            PdfPCell cell = new PdfPCell(new Phrase("Zimmer", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Status", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Name", small));
            cell.HorizontalAlignment = 0;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Block", small));
            cell.HorizontalAlignment = 2;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Haben", small));
            cell.HorizontalAlignment = 2;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Tagesrechnung", small));
            cell.HorizontalAlignment = 2;
            cell.Padding = 3;
            cell.BackgroundColor = new BaseColor(211, 211, 211);
            table.AddCell(cell);

            // define header row
            table.HeaderRows = 1;

            foreach (var b in BlockList.Cast<block_list>())
            {
                cell = new PdfPCell(new Phrase(b.room_number, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(b.status, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(b.name, small));
                cell.HorizontalAlignment = 0;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(b.block.ToString(), small));
                cell.HorizontalAlignment = 2;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(b.credit.ToString(), small));
                cell.HorizontalAlignment = 2;
                cell.Padding = 3;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(b.daily_bill.ToString(), small));
                cell.HorizontalAlignment = 2;
                cell.Padding = 3;
                table.AddCell(cell);
            }

            //Title
            ptitle = "Blockliste für: " + Today;
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
