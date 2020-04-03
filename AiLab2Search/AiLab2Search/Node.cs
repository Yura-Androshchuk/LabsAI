using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AiLab2Search
{
    [Serializable]
    public class Node //: //ICloneable
    {
        //значення вузла

        public int[] ValueShoreLeft { get; set; }
        public int[] ValueShoreRight { get; set; }
        public int[] ValueBoat { get; set; }
        
        //children
        public List<Node> children;
        public List<Node> Children { get; set; }
        //constrictor
        public Node(int[] valueShoreL,int[] valueShoreR,int[] valueBoat)
        {
            this.ValueShoreLeft = valueShoreL;
            this.ValueShoreRight = valueShoreR;
            this.ValueBoat = valueBoat;
            Children = new List<Node>();
        }

        //methods
        public void AddChild(Node value)
        {
            Children.Add(value);
        }
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
