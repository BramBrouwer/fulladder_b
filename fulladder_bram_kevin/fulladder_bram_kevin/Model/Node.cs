using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    public abstract class Node
    {
        public List<int> inputs = new List<int>();
        public int output;
        public List<Node> nexts = new List<Node>();

        public abstract void Run();
    }
}
