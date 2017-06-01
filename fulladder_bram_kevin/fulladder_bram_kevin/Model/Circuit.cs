using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Model
{
    /*
    Lazy instantiation - circuit wordt pas geinstatiate wanneer nodig
    globaal beschikbaar 
    1 instance mogelijk (nog steeds uit te breiden, al zou je circuits willen koppelen kun je dit ergens anders doen en deze aan elkaar koppelen. 
    */

    class Circuit
    {
        public Dictionary<String, Node> _nodes;
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
        }
    }
}
