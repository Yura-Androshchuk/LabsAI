using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AiLab1Search
{
    [Serializable]
    public class Node //: //ICloneable
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
        public void AddChild(Node value)
        {
            Children.Add(value);
        }
       public Node DeepCopy()
        {
            Node temp = (Node)this.MemberwiseClone();
            temp.Value = this.Value;
            return temp;
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
    public static class ExtensionMethods
    {
        // Deep clone
        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
