using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder_bram_kevin.Controller
{
    class MainController
    { 
        public CircuitBuilder circuitbuilder;
        NodeDrawer nodeDrawer;
        public FileReader filereader;
        NodeFactory nodeFactory;
        MainWindow mainWindow;

        public MainController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.nodeDrawer = new NodeDrawer(mainWindow.grid);
            this.filereader = new FileReader(this,mainWindow.logBody);
            this.nodeFactory = new NodeFactory();
            //this.circuitbuilder = new CircuitBuilder();
        }


        public void openFile()
        {
            if (filereader.chooseFile())
            {
                circuitbuilder.CreateAllNodes(filereader._nodes);
                circuitbuilder.CreateCircuit(filereader._edges);
            }
        }



    }
}
