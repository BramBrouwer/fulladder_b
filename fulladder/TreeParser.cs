using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fulladder
{
    class TreeParser
    {
        private string[] lines;
        private Dictionary<String,String> nodes;
        private List<String> edges;

        public bool readFile(String fileLocation)
        {
            bool success = false;
            try {
                lines = System.IO.File.ReadAllLines(fileLocation);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input file, please check file location and try again.");
            }
          
            return success;
        }

        public void filterLines()
        {
            nodes = new Dictionary<string, string>();
            int i = 0;
            foreach (string line in lines)
            {
                

                /* Are we currently in the nodes, edges or an irrelevant part of the document? */
                if (line.Contains("nodes"))
                {
                    i = 1;
                    continue;
                }
                else if (line.Contains("edges"))
                {
                    i = 2;
                    continue;
                }else if (!line.EndsWith(";"))
                {
                    /* a line that does not indicate the start of node or edge description.
                    Make sure to ignore this line fully so we dont try to add empty/comment lines to our nodes/edges list*/
                    continue;
                }

                switch (i){
                    case 0:
                        //Unimportant lines
                        break;
                    case 1:
                        //Node description
                        string[] nodeParts = line.Split(':');
                        string replacement_n = Regex.Replace(nodeParts[1], @"\r|\n|\t|\;", "");
                        nodes.Add(nodeParts[0], replacement_n);
                        break;
                    case 2:
                        //Edge description
                        string[] edgeParts = line.Split(':');
                        string replacement_e = Regex.Replace(edgeParts[1], @"\r|\n|\t|\;", "");
                        //todo use regex to filter /r from both string parts
                    
                        //seperate targets
                        string[] targets = edgeParts[1].Split(',');

                        nodes.Add(edgeParts[0], replacement_e);



                        break;
                }


            }
        }

       
        public void printLInes() {
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }
        public void printNodes()
        { 
            foreach (KeyValuePair<string, string> entry in nodes)
            {
                // do something with entry.Value or entry.Key
                Console.WriteLine("\t" + "Node descriptor: "+entry.Key + " Node type: "+entry.Value);

            }


        }
    }
}
