﻿using fulladder_bram_kevin.Controller;
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

namespace fulladder_bram_kevin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController mainController;
        public MainWindow()
        {
            InitializeComponent();
            mainController = new MainController(this);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainController.openFile(false);
        }

        private void logBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            logBody.ScrollToEnd();            
        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mainController.run();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mainController.edit();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mainController.reload();
        }
    }
}
