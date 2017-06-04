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

        public CircuitBuilder(NodeFactory nodeFactory)
        {
            _factory = nodeFactory;
            _nodes = new Dictionary<string, Node>();
        }

        public Dictionary<string,Node> getNodes()
        {
            return _nodes;
        }

        public void CreateAllNodes(Dictionary<string, string> nodesToBuild)
        {
            _nodes.Clear();

            Console.WriteLine("-------------------Create all nodes----------------");
            foreach (KeyValuePair<string, string> nodeString in nodesToBuild)
            {
                Node node = _factory.CreateNode(nodeString.Value);
                _nodes.Add(nodeString.Key, node);
            }
        }

        public Dictionary<String,Node> CreateCircuit(Dictionary<string, string> edges)
        {
            Console.WriteLine("-----------------Create circuit-------------------");
            foreach (KeyValuePair<string, string> edge in edges)
            {
                string key = edge.Key;
                List<string> values = edge.Value.Split(',').ToList();
                foreach (string next in values)
                {
                    _nodes[key].nexts.Add(_nodes[next]);
                }
            }
            return this._nodes;
        }

        public bool ValidateCircuit()
        {
            Console.WriteLine("---------------Validate--------------");
            bool circuitIsValid = true;
            foreach (KeyValuePair<string, Node> node in _nodes)
            {
                if(node.Value.GetType() != typeof(Probe))
                {                
                    if (node.Value.nexts.Count == 0)
                    {
                        Console.WriteLine("No Next");
                        circuitIsValid = false;
                    }
                }
            }

            if(circuitIsValid)
            {
                int counter = _nodes.Count * _nodes.Count;
                foreach (KeyValuePair<string, Node> node in _nodes)
                {
                    if (node.Value.GetType() == typeof(Input))
                    {
                        if (node.Value.inputIsHigh)
                        {
                            node.Value.inputs.Add(1);
                        }
                        else
                        {
                            node.Value.inputs.Add(0);
                        }

                        List<Node> currents = new List<Node>();
                        List<Node> nexts = new List<Node>();
                        currents.Add(node.Value);

                        while (currents.Count != 0)
                        {
                            if (counter > 0)
                            {
                                foreach (Node current in currents)
                                {
                                    counter--;
                                    current.Run();
                                    foreach (Node next in current.nexts)
                                    {
                                        nexts.Add(next);
                                    }
                                }
                                currents.Clear();
                                foreach (Node next in nexts)
                                {
                                    currents.Add(next);
                                }

                                nexts.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Infinite Loop");
                                circuitIsValid = false;
                                currents.Clear();
                            }
                        }
                    }
                }
                foreach (KeyValuePair<string, Node> node in _nodes)
                {
                    node.Value.inputs.Clear();
                    node.Value.output = 2;
                }
            }
            Console.WriteLine("---------------------------------");
            return circuitIsValid;
        }
    }
}
