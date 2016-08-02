using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ICP.Controls.PrintableListView
{
    public class PrintableListView : ListView
    {
        #region Properties

        public ReportGroup Group
        {
            get
            {
                return (ReportGroup)this.GetValue(GroupProperty);
            }
            set
            {
                this.SetValue(GroupProperty, value);
            }
        }
        public static DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(ReportGroup), typeof(PrintableListView), new PropertyMetadata());

        public ViewBase ReportBody
        {
            get
            {
                return (ViewBase)this.GetValue(ReportBodyProperty);
            }
            set
            {
                this.SetValue(ReportBodyProperty, value);
            }
        }

        public static DependencyProperty ReportBodyProperty =
            DependencyProperty.Register("ReportBody", typeof(ViewBase), typeof(PrintableListView), new PropertyMetadata());

        public static DependencyProperty myCellTemplatePRICEProperty = DependencyProperty.Register("myCellTemplatePRICE", typeof(DataTemplate), typeof(PrintableListView), new PropertyMetadata());
        public DataTemplate myCellTemplatePRICE
        {
            get
            {
                return (DataTemplate)this.GetValue(myCellTemplatePRICEProperty);
            }
            set
            {
                this.SetValue(myCellTemplatePRICEProperty, value);
            }
        }

        public static DependencyProperty myCellTemplateIDProperty = DependencyProperty.Register("myCellTemplateID", typeof(DataTemplate), typeof(PrintableListView), new PropertyMetadata());
        public DataTemplate myCellTemplateID
        {
            get
            {
                return (DataTemplate)this.GetValue(myCellTemplateIDProperty);
            }
            set
            {
                this.SetValue(myCellTemplateIDProperty, value);
            }
        }

        public DataTemplate PageHeaderTemplate
        {
            get
            {
                return (DataTemplate)this.GetValue(PageHeaderTemplateProperty);
            }
            set
            {
                this.SetValue(PageHeaderTemplateProperty, value);
            }
        }
        public static DependencyProperty PageHeaderTemplateProperty =
            DependencyProperty.Register("PageHeaderTemplate", typeof(DataTemplate), typeof(PrintableListView), new PropertyMetadata());

        public DataTemplate PageFooterTemplate
        {
            get
            {
                return (DataTemplate)this.GetValue(PageFooterTemplateProperty);
            }
            set
            {
                this.SetValue(PageFooterTemplateProperty, value);
            }
        }
        public static DependencyProperty PageFooterTemplateProperty =
            DependencyProperty.Register("PageFooterTemplate", typeof(DataTemplate), typeof(PrintableListView), new PropertyMetadata());

        public Size PageSize
        {
            get
            {
                return (Size)this.GetValue(PageSizeProperty);
            }
            set
            {
                this.SetValue(PageSizeProperty, value);
            }
        }
        public static DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(Size), typeof(PrintableListView), new PropertyMetadata());

        public Thickness PageMargin
        {
            get
            {
                return (Thickness)this.GetValue(PageMarginProperty);
            }
            set
            {
                this.SetValue(PageMarginProperty, value);
            }
        }

        public static DependencyProperty PageMarginProperty =
            DependencyProperty.Register("PageMargin", typeof(Thickness), typeof(PrintableListView), new PropertyMetadata());

        public Size HeaderSize
        {
            get
            {
                return (Size)this.GetValue(HeaderSizeProperty);
            }
            set
            {
                this.SetValue(HeaderSizeProperty, value);
            }
        }
        public static DependencyProperty HeaderSizeProperty =
            DependencyProperty.Register("HeaderSize", typeof(Size), typeof(PrintableListView), new PropertyMetadata());

        public Size FooterSize
        {
            get
            {
                return (Size)this.GetValue(FooterSizeProperty);
            }
            set
            {
                this.SetValue(FooterSizeProperty, value);
            }
        }
        public static DependencyProperty FooterSizeProperty =
            DependencyProperty.Register("FooterSize", typeof(Size), typeof(PrintableListView), new PropertyMetadata());

        public ICommand PrintCommand
        {
            get
            {
                return printCommand;
            }
            set
            {
                printCommand = value;
            }
        }
        private ICommand printCommand;

        #endregion

        #region Constructor

        public PrintableListView()
            : base()
        {
            PrintCommand = new DelegateCommand<object>(print);
        }

        #endregion

        #region Private Members

        private void print(object parameter)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                if (PageSize == null)
                {
                    PageSize = new Size((int)printDialog.PrintableAreaWidth, (int)printDialog.PrintableAreaHeight);
                }
                if (PageMargin == null)
                {
                    PageMargin = new Thickness(20);
                }
                DocumentPaginatorExtention documentPaginatorExtention = new DocumentPaginatorExtention(this, PageMargin, PageSize);
                //DocumentPaginatorExtention documentPaginatorExtention = new DocumentPaginatorExtention(this, new Thickness(20), PageSize);PageMargin
                printDialog.PrintDocument(documentPaginatorExtention, "My Data");
            }
        }

        #endregion
    }
}
