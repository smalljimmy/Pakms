using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PaK_v1._0.ViewModels;

//using PaK_v1._0.utilities;

namespace PaK_v1._0.Pages.Content
{
    /// <summary>
    /// Interaction logic for newuser.xaml
    /// </summary>
    public partial class newuser : UserControl
    {
        public newuser()
        {
            InitializeComponent();
            DataContext = new UserNewVM();

            //MultiBinding pwds = new MultiBinding();
            //pwds.Converter = new PwdConverter();
            //Binding p = new Binding();
            //p.ElementName = "passwordBox1";
            //pwds.Bindings.Add(p);
            //Binding p2 = new Binding();
            //p2.ElementName = "passwordBox2";
            //pwds.Bindings.Add(p2);
            //btnSave.SetBinding(Button.CommandParameterProperty, pwds);

        }
    }
}
