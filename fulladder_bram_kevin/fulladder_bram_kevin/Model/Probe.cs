using fulladder_bram_kevin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Model
{
    public class Probe : Node
    {

        public Probe()
        {
            base.output = 2;
        }

        public override void Run()
        {
            if (base.inputs.Count == 1)
            {
                if (base.output == 2)
                {
                    base.output = base.inputs.First<int>();
                }
            }
        }
        public override Object accept(NodeVisitor nodeVisitor, String name)
        {
            return nodeVisitor.visit(this, name);
        }
    }
}
