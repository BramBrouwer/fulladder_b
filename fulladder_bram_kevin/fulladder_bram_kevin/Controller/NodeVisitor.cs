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
        Object visit(AND and, String s);
        Object visit(NAND nand, String s);
        Object visit(NOR nor, String s);
        Object visit(NOT not, String s);
        Object visit(Input input, String s);
        Object visit(OR or, String s);
        Object visit(Probe probe, String s);
        Object visit(XOR xor, String s);
            
    }
}
