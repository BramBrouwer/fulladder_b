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
        public NodeDrawer(Grid grid)
        {
            this.grid = grid;
        }


        public void draw(Circuit circuit)
        {
            grid.Children.Clear();
            this.nodeAmount = circuit._nodes.Count;
            grid.Width = (nodeAmount+6) / 3 * 150;

            for (int i = 0; i < (nodeAmount+6) / 3; i++)
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
           
            foreach (KeyValuePair<string, Node> entry in circuit._nodes)
            {
                //Label l = createLabel(entry.Key);
                NodeDisplayVisitor n = new NodeDisplayVisitor();
                Label l = (Label)entry.Value.accept(n, entry.Key);
                Grid.SetRow(l, rowIndex);
                Grid.SetColumn(l, colIndex);
                grid.Children.Add(l);
                if(rowIndex == 2)
                {
                    Grid.SetRow(l, rowIndex);
                    Grid.SetColumn(l, colIndex);
                    colIndex++;
                    rowIndex = 0;
                }
                else
                {
                    Grid.SetRow(l, rowIndex);
                    Grid.SetColumn(l, colIndex);
                    rowIndex++;
                }
            }
        }

        



    }
}
