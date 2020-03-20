using System;
using System.Collections.Generic;
using System.Text;

namespace AiLab1Search
{
    public class Node
    {
        //значення вузла
        
        public int[] Value{ get; set; }
        //children
        public List<Node> children;
        public List<Node> Children{ get;   set; }
        //constrictor
        public Node(int[] value)
        {
            this.Value = value;
            Children = new List<Node>();
        }
        //methods
        public void AddChild(int[] value)
        {
            Children.Add(new Node(value));
        }
       
        //public void PrintPretty(string indent, bool last)
        //{
        //    Console.Write(indent);
        //    if (last)
        //    {
        //        Console.Write("\\-");
        //        indent += "  ";
        //    }
        //    else
        //    {
        //        Console.Write("|-");
        //        indent += "| ";
        //    }
        //    Console.WriteLine(Value);

        //    for (int i = 0; i < Children.Count; i++)
        //        Children[i].PrintPretty(indent, i == Children.Count - 1);
        //}
    }
}
