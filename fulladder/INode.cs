using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder
{
    public abstract class INode
    {

        private int value;
        private String identifier;
        private List<String> edges;

        public List<string> Edges
        {
            get
            {
                return edges;
            }

        }

        public string Identifier
        {
            get
            {
                return identifier;
            }

            set
            {
                identifier = value;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public void addEdge(String edge)
        {
            if(this.edges == null)
            {
                edges = new List<string>();
            }
            edges.Add(edge);
        }


        
    }

}
