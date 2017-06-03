using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;
using fulladder_bram_kevin.Controller;
using System.Windows.Controls;

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
        private State currentState;

        public Circuit(Dictionary<string,Node> _nodes)
        {
            this._nodes = _nodes;
            currentState = null;
        }

        public void set_state(State s)
        {
            currentState = s;
        }

        internal void run(TextBox logBody)
        {

            this.currentState.run(this, logBody);
        }


        /*
        //Run circuit 
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
                    currents = nexts;
                    nexts.Clear();
                }
            }
        }
        Console.WriteLine("---------------OUTPUT--------------");
        foreach (KeyValuePair<string, Node> node in _nodes)
        {
            if (node.Value.GetType() == typeof(Probe))
            {
                Console.WriteLine("Probe: "+node.Key+" output: "+node.Value.output);
            }
        }
        Console.WriteLine("-----------------------------------");
       */



    }
}
