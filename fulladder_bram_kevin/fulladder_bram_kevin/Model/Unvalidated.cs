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
            //TODO try to validate circuit, set state to valid if succesfull
            //Make circuit builder available here?
            //circuit.set_state(new )
            throw new NotImplementedException();
        }

    }
}
