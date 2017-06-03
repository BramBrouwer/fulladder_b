using fulladder_bram_kevin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Model
{
    class Unvalidated : State
    {
        public override void run(Circuit circuit, TextBox logBody)
        {
            //TODO Validate circuit
            //Message user to run the circuit again (state will be changed)
            throw new NotImplementedException();
        }

    }
}
