using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;
using System.Data.Objects;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace PaK_v1._0.ViewModels
{
    class AcctVM : VMBase
    {

        private PaKEntities _pak;
        private CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;

        private ObservableCollection<accounts> _accounts;

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }


        public ObservableCollection<accounts> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
            }
        }


/*        private CollectionViewSource _accts;
        public CollectionViewSource Accts
        {
            get { return _accts; }
            set
            {
                _accts = value;
                RaisePropertyChanged("Accts");
            }
        }
*/

        private accounts _account;
        public accounts lAccount
        {
            get
            {
                if (_account == null)
                {
                    _account = new accounts();
                }

                return _account;
            }
            set
            {
                _account = value;
                RaisePropertyChanged("lAccount");
            }
        }

        private pers_data _persdata;
        public pers_data lPersData
        {
            get
            {
                //if (_persdata == null)
                //{
                //    _persdata = new pers_data();
                //}

                return _persdata;
            }
            set
            {
                _persdata = value;
                RaisePropertyChanged("lPersData");
            }
        }

        private ObservableCollection<ServiceItemEntry> _svclist;
        public ObservableCollection<ServiceItemEntry> SvcList
        {
            get { return _svclist; }
            set
            {
                _svclist = value;
                RaisePropertyChanged("SvcList");
            }
        }

        private accounts _selectedAccount;
        public accounts selectedAccount
        {
            get
            {
                return _selectedAccount;
            }

            set
            {
                _selectedAccount = value;
                TabSelected = true;
                if (_selectedAccount != null)
                {
                    lAccount = _selectedAccount;
                    AcctState = (selectedAccount.ast_id == null) ? 1 : (int)selectedAccount.ast_id;
                    AcctVisible = true;
                    //if (lAccount.pers_data != null)
                    //{
                    // init svc tab
                    //lPersData = lAccount.pers_data;

                    //var _items = (from item in _pak.pers_svc
                    //              select new ServiceItemEntry()
                    //              {
                    //                  Svc = item,
                    //                  IsSelected = _pak.c_pers_data_svc.Any(x => x.act_id == selectedAccount.act_id && x.svc_id == item.svc_id)
                    //              }).ToList();

                    //SvcList = new ObservableCollection<ServiceItemEntry>(_items);
                    //SvcVisible = true;
                    //Duedo_Visible = true;
                    //}
                    //else
                    //{
                    //SvcVisible = false;
                    //Duedo_Visible = false;
                    //lPersData = new pers_data();
                    //}
                    Status = "";
                }
                else
                {
                    TabSelected = false;
                    AcctVisible = false;
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        private System.Windows.Media.Brush _fgcolor;
        public System.Windows.Media.Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }

        private string _status2;
        public string Status2
        {
            get { return _status2; }
            set
            {
                _status2 = value;
                RaisePropertyChanged("Status2");
            }
        }

        private System.Windows.Media.Brush _fgcolor2;
        public System.Windows.Media.Brush FgColor2
        {
            get { return _fgcolor2; }
            set { _fgcolor2 = value; RaisePropertyChanged("FgColor2"); }
        }

        private string _st;
        public string ST
        {
            get { return _st; }
            set
            {
                _st = value;
                RaisePropertyChanged("ST");
            }
        }

        private ICollectionView _accountsview;
        public ICollectionView accountsView 
        {
            get { return _accountsview;  }
            set
            {
                _accountsview = value;
                RaisePropertyChanged("accountsView");
            }
        }


        private bool _duedo_visible;
        public bool Duedo_Visible
        {
            get { return _duedo_visible; }
            set
            {
                _duedo_visible = value;
                if (_duedo_visible == false)
                    Duedo_Checked = false;
                RaisePropertyChanged("Duedo_Visible");
            }
        }

        private bool _duedo_checked;
        public bool Duedo_Checked
        {
            get { return _duedo_checked; }
            set
            {
                _duedo_checked = value;
                RaisePropertyChanged("Duedo_Checked");
            }
        }

        private int _selected_status;
        public int AcctState
        {
            get { return _selected_status; }
            set
            {
                _selected_status = value;
                if (_selected_status == 1 || _selected_status == 2 || _selected_status == 3)
                {
                    if (lPersData == null)
                    {
                        lPersData = new pers_data();
                        lPersData.act_id = lAccount.act_id;
                        Duedo_Checked = false;
                    }
                    else
                    {
                        Duedo_Checked = lPersData.pdt_duedo_tax;
                    }
                    Duedo_Visible = true;
                    SvcVisible = true;

                    // init svc tab
                    lPersData = lAccount.pers_data;

                    var _items = (from item in _pak.pers_svc
                                    select new ServiceItemEntry()
                                    {
                                        Svc = item,
                                        IsSelected = _pak.c_pers_data_svc.Any(x => x.act_id == selectedAccount.act_id && x.svc_id == item.svc_id)
                                    }).ToList();

                    SvcList = new ObservableCollection<ServiceItemEntry>(_items);

                }
                else
                {
                    //lPersData = null;
                    Duedo_Visible = false;
                    SvcVisible = false;
                }

                RaisePropertyChanged("AcctState");
            }
        }

        private bool _svcvisible;
        public bool SvcVisible
        {
            get { return _svcvisible; }
            set
            {
                _svcvisible = value;
                RaisePropertyChanged("SvcVisible");
            }
        }

        private bool _acctvisible;
        public bool AcctVisible
        {
            get { return _acctvisible; }
            set
            {
                _acctvisible = value;
                RaisePropertyChanged("AcctVisible");
            }
        }
        
        private bool _tabselected;
        public bool TabSelected
        {
            get { return _tabselected; }
            set
            {
                _tabselected = value;
                RaisePropertyChanged("TabSelected");
            }
        }

        private ObservableCollection<acct_status> _acctstates;

        public ObservableCollection<acct_status> AcctStates
        {
            get
            {
                if (_acctstates == null)
                    _acctstates = new ObservableCollection<acct_status>(_pak.acct_status);
                return _acctstates;
            }

        }

        private ObservableCollection<nations> _nations;
        public ObservableCollection<nations> Nations
        {
            get
            {
                if (_nations == null)
                    _nations = new ObservableCollection<nations>(_pak.nations);
                return _nations;
            }
        }

        private ObservableCollection<rooms> _rooms;
        public ObservableCollection<rooms> Rooms
        {
            get
            {
                if (_rooms == null)
                    _rooms = new ObservableCollection<rooms>(_pak.rooms.OrderBy(r => r.room_number));
                return _rooms;
            }
        }

        /*
        private rooms _room;
        public rooms Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RaisePropertyChanged("Room");
            }
        }
         */

        private ObservableCollection<rental_tariffs> _tariffs;
        public ObservableCollection<rental_tariffs> Tariffs
        {
            get
            {
                if (_tariffs == null)
                    _tariffs = new ObservableCollection<rental_tariffs>(_pak.rental_tariffs.OrderBy(x => x.tar_order));
                return _tariffs;
            }
        }
        /*
        private rental_tariffs _tariff;
        public rental_tariffs Tariff
        {
            get { return _tariff; }
            set
            {
                _tariff = value;
                RaisePropertyChanged("Tariff");
            }
        }
        */

        private readonly DelegateCommand _searchCommand;
        public DelegateCommand SearchCommand { get { return _searchCommand; } }

        

        public AcctVM() : this(1) { }

        public AcctVM(int filter)
        {
            _pak = new PaKEntities();

            ST = "Suchtext eingeben";
             
            Accounts = getaccts(filter);
            if (Accounts.Count > 0)
            {
                selectedAccount = Accounts.First();
                //AcctState = (selectedAccount.ast_id == null) ? 1 : (int)selectedAccount.ast_id;
                AcctVisible = true;
                 
                if (lPersData != null)
                {
                    Duedo_Checked = lPersData.pdt_duedo_tax;
                    SvcVisible = true;
                }
                else
                {
                    SvcVisible = false;
                }

            }
            else  // tbd: delete?
            {
                SvcVisible = false;
                AcctVisible = false;
            }
             
            accountsView = CollectionViewSource.GetDefaultView(Accounts);

            _commands = new CommandMap();
            _commands.AddCommand("saveacct", (o) => saveacct());
            _commands.AddCommand("savepers", (o) => savepers());
            //_commands.AddCommand("search", (o) => search());
            _commands.AddCommand("emptybox", (o) => emptybox());
            _commands.AddCommand("print", (o) => print());
            _commands.AddCommand("printQ", (o) => printQ());
            _searchCommand = new DelegateCommand(search, null);
        }

        private ObservableCollection<accounts> getaccts(int filter)
        {

            switch (filter)
            {
                case 1: // all with a tariff (: tariff_id != 900 )
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true && a.tariff_id != 900).OrderBy(o => o.act_pseudonym));
                case 2: // only hotel
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true && (a.tariff_id == 901 || a.tariff_id == 902 )).OrderBy(o => o.act_lastname));
                case 3: // away (: tariff_id == 900)
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true && a.tariff_id == 900).OrderBy(o => o.act_pseudonym));
                case 4: 
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true).OrderBy(o => o.act_pseudonym));
                case 5: // only block (: tariff_id != 900 && balance < 0)
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true && a.tariff_id != 900 && a.act_balance < 0).OrderBy(o => o.act_pseudonym));
                case 6: // inactive (: tariff_id == 900)
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == false).OrderBy(o => o.act_lastname));
                default:
                    return new ObservableCollection<accounts>(_pak.accounts.Where(a => a.act_active == true).OrderBy(o => o.act_pseudonym));
            }
        }

        /*
        private void refreshview()
        {
            _accts = new CollectionViewSource();

            _accts.Source = new AutoRefreshWrapper<Models.accounts>(db.accounts, RefreshMode.StoreWins);

            switch (filter)
            {
                case 1:
                    _accts.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    _accts.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = account.act_active;
                    };
                    break;
                case 2:
                    _accts.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    _accts.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = account.act_balance < 0;
                    };
                    break;
                case 3:
                    _accts.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    break;
                case 4:
                    _accts.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    _accts.Filter += (s, ev) =>
                    {
                        accounts account = ev.Item as accounts;
                        ev.Accepted = !account.act_active;
                    };
                    break;
                default:
                    _accts.Source = new AutoRefreshWrapper<accounts>(db.accounts, RefreshMode.StoreWins);
                    break;
            }
        }*/

        public void print()
        {
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();
            keys.Add(new KeyValuePair<string, string>("name", lAccount.act_firstname + " " + lAccount.act_lastname));
            keys.Add(new KeyValuePair<string, string>("passport", lAccount.act_passport_id));
            keys.Add(new KeyValuePair<string, string>("pseudonym", lAccount.act_pseudonym));
            keys.Add(new KeyValuePair<string, string>("nationality", lAccount.nations.nation));
            keys.Add(new KeyValuePair<string, string>("birthday", lAccount.act_birthday.ToString()));
            keys.Add(new KeyValuePair<string, string>("birthplace", lAccount.act_birthplace));
            keys.Add(new KeyValuePair<string, string>("address", lAccount.act_address));
            keys.Add(new KeyValuePair<string, string>("zipcity", lAccount.act_zip + " " + lAccount.act_city));
            keys.Add(new KeyValuePair<string, string>("account", lAccount.act_id.ToString()));
            string target = "Personalbogen_" + lAccount.act_id.ToString() + ".pdf";
            PDFTemplate.ReplacePdfForm(keys, "personalbogen_tpl.pdf", target);
            System.Diagnostics.Process.Start(appRootDir + "\\pdf\\" + target);

        }

        public void printQ()
        {
            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            List<string> PDFs = new List<string>();

            List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();
            keys.Add(new KeyValuePair<string, string>("name", lAccount.act_firstname + " " + lAccount.act_lastname));
            keys.Add(new KeyValuePair<string, string>("passport", lAccount.act_passport_id));
            keys.Add(new KeyValuePair<string, string>("pseudonym", lAccount.act_pseudonym));
            keys.Add(new KeyValuePair<string, string>("nationality", lAccount.nations.nation));
            keys.Add(new KeyValuePair<string, string>("birthday", lAccount.act_birthday.HasValue ? lAccount.act_birthday.Value.ToShortDateString() : "" ));
            keys.Add(new KeyValuePair<string, string>("birthplace", lAccount.act_birthplace));
            keys.Add(new KeyValuePair<string, string>("address", lAccount.act_address));
            keys.Add(new KeyValuePair<string, string>("zipcity", lAccount.act_zip + " " + lAccount.act_city));
            keys.Add(new KeyValuePair<string, string>("account", lAccount.act_id.ToString()));
            keys.Add(new KeyValuePair<string, string>("phone", lAccount.act_phone.ToString()));

            string pdf1 = "fragebogen_tmp.pdf";
            PDFTemplate.ReplacePdfForm(keys, "personalfragebogen_tpl.pdf", pdf1);
            PDFs.Add(appRootDir + "\\pdf\\" + pdf1);

            string pdf2 = "services_tmp.pdf";

            string filename = Path.Combine(appRootDir + "\\pdf", pdf2);

            Document doc = new Document(PageSize.A4, 60, 20, 40, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();
            
            
            // layout
            doc.Add(new Paragraph(new Phrase("Meine Services")));
            doc.Add(new Paragraph(new Phrase(" ")));

            // fake checkbox
            PdfTemplate template = wri.DirectContent.CreateTemplate(20, 20);   //.getDirectContent().createTemplate(120, 80);
            template.Rectangle(5, 3, 11, 11);    //.rectangle(0, 0, 120, 80);
            template.SetColorFill(BaseColor.WHITE);
            //template.Fill();
            template.SetColorStroke(BaseColor.BLACK);
            template.FillStroke();
            wri.ReleaseTemplate(template); //releaseTemplate(template);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(template);


            PdfPTable table = new PdfPTable(6);
            table.TotalWidth = 570f;
            table.LockedWidth = true;
            float[] widths = new float[] { 40f, 120f, 40f, 120f, 40f, 120f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 1;

            //PdfPCell cell = new PdfPCell();

            
            foreach (var svc in SvcList)
            {
                // fake check box
                PdfPCell cell1 = new PdfPCell(img);
                cell1.Border = PdfPCell.NO_BORDER;
                cell1.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell1);
                // service
                PdfPCell cell = new PdfPCell(new Phrase(svc.Svc.svc_name));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 4;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

            }

           
            doc.Add(table);
            doc.Add(new Paragraph(new Phrase(" ")));
            doc.Add(new Paragraph(new Phrase(" ")));
            doc.Add(new Paragraph(new Phrase(" ")));


            // add a new table for Check-in by / Signature
            PdfPTable t2 = new PdfPTable(5);
            //t2.TotalWidth = 400f;
            //t2.LockedWidth = true;
            //float[] widths2 = new float[] { 60f, 120f, 40f, 60f, 120f };
            //t2.SetWidths(widths2);
            // add cells
            PdfPCell c2 = new PdfPCell(new Phrase("Check-In bei: "));
            c2.Border = PdfPCell.NO_BORDER;
            t2.AddCell(c2);
            c2 = new PdfPCell(new Phrase(customPrincipal.Identity.Name));
            c2.Border = PdfPCell.NO_BORDER;
            t2.AddCell(c2);
            c2 = new PdfPCell(new Phrase(" "));
            c2.Border = PdfPCell.NO_BORDER;
            t2.AddCell(c2);
            c2 = new PdfPCell(new Phrase("Unterschrift:"));
            c2.Border = PdfPCell.NO_BORDER;
            t2.AddCell(c2);
            c2 = new PdfPCell(new Phrase(" "));
            c2.Border = PdfPCell.BOTTOM_BORDER;
            t2.AddCell(c2);
            doc.Add(t2);
            

            doc.Close();

            PDFs.Add(appRootDir + "\\pdf\\" + pdf2);

            string pdf = "fragebogen_" + lAccount.act_id.ToString() + ".pdf";

            PDFTemplate.MergeFiles(appRootDir + "\\pdf\\" + pdf, PDFs);

            System.Diagnostics.Process.Start(appRootDir + "\\pdf\\" + pdf);


        }


        public void saveacct()
        {

            lAccount.ast_id = AcctState;

            if (lAccount.ast_id == 1 || lAccount.ast_id == 2 || lAccount.ast_id == 3) //MIETERIN/TABLE DANCE/CLUB 11
            {
                if (lPersData == null) // if pers_data does not exist yet, we have to add it
                {
                    lPersData = new pers_data();
                    lPersData.act_id = lAccount.act_id;
                    lPersData.pdt_duedo_tax = Duedo_Checked;
                    _pak.pers_data.AddObject(lPersData);
                }
                else
                    lPersData.pdt_duedo_tax = Duedo_Checked;
            }

            _pak.SaveChanges();
            FgColor = Brushes.DeepSkyBlue;
            Status = "Daten erfolgreich gespeichert.";
        }

        public void savepers()
        {

            var toDelete = _pak.c_pers_data_svc.Where(w => w.act_id == lAccount.act_id);

            if (toDelete != null)
            {
                foreach (c_pers_data_svc d in toDelete)
                {
                    _pak.c_pers_data_svc.DeleteObject(d);
                }
            }

            foreach (ServiceItemEntry item in SvcList)
            {
                if (item.IsSelected)
                {
                    c_pers_data_svc entry = new c_pers_data_svc();
                    entry.act_id = lAccount.act_id;
                    entry.svc_id = item.Svc.svc_id;

                    _pak.c_pers_data_svc.AddObject(entry);
                }
            }

            _pak.SaveChanges();

            FgColor2 = Brushes.DeepSkyBlue;
            Status2 = "Daten erfolgreich gespeichert.";


            _pak.SaveChanges();
            
        }


        public void search(object parameter)
        {

            KeyEventArgs e = parameter as KeyEventArgs;
            TextBox searchBox = (TextBox)e.OriginalSource;
            string txt = searchBox.Text.ToUpper(); 

            if (Accounts.Count > 0)
            {

                var _faccts = Accounts.Where(a => a.act_lastname.ToUpper().Contains(txt) || a.act_firstname.ToUpper().Contains(txt) || a.act_pseudonym.ToUpper().Contains(txt) || a.rooms.room_number.ToUpper().Contains(txt));

                ObservableCollection<accounts> AcctFiltered = new ObservableCollection<accounts>(_faccts);

                accountsView = CollectionViewSource.GetDefaultView(AcctFiltered);

                if (AcctFiltered.Count > 0)
                {
                    selectedAccount = AcctFiltered.First();
                    AcctVisible = true;
                }
                else
                {
                    selectedAccount = null;
                    AcctVisible = false;
                    //SvcVisible = false;
                }

            }

            return;
        }

        public void emptybox()
        {
            if(ST.ToUpper().Contains("SUCHTEXT"))
                ST = "";
        }


        /*
        public CollectionViewSource accts 
        {
            get { return _accts; }
            set
            {
                _accts = value;
            }

        }
         */

        private int _filter = 1;
        public int filter
        {
            get{return _filter;}
            set { _filter = value;}
        }

    }

    public class ServiceItemEntry
    {
        public pers_svc Svc { get; set; }
        public bool IsSelected { get; set; }
    }
}
