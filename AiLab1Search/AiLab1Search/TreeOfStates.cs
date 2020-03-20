using System;
using System.Collections.Generic;
using System.Text;

namespace AiLab1Search
{
    class TreeOfStates
    {
        //queue of unchecked states
        Queue<Node> unchecked1 = new Queue<Node>();
        
        public void CreateTree()
        {
            //root
            Node rootElement = new Node(new int[] { 2, 2, 2, 2, 0, 1, 1, 1 });
            //adding root element
            unchecked1.Enqueue(rootElement);
            
            while (unchecked1.Count > -1)
            {
                
                Node current = unchecked1.Dequeue();

                for (int i = 0; i < 8; i++)
                {

                    Console.Write(current.Value[i]);
                }
                Console.WriteLine();

                Node temp1 = PossibleMoveDoubleLeft(current);
                if (temp1!=null)
                {
                    current.AddChild(temp1.Value);
                }
                Node temp2 = PossibleMoveLeft(current);
                if (temp2 != null)
                {
                    current.AddChild(temp2.Value);
                }
                Node temp3 = PossibleMoveRight(current);
                if (temp3 != null)
                {
                    current.AddChild(temp3.Value);
                }
                Node temp4 = PossibleMoveDoubleRight(current);
                if (temp4 != null)
                {
                    current.AddChild(temp4.Value);
                }

            }
        }
        // find position of 0 in an array
        public int FindPosZero(int[] a)
        {
            for (int i = 0; i < 8; i++)
            {
                if (a[i] == 0)
                {
                    int findPosZero = i;
                    return findPosZero;
                }

            }
            return 0;
            
        }
        //methods checking the position swappng and adding to a queue
        public Node PossibleMoveRight(Node node)
        {
            
             int[] tarray = new int[8];
             tarray = node.Value;
            int findPosZero = FindPosZero(tarray);
            if (findPosZero > 0 && tarray[findPosZero - 1] == 2)
            {
                tarray[findPosZero] = 2;
                tarray[findPosZero - 1] = 0;
                Node newArrayNode = new Node(tarray);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else { return null; }
            

        }
        public Node PossibleMoveDoubleRight(Node node)
        {
           
            int[] tarray = new int[8];
            tarray = node.Value;
            int findPosZero = FindPosZero(tarray);
            if (findPosZero > 1 && tarray[findPosZero - 2] == 2)
            {
                tarray[findPosZero] = 2;
                tarray[findPosZero - 2] = 0;
                Node newArrayNode = new Node(tarray);
                unchecked1.Enqueue(newArrayNode);
                
                return newArrayNode;
            }
            else { return null; }
        }
        public Node PossibleMoveLeft(Node node)
        {
            int[] tarray = new int[8];
            tarray = node.Value;
            int findPosZero = FindPosZero(tarray);
            if (findPosZero < 7 && tarray[findPosZero + 1] == 1)
            {
                tarray[findPosZero] = 1;
                tarray[findPosZero + 1] = 0;
                Node newArrayNode = new Node(tarray);
                unchecked1.Enqueue(newArrayNode);
                
                return newArrayNode;
            }
            else { return null; }
        }
        public Node PossibleMoveDoubleLeft(Node node)
        {
           
            int[] tarray = new int[8];
            tarray = node.Value;
            int findPosZero = FindPosZero(tarray);
            if (findPosZero < 6 &&tarray[findPosZero + 2] == 1 )
            {
                tarray[findPosZero] = 1;
                tarray[findPosZero + 2] = 0;
                Node newArrayNode = new Node(tarray);
                unchecked1.Enqueue(newArrayNode);
                
                return newArrayNode;
            }
            else { return null; }
        }
        //add list og children to a queue
      
        //bfs shows how many nodes where checked
        public int BFS(Node node)
        {
            Node result = new Node(new int[] { 1, 1, 1, 0, 2, 2, 2, 2 });
            int counter = 0;
            Queue<Node> checkQueue = new Queue<Node>();
            checkQueue.Enqueue(node);
            bool ch = true;
            while (ch)
            {
                Node currentCheck = checkQueue.Dequeue();
                counter += 1;
                if (currentCheck.Value == result.Value)
                {
                    ch = false;
                }
                else
                {
                    foreach (Node obj in currentCheck.Children)
                    {
                        checkQueue.Enqueue(obj);
                    }
                }
            }
            return counter;
        }
    }
}
