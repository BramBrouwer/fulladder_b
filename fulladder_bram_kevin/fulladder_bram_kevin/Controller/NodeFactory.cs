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
        }

        public void AddNodeType(string name, Type type)
        {
            _types[name] = type;
        }

        public Node CreateNode(string type)
        {
            Type t = _types[type];
            if(t.GetType() == typeof(Input))
            {
                if (type == "INPUT_HIGH")
                {
                    Object[] args = { "input", true };
                    Node node = (Node)Activator.CreateInstance(t, args);
                    return node;
                }
                else
                {
                    Object[] args = { "input", false };
                    Node node = (Node)Activator.CreateInstance(t, args);
                    return node;
                }
            }
            else
            {
                Node node = (Node)Activator.CreateInstance(t);
                return node;
            }
        }
    }
}
