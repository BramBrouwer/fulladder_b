using fulladder_bram_kevin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Controller
{
    /*
    State pattern, zorgt er voor dat het gedrag van het circuit verandert aan de hand van de state.
    Makkelikk uit te breiden als de applicatie in de toekomst ook een edit functie oid krijgt
    */
    abstract class State
    {
        public abstract void run(Circuit circuit, TextBox logBody);
    }
}
