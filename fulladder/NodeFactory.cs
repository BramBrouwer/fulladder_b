using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder
{
    class NodeFactory
    {
        private Dictionary<String, Type> _types;

        public void AddNodeType(string name, Type type)
        {
            _types[name] = type;
        }

        //public INode CreateNode(string type, String identifier)
        //{
        //    Type t = _types[type];
        //    INode n = new INode();
        //}
    }
}
