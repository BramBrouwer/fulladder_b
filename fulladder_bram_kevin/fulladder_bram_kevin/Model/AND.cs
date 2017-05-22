using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    class AND : Node
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
                if (count == 2)
                {
                    base.output = 1;
                }
                else
                {
                    base.output = 0;
                }
                base.next.inputs.Add(base.output);
            }
            else
            {
                Console.WriteLine(base.inputs.Count + " is no valid input amount for an AND Node");
            }
        }
    }
}
