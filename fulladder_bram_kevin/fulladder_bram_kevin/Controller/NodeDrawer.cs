using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace fulladder_bram_kevin.Controller
{
    class NodeDrawer
    {
        private Canvas mainCanvas;
        private int nodeAmount;     //Keep track of how many nodes weve drawn so we know where to draw

        public NodeDrawer(Canvas mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            drawBaseNode();
        }


        public void drawBaseNode()
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 50;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = "Node 1" + System.Environment.NewLine + "  AND";
            label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            mainCanvas.Children.Add(label);
            Canvas.SetTop(label, 100);
            Canvas.SetLeft(label, 100);
            Canvas.SetTop(label, 200);
            Canvas.SetLeft(label, 200);
        }



    }
}
