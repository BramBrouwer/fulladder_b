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
    /*
        Implementatie van de nodevisitor, deze is voor het tekenen van nodes
        Als er node types toegevoegd worden kan de gebruiker hier simpel ook een nieuw uiterlijk toevoegen
        Op het moment wijken de nodes niet heel erg van elkaar af
        Maar de visitor zou er van pas komen als iedere node een aparte/vorm grootte zou hebben
    */
    class NodeDisplayVisitor : NodeVisitor
    {
        public Object visit(NOR nor, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "NOR";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(Input input, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "Input";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(Probe probe, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "Probe";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(XOR xor, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "XOR";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(OR or, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "OR";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(NOT not, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "NOT";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(NAND nand, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "NAND";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }

        public Object visit(AND and, string s)
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.Content = s + System.Environment.NewLine + "AND";
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            return label;
        }
    }
}
