using fulladder_bram_kevin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Model
    
{
    class Valid : State
    {
        public override void run(Circuit circuit, TextBox logBody)
        {
            //Run circuit 
            logBody.AppendText("Running Circuit"+System.Environment.NewLine);
            foreach (KeyValuePair<string, Node> node in circuit._nodes)
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
            logBody.AppendText("------------OUTPUT--------------"+System.Environment.NewLine);
            foreach (KeyValuePair<string, Node> node in circuit._nodes)
            {

                if (node.Value.GetType() == typeof(Probe))
                {
                    logBody.AppendText("Probe: " + node.Key + " output: " + node.Value.output + System.Environment.NewLine);
                }
            }
            logBody.AppendText("-----------------------------------" + System.Environment.NewLine);
            foreach (KeyValuePair<string, Node> node in circuit._nodes)
            {
                node.Value.inputs.Clear();
                node.Value.output = 2;
            }

        }
    }
}
