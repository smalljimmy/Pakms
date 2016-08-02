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
    class EditPrdGrpVM : VMBase, IDataErrorInfo
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

        private ObservableCollection<prod_grp> _prdgrpsrc;
        public ObservableCollection<prod_grp> PrdGrpSrc
        {
            get { return _prdgrpsrc; }
            set
            {
                _prdgrpsrc = value;
                RaisePropertyChanged("PrdGrpSrc");
            }
        }

        public int _prdgrpid;
        public int ProdGrpId {
            get { return _prdgrpid; }
            set
            {
                _prdgrpid = value;
                PrdGrp = _pak.prod_grp.Single(g => g.pgr_id == _prdgrpid).pgr_name;
                RaisePropertyChanged("ProdGrpId");
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

        public EditPrdGrpVM()
        {
            Status = "";
            PrdGrpSrc = new ObservableCollection<prod_grp>(_pak.prod_grp);
            ProdGrpId = _pak.prod_grp.OrderBy(g => g.pgr_name).First().pgr_id;
            _commands = new CommandMap();
            _commands.AddCommand("save", x => Save());

        }

        public void Save()
        {
            // validation
            if (PrdGrp == null || PrdGrp == "")
            {
                FgColor = Brushes.Crimson;
                Status = "Der Produktgruppenname darf nicht leer sein.";
                return;
            }

            try
            {
                var mprdgrp = _pak.prod_grp.Single(g => g.pgr_id == ProdGrpId);
                mprdgrp.pgr_name = PrdGrp;
                _pak.SaveChanges();
                
            }
            catch (Exception ex)
            {
                FgColor = Brushes.Crimson;
                Status = "Produktgruppe konnte nicht gepeichert werden: " + ex.Message;
                return;
            }

            FgColor = Brushes.DeepSkyBlue;
            Status = "Produktgruppe erfolgreich gespeichert.";



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
