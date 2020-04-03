using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiLab2Search
{
    class Program
    {
        static void Main(string[] args)
        {
          
            TreeOfStates t = new TreeOfStates();
            t.CreateTree();
            //Queue<int> num = new Queue<int>();
            //List<int> numbers = new List<int>() {2,5,0, 1, 2, 3, 45 };
            //numbers.Sort();
            //numbers.ForEach(o => num.Enqueue(o));
            
            
            //int ontop = num.Dequeue();
            //Console.WriteLine(ontop+ "1111111111111");
            //foreach (int i in num)
            //{
            //    Console.WriteLine(i);
            //}
            Console.ReadKey();
        }
    }
}
