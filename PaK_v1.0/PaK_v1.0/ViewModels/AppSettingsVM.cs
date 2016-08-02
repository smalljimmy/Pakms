using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using PaK_v1._0.Models;
using PaK_v1._0.utilities;


namespace PaK_v1._0.ViewModels
{
    class AppSettingsVM : VMBase
    {
        private PaKEntities _pak;

        private CommandMap _commands;
        public CommandMap Commands
        {
            get
            {
                return _commands;
            }
        }

        private string _duedotax;
        public string DuedoTax
        {
            get { return _duedotax; }
            set
            {
                _duedotax = value;
                RaisePropertyChanged("DuedoTax");
            }
        }

        private string _entertainmenttax;
        public string EntertainmentTax
        {
            get { return _entertainmenttax; }
            set
            {
                _entertainmenttax = value;
                RaisePropertyChanged("EntertainmentTax");
            }
        }

        private Brush _fgcolor;
        public Brush FgColor
        {
            get { return _fgcolor; }
            set
            {
                _fgcolor = value;
                RaisePropertyChanged("FgColor");
            }
        }

        private string _status1;
        public string Status1
        {
            get { return _status1; }
            set
            {
                _status1 = value;
                RaisePropertyChanged("Status1");
            }
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

        public AppSettingsVM()
        {
            _pak = new PaKEntities();
            DuedoTax = _pak.settings.FirstOrDefault(s => s.set_key == "DUEDO_TAX").set_value;
            EntertainmentTax = _pak.settings.FirstOrDefault(s => s.set_key == "ENTERTAINMENT_TAX").set_value;

            _commands = new CommandMap();
            _commands.AddCommand("duedo_sav", (o) => duedo_sav());
            _commands.AddCommand("entertainment_sav", (o) => entertainment_sav());

        }

        public void duedo_sav()
        {
            Status2 = "";
            // validate
            if (!Regex.IsMatch(DuedoTax, @"^[0-9]{1,6}([.,][0-9]{1,2})?$"))
            {
                FgColor = Brushes.Crimson;
                Status1 = "Fehler: Der Betrag enthält einen ungültigen Wert.";
                return;
            }

            try
            {
                var amount = Convert.ToDecimal(DuedoTax.Replace(',', '.'));

                var rec = _pak.settings.FirstOrDefault(s => s.set_key == "DUEDO_TAX");
                rec.set_value = amount.ToString();
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status1 = "Fehler: " + ex.Message;
                return;
            }
            FgColor = Brushes.DeepSkyBlue;
            Status1 = "Neuer Wert gespeichert.";

        }

        public void entertainment_sav()
        {
            Status1 = "";
            // validate
            if (!Regex.IsMatch(EntertainmentTax, @"^[0-9]{1,6}([.,][0-9]{1,2})?$"))
            {
                FgColor = Brushes.Crimson;
                Status2 = "Fehler: Der Betrag enthält einen ungültigen Wert.";
                return;
            }

            try
            {
                var amount = Convert.ToDecimal(EntertainmentTax.Replace(',', '.'));

                var rec = _pak.settings.FirstOrDefault(s => s.set_key == "ENTERTAINMENT_TAX");
                rec.set_value = amount.ToString();
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status2 = "Fehler: " + ex.Message;
                return;
            }
            FgColor = Brushes.DeepSkyBlue;
            Status2 = "Neuer Wert gespeichert.";

        }

    }
}
