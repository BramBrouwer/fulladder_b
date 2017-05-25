using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    class Input : Node
    {
        public override void Run()
        {
            if (base.inputs.Count == 1)
            {
                base.output = base.inputs.First<int>();

                foreach (Node next in base.nexts)
                {
                    next.inputs.Add(base.output);
                }
            }
            else
            {
                Console.WriteLine(base.inputs.Count + " is no valid input amount for an INPUT Node");
            }
        }
    }
}
