using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fulladder
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeParser tp = new TreeParser();
            bool inputValid = false;

            Console.WriteLine("Please enter tree location and press enter");
            Console.WriteLine("For example : C:\\User\\Examplefolder\\Tree.txt");

            while (!inputValid) {
               
                String input = Console.ReadLine();
                inputValid = tp.readFile("C: \\Users\\bram\\School\\IDP\\CIRCUIT3.txt");
                
            }
            tp.filterLines();
            tp.printNodes();
           
            Console.ReadKey();

        }
    }
}
