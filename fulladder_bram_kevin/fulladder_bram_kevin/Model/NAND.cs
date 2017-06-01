﻿using fulladder_bram_kevin.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fulladder_bram_kevin.Model
{
    public class NAND : Node
    {
        public override void Run()
        {
            if (base.inputs.Count == 2)
            {
                int count = 0;
                foreach (int value in base.inputs)
                {
                    count = count + value;
                }
                if (count == 2)
                {
                    base.output = 0;
                }
                else
                {
                    base.output = 1;
                }
                foreach (Node next in base.nexts)
                {
                    next.inputs.Add(base.output);
                }
            }
            else
            {
                Console.WriteLine(base.inputs.Count + " is no valid input amount for an NAND Node");
            }
        }
        public override Label accept(NodeVisitor nodeVisitor, String name)
        {
            return nodeVisitor.visit(this, name);
        }
    }
}
