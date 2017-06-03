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
            this.circuitbuilder = new CircuitBuilder();
        }

           //TODO 
           //Circuit geen singleton maar gewoon instance retunen hier na het creeeren
           //Bij het creeren wordt de state op unvalidated gezet.
           //Na het valideren van het circuit wordt de state op validat/invalid gezet
        public void openFile()
        {
            if (filereader.chooseFile())
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
        }
        //Called when the user clicks the run button, behaviour depends on the circuits state
        public void run()
        {
            if(circuit == null) { mainWindow.logBody.AppendText("No circuit found!"); return; }
            circuit.run(mainWindow.logBody);
        }


    
    }
}
