using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AiLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeOfStates t = new TreeOfStates();
             t.CreateTree();
           
            //var str = "Tag 1         Tag2Tagb  tfdB";
            //str = string.Concat(str.Select(x => Char.IsDigit(x)|| char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            //str = Regex.Replace(str, @"\s+", " ");
            //str = str.Replace(" ", "-").ToLower();
            //Console.WriteLine(str); //somestr
        

       
       
            
            Console.ReadKey();
        }
    }
}
