using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fulladder_bram_kevin
{

    //TODO add check if file actually contains a start and end (return false or true in getnodesandedges)
    class FileReader
    {
        private string _filecontents;
        private Dictionary<string, string> _nodes = new Dictionary<string, string>();
        private Dictionary<string, string> _edges = new Dictionary<string, string>();
        private int counter = 0;

        public void chooseFile()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Files (*.txt)|*.txt";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and read all text
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                _filecontents = File.ReadAllText(dlg.FileName);
                readFile();
            }
        }

        public void readFile()
        {
            try
            {
                _nodes.Clear();    //Empty nodes
                _edges.Clear();    //Empty edges
                getNodesAndEdgesFromFile();
                validateEdges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid file");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /*
            Get all the nodes and edges given in the text file and add them to _nodes and _edges dictionary
        */
        private void getNodesAndEdgesFromFile()
        {
            //Split file /n to seperate all lines
            string[] allLines = _filecontents.Split('\n');         
            foreach (string line in allLines)
            {   
                //Remove all whitespaces, tabs, carriage returns, line feed and ;
                string i = line.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace(";", "");
                
                //If we have something left line isnt empty
                if (i != string.Empty)                              
                {
                    //If line is not a comment
                    if (i.ToCharArray()[0] != '#')                  
                    {
                        //Seperate name and value
                        string[] s = i.Split(':');                  
                        if (_nodes.ContainsKey(s[0]))
                        {
                            //dealing with an edge
                            _edges.Add(s[0], s[1]);
                        }
                        else
                        {
                            //dealing with a node
                            _nodes.Add(s[0], s[1]);
                        }

                    }
                }
            }
        }

        private void validateEdges()
        {
            Dictionary<string, string[]> d = new Dictionary<string, string[]>();

            foreach (var i in _edges)
            {
                //TODO check what this looks like in debugger
                //Split edge values and them to a dictionary under the edges key
                string[] s = i.Value.Split(','); 
                d.Add(i.Key, s);
            }

            //Iterate over newly created dictionary and check if a loop exists in each edge 
            foreach (var i in d)
            {
                foreach (string s in d[i.Key])
                {
                    counter = 0;
                    checkForLoops(i.Key, s, d);
                }
            }

        }
        /*
        Check if edge creates a loop
        */
        private void checkForLoops(string current, string next, Dictionary<string, string[]> d)
        {
            if (!d.ContainsKey(next))
            {
                //dealing with a probe which is not present as key in the edges dictionary but this also means this path has an end and doesnt loop forever
                return;
            }

            foreach (string s in d[next])
            {
                //when counter is +- 9000 StackOverFlowException will be thrown. This is prevented by ending the loop early and throwing our own exception
                counter++;
                if (s.Equals(current) || counter > 5000)
                {
                    Console.WriteLine("Infinite loop in file");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }
                else
                {
                    checkForLoops(current, s, d);
                }
            }
        }

    }
}
