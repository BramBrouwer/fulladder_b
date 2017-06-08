using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Controller
{
    class CircuitBuilder
    {
        private Dictionary<string, Node> _nodes;
        private NodeFactory _factory;
        private TextBox logBody;

        public CircuitBuilder(NodeFactory nodeFactory,TextBox logBody)
        {
            _factory = nodeFactory;
            _nodes = new Dictionary<string, Node>();
            this.logBody = logBody;
        }

        public Dictionary<string,Node> getNodes()
        {
            return _nodes;
        }

        public void CreateAllNodes(Dictionary<string, string> nodesToBuild)
        {
            _nodes.Clear();
            foreach (KeyValuePair<string, string> nodeString in nodesToBuild)
            {
                Node node = _factory.CreateNode(nodeString.Value);
                _nodes.Add(nodeString.Key, node);
            }
        }

        public Dictionary<String,Node> CreateCircuit(Dictionary<string, string> edges)
        {

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
            logBody.AppendText("Validating circuit" + System.Environment.NewLine + "-" + System.Environment.NewLine);
            bool circuitIsValid = true;
            foreach (KeyValuePair<string, Node> node in _nodes)
            {
                if(node.Value.GetType() != typeof(Probe))
                {                
                    if (node.Value.nexts.Count == 0)
                    {
                        logBody.AppendText("Circuit is invalid. Non-output node found without a next."+System.Environment.NewLine);
                        return false;
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
                                logBody.AppendText("Circuit is invalid, infinite loop found." + System.Environment.NewLine);
                                currents.Clear();
                                return false;
                            }
                        }
                    }
                }
                foreach (KeyValuePair<string, Node> node in _nodes)
                {
                    if (node.Value.GetType() != typeof(Input))
                    {
                        node.Value.inputs.Clear();
                    }
                        
                    node.Value.output = 2;
                }
            }
            logBody.AppendText("Circuit is valid." + System.Environment.NewLine);
            return circuitIsValid;
        }
    }
}
