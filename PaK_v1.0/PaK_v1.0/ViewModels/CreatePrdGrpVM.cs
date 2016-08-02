using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PaK_v1._0.utilities;
using PaK_v1._0.Models;

namespace PaK_v1._0.ViewModels
{
    class CreatePrdGrpVM : VMBase, IDataErrorInfo
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

        private string _prdgrp;
        public string PrdGrp
        {
            get { return _prdgrp; }
            set
            {
                _prdgrp = value;
                RaisePropertyChanged("PrdGrp");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            { _status = value; RaisePropertyChanged("Status"); }
        }

        private Brush _fgcolor;
        public Brush FgColor
        {
            get { return _fgcolor; }
            set { _fgcolor = value; RaisePropertyChanged("FgColor"); }
        }


        public CreatePrdGrpVM()
        {
            Status = "";
            _commands = new CommandMap();
            _commands.AddCommand("add", x => Add());

        }

        public void Add()
        {
            // validation
            if (PrdGrp == null || PrdGrp == "")
            {
                FgColor = Brushes.Crimson;
                Status = "Der Produktgruppenname muss angegeben werden.";
                return;
            }

            try
            {
                var mprdgrp = new prod_grp();
                mprdgrp.pgr_name = PrdGrp;
                _pak.prod_grp.AddObject(mprdgrp);
                _pak.SaveChanges();
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status = "Produktgruppe konnte nicht gepeichert werden: " + ex.Message;
                return;
            }

            FgColor = Brushes.DeepSkyBlue;
            Status = "Produktgruppe erfolgreich angelegt.";
        }


        public string Error
        {
            get { return null; }
        }

        public string this[string fieldName]
        {
            get
            {
                if (fieldName == "PrdGrp")
                {
                    return string.IsNullOrEmpty(PrdGrp) ? "Angabe erforderlich" : null;
                }

                return null;
            }
        }
    }
}
