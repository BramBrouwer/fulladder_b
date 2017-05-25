using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    class OR : Node
    {
        public override void Run()
        {
            if (base.inputs.Count == 2)
            {
                int count = 0;
                foreach (int value in base.inputs)
                {
                    count = count + value;
                }
                if (count == 0)
                {
                    base.output = 0;
                }
                else
                {
                    base.output = 1;
                }
                foreach(Node next in base.nexts)
                {
                    next.inputs.Add(base.output);
                }
                
            }
            else
            {
                Console.WriteLine(base.inputs.Count + " is no valid input amount for an OR Node");
            }
        }
    }
}

