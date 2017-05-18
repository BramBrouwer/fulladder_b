using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    public abstract class Node
    {
        public List<int> inputs;
        public int output;
        public Node next;

        public abstract void Run();
    }
}
