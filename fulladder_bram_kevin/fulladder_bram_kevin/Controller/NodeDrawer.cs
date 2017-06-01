using fulladder_bram_kevin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace fulladder_bram_kevin.Controller
{
    class NodeDrawer
    {
        private Grid grid;
        private int nodeAmount = 30;     //Keep track of how many nodes weve drawn so we know where to draw
        private int col = 0;
        public NodeDrawer(Grid grid)
        {
            this.grid = grid;
        }


        public void draw()
        {
            this.nodeAmount = Circuit.Instance._nodes.Count;
            grid.Width = nodeAmount / 3 * 150;

            for (int i = 0; i < nodeAmount / 3; i++)
            {
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col1);
            }

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(150);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(150);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(150);
            grid.RowDefinitions.Add(gridRow1);
            grid.RowDefinitions.Add(gridRow2);
            grid.RowDefinitions.Add(gridRow3);

            int colIndex = 1;
            int rowIndex = 0;
           
            foreach (KeyValuePair<string, Node> entry in Circuit.Instance._nodes)
            {
                Label l = createLabel(entry.Key);
                Grid.SetRow(l, rowIndex);
                Grid.SetColumn(l, colIndex);
                grid.Children.Add(l);
                colIndex++;
                rowIndex++;
            }
        }


        public void setupGrid()
        { 
            grid.Width = nodeAmount / 3 * 150;

            for(int i = 0; i < nodeAmount / 3; i ++)
            {
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col1);
            }

            // Create Rows
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(150);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(150);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(150);
            grid.RowDefinitions.Add(gridRow1);
            grid.RowDefinitions.Add(gridRow2);
            grid.RowDefinitions.Add(gridRow3);

            addNodesTogrid();
        }

        public Label createLabel(String name)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = name + System.Environment.NewLine + "  AND";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }


        //TODO voeg hier de nodes toe aan de hand van het aantal nodes dat je hebt
        //Inputs op de eerste column
        //Dan iedere keer een node, een row naar beneden, weer een node, nog een keer naar beneden, een columng naar rechts, repeat.

        public void addNodesTogrid()
        {
            for (int i = 0; i < nodeAmount / 3 + 2; i++)
            {
                Brush b = Brushes.Black;
                Label label = new Label();
                label.Height = 50;
                label.Width = 100;
                label.BorderBrush = b;
                label.BorderThickness = new System.Windows.Thickness(1);
                label.Content = "Node 1" + System.Environment.NewLine + "  AND";
                label.HorizontalContentAlignment = HorizontalAlignment.Center;

                Grid.SetRow(label, i);
                Grid.SetColumn(label, i);
                grid.Children.Add(label);
            }

        }



    }
}
