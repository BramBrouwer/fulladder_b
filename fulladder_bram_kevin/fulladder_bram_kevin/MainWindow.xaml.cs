using fulladder_bram_kevin.Controller;
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
        public MainWindow()
        {
            InitializeComponent();
            NodeDrawer nd = new NodeDrawer(this.mainCanvas,this.grid);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FileReader fr = new FileReader(this.logBody);
            fr.chooseFile();
        }

        private void logBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
