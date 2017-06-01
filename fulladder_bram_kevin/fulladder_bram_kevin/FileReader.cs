using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using fulladder_bram_kevin.Controller;
using System.Windows.Controls;
using fulladder_bram_kevin.Model;

//TODO
//Test checkforloops
//Add a start/exit exists check 
//Think of a better way to check for loops

namespace fulladder_bram_kevin
{

    //TODO add check if file actually contains a start and end (return false or true in getnodesandedges)
    class FileReader
    {
        private string _filecontents;
        private Dictionary<string, string> _nodes = new Dictionary<string, string>();
        private Dictionary<string, string> _edges = new Dictionary<string, string>();
        private TextBox logBody;

        public FileReader(TextBox logBody)
        {
            this.logBody = logBody;
        }

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
            logBody.AppendText("Reading file.." + System.Environment.NewLine + "-" + System.Environment.NewLine);
            try
            {
                _nodes.Clear();    //Empty nodes
                _edges.Clear();    //Empty edges
                getNodesAndEdgesFromFile();
                logBody.AppendText("File read.." + System.Environment.NewLine + "-" + System.Environment.NewLine);
                logNodesAndEdges();
                CircuitBuilder builder = new CircuitBuilder();
                builder.CreateAllNodes(_nodes);
                builder.CreateCircuit(_edges);
                Dictionary<String,Node> x = Circuit.Instance._nodes;
            }
            catch (Exception e)
            {
                logBody.AppendText("Invalid file" + System.Environment.NewLine + "-" + System.Environment.NewLine);
                logBody.AppendText(e.Message + System.Environment.NewLine + "-" + System.Environment.NewLine);
            }
        }

        private void logNodesAndEdges()
        {
            logBody.AppendText("Nodes found" + System.Environment.NewLine + "_______________" + System.Environment.NewLine);
            foreach (KeyValuePair<string, string> entry in this._nodes)
            {
                logBody.AppendText(entry.Key + " - " + entry.Value + System.Environment.NewLine);
            }

            logBody.AppendText(System.Environment.NewLine + "Edges found" + System.Environment.NewLine + "_______________" + System.Environment.NewLine);
            foreach (KeyValuePair<string, string> entry in this._edges)
            {
                logBody.AppendText(entry.Key + " - " + entry.Value + System.Environment.NewLine);
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


    }
}
