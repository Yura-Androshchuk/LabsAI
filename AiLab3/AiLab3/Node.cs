using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AiLab3
{
    [Serializable]
    public class Node //: //ICloneable
    {
        //значення вузла

        public int[] Value { get; set; }
        //children
        public List<Node> children;
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }
        //constrictor
        public Node(int[] value, Node parent)
        {
            this.Value = value;
            this.Parent = parent;
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
