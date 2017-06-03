using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;

namespace fulladder_bram_kevin.Model
{
    /*
    Lazy instantiation - circuit wordt pas geinstatiate wanneer nodig
    globaal beschikbaar 
    1 instance mogelijk (nog steeds uit te breiden, al zou je circuits willen koppelen kun je dit ergens anders doen en deze aan elkaar koppelen. 
    */

    class Circuit
    {
        public Dictionary<string, Node> _nodes;
        private static Circuit instance;
        private Circuit() { }

        public static Circuit Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Circuit();
                }
                return instance;
            }

        }


        public void run()
        {
            //Run circuit 
            Console.WriteLine("---------------RUN--------------");
            foreach (KeyValuePair<string, Node> node in _nodes)
            {
                if(node.Value.GetType() == typeof(Input))
                {
                    List<Node> currents = new List<Node>();
                    List<Node> nexts = new List<Node>();
                    currents.Add(node.Value);

                    while(currents.Count != 0)
                    {
                        foreach (Node current in currents)
                        {
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
                }
            }
            Console.WriteLine("---------------OUTPUT--------------");
            foreach (KeyValuePair<string, Node> node in _nodes)
            {
                if (node.Value.GetType() == typeof(Probe))
                {
                    Console.WriteLine("Probe: " + node.Key + " output: " + node.Value.output);
                }
            }
            Console.WriteLine("-----------------------------------");
            foreach (KeyValuePair<string, Node> node in _nodes)
            {
                if (node.Value.GetType() != typeof(Input))
                {
                    node.Value.inputs.Clear();
                }
                node.Value.output = 2;
            }

        }
    }
}
