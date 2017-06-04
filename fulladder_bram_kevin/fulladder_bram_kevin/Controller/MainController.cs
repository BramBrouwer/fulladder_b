using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fulladder_bram_kevin.Model;

namespace fulladder_bram_kevin.Controller
{
    class MainController
    { 
        public CircuitBuilder circuitbuilder;
        NodeDrawer nodeDrawer;
        public FileReader filereader;
        NodeFactory nodeFactory;
        MainWindow mainWindow;
        Circuit circuit;

        public MainController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.nodeDrawer = new NodeDrawer(mainWindow.grid);
            this.filereader = new FileReader(this,mainWindow.logBody);
            this.nodeFactory = new NodeFactory();
            this.nodeFactory.AddNodeType("INPUT_HIGH", typeof(Input));
            this.nodeFactory.AddNodeType("INPUT_LOW", typeof(Input));
            this.nodeFactory.AddNodeType("PROBE", typeof(Probe));
            this.nodeFactory.AddNodeType("AND", typeof(AND));
            this.nodeFactory.AddNodeType("NAND", typeof(NAND));
            this.nodeFactory.AddNodeType("NOR", typeof(NOR));
            this.nodeFactory.AddNodeType("NOT", typeof(NOT));
            this.nodeFactory.AddNodeType("OR", typeof(OR));
            this.nodeFactory.AddNodeType("XOR", typeof(XOR));
            this.circuitbuilder = new CircuitBuilder(nodeFactory,mainWindow.logBody);
        }

           
        public void openFile(bool curFile)
        {
            if (filereader.chooseFile(curFile))
            {
                circuitbuilder.CreateAllNodes(filereader._nodes);
                circuit = new Circuit(circuitbuilder.CreateCircuit(filereader._edges));
                if(circuitbuilder.ValidateCircuit())
                {
                    circuit.set_state(new Valid());
                    //mainWindow.logBody.AppendText("Circuit vali");
                    nodeDrawer.draw(circuit);
                }
                else
                {
                    circuit.set_state(new Invalid());
                }
            }
            else
            {
                Console.WriteLine("mMeme");
            }
        }
        //Called when the user clicks the run button, behaviour depends on the circuits state
        public void run()
        {
            if(circuit == null) { mainWindow.logBody.AppendText("No circuit found!"); return; }
            circuit.run(mainWindow.logBody);
        }


        public void edit()
        {
            filereader.edit();
        }

        public void reload()
        {
            openFile(true);
        }


    
    }
}
