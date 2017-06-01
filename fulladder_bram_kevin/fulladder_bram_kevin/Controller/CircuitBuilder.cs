using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;

namespace fulladder_bram_kevin.Controller
{
    class CircuitBuilder
    {
        private Dictionary<string, Node> _nodes;
        private NodeFactory _factory;

        public CircuitBuilder()
        {
            _factory = new NodeFactory();
            _nodes = new Dictionary<string, Node>();
        }

        public Dictionary<string,Node> getNodes()
        {
            return _nodes;
        }

        public void CreateAllNodes(Dictionary<string, string> nodesToBuild)
        {
            //Console.WriteLine("-------------------Create all nodes----------------");
            foreach (KeyValuePair<string, string> nodeString in nodesToBuild)
            {
                //Console.WriteLine("------------------------------------");
                string key = nodeString.Key;
                //Console.WriteLine("key:--" + key + "--");
                string value = nodeString.Value;
                //Console.WriteLine("value:--" + value + "--");
                Node node = _factory.CreateNode(value);
                //Console.WriteLine("Node created");
                _nodes.Add(key, node);
                //Console.WriteLine("Node added");
            }
            //Console.WriteLine("------------------------------------");
        }

        public void CreateCircuit(Dictionary<string, string> edges)
        {
            //Console.WriteLine("-----------------Create circuit-------------------");
            foreach (KeyValuePair<string, string> edge in edges)
            {
                //Console.WriteLine("------------------------------------");
                string key = edge.Key;
                //Console.WriteLine("key: " + key);
                List<string> values = edge.Value.Split(',').ToList();
                //Console.WriteLine("Value list created");
                Node node = _nodes[key];
                //Console.WriteLine("Get node from list");
                foreach (string next in values)
                {
                    //Console.WriteLine("Splitted--" + next + "--");
                    Node nextNode = _nodes[next];
                   // Console.WriteLine("next created");
                    node.nexts.Add(nextNode);
                    //Console.WriteLine("next added");
                }
            }
            //Console.WriteLine("------------------------------------");
            Circuit.Instance._nodes = this._nodes;
        }
    }
}
