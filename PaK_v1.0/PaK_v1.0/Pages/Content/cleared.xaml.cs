﻿using System;
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

namespace PaK_v1._0.Content
{
    /// <summary>
    /// Interaction logic for cleared.xaml
    /// </summary>
    public partial class cleared : UserControl
    {

        public cleared()
        {
            InitializeComponent();

            ClearedVM vm = new ClearedVM();
            this.DataContext = vm;
        }

    }

}