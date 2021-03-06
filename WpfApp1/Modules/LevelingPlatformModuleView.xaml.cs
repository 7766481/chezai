﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Modules
{
    /// <summary>
    /// LevelingPlatformModuleView.xaml 的交互逻辑
    /// </summary>
    public partial class LevelingPlatformModuleView : BaseModuleView
    {
        public LevelingPlatformModuleView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (messageSender != null)
            {
                messageSender("Home");
            }
        }

    }
}
