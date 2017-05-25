using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    class Probe : Node
    {
        public override void Run()
        {
            if (base.inputs.Count == 1)
            {
                base.output = base.inputs.First<int>();
            }
            else
            {
                Console.WriteLine(base.inputs.Count + " is no valid input amount for a PROBE Node");
            }
        }
    }
}
