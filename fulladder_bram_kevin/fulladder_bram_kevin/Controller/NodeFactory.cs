using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;

namespace fulladder_bram_kevin.Controller
{
    class NodeFactory
    {
        private Dictionary<string, Type> _types;

        public NodeFactory()
        {
            _types = new Dictionary<string, Type>();
            AddNodeType("INPUT_HIGH", typeof(Input));
            AddNodeType("INPUT_LOW", typeof(Input));
            AddNodeType("PROBE", typeof(Probe));
            AddNodeType("AND", typeof(AND));
            AddNodeType("NAND", typeof(NAND));
            AddNodeType("NOR", typeof(NOR));
            AddNodeType("NOT", typeof(NOT));
            AddNodeType("OR", typeof(OR));
            AddNodeType("XOR", typeof(XOR));
        }

        public void AddNodeType(string name, Type type)
        {
            _types[name] = type;
        }

        public Node CreateNode(string type)
        {
            Type t = _types[type];
            Node node = (Node)Activator.CreateInstance(t);
            return node;
        }
    }
}
