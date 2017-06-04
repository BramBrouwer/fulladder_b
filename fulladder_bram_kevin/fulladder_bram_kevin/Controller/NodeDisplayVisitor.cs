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
        /*
            Base label reference so general label properties can be easily changed
        */
        public Label getBaseLabel()
        {
            Brush b = Brushes.Black;
            Label label = new Label();
            label.Height = 50;
            label.Width = 100;
            label.BorderBrush = b;
            label.BorderThickness = new System.Windows.Thickness(1);
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            return label;
        }

        public Object visit(NOR nor, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "NOR";     
            return label;
        }

        public Object visit(Input input, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "Input";
            return label;
        }

        public Object visit(Probe probe, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "Probe";
            return label;
        }

        public Object visit(XOR xor, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "XOR";
            return label;
        }

        public Object visit(OR or, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "OR";
            return label;
        }

        public Object visit(NOT not, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "NOT";
            return label;
        }

        public Object visit(NAND nand, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "NAND";
            return label;
        }

        public Object visit(AND and, string s)
        {
            Label label = getBaseLabel();
            label.Content = s + " - " + "AND";
            return label;
        }
    }
}
