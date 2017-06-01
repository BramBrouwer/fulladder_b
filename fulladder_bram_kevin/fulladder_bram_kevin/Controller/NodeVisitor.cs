using fulladder_bram_kevin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Controller
{
    /*
        Interface to represent nodevisitor

    */
    public interface NodeVisitor
    {
        //Visit for each node type
        Label visit(AND and, String s);
        Label visit(NAND nand, String s);
        Label visit(NOR nor, String s);
        Label visit(NOT not, String s);
        Label visit(Input input, String s);
        Label visit(OR or, String s);
        Label visit(Probe probe, String s);
        Label visit(XOR xor, String s);
            
    }
}
