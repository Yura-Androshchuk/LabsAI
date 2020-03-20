using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiLab1Search
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeOfStates t = new TreeOfStates();
            t.CreateTree();
            
            Console.ReadKey();

        }
    }
}
