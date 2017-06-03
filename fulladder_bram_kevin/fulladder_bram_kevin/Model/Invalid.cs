using fulladder_bram_kevin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Model
{
    class Invalid : State
    {
        public override void run(Circuit circuit, TextBox logBody)
        {
            //TODO log to user that circuit is invalid
            logBody.AppendText("Cannot run circuit, validation failed.");
        }
    }
}
