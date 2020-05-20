using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace AiLab3
{
    class TreeOfStates
    {
        //queue of unchecked states
        Queue<Node> unchecked1 = new Queue<Node>();
        Queue<Node> states = new Queue<Node>();
        public void CreateTree()
        {
            //root
            Node rootElement = new Node(new int[] { 2, 2, 2, 0, 1, 1, 1 }, null);
            //adding root element
            unchecked1.Enqueue(rootElement);
            //states.Enqueue(rootElement);
            //Node rootElement3 = new Node(new int[] { 23, 2, 2, 0, 1, 1, 1 }, null);
            //Node rootElement1 = new Node(new int[] { 23, 2, 2, 0, 1, 1, 1 }, null);
            //Node rootElement2 = new Node(new int[] { 14, 4, 2, 0, 1, 1, 1 }, null);
            //Queue<Node> n = new Queue<Node>();
            //n.Enqueue(rootElement1); n.Enqueue(rootElement3);
            //Console.WriteLine(IsInQueue(rootElement2, n));

            while (unchecked1.Count > 0)
            {

                Node current = unchecked1.Dequeue();
                
                    for (int i = 0; i < 7; i++)
                    {

                        Console.Write(current.Value[i]);
                    }
                    Console.WriteLine();
                


                //check1

                Node temp1 = PossibleMoveDoubleLeft(current);
                if (temp1 != null)
                {
                    current.AddChild(temp1);
                }
                //check2
                Node temp2 = PossibleMoveLeft(current);
                if (temp2 != null)
                {
                    current.AddChild(temp2);
                }
                //check3
                Node temp3 = PossibleMoveRight(current);
                if (temp3 != null)
                {
                    current.AddChild(temp3);
                }
                //check4
                Node temp4 = PossibleMoveDoubleRight(current);
                if (temp4 != null)
                {
                    current.AddChild(temp4);
                }

            }
            Console.WriteLine("Search");
            Aneal(rootElement, 300.0, 1.0);

            Console.WriteLine();
            //int counter = BFS(rootElement);
            //Console.WriteLine("Nodes Checked");
            //Console.WriteLine(counter);
            //Node node123 = BFSReturnNode(rootElement);
            //for (int i = 0; i < 8; i++)
            //{

            //    Console.Write(node123.Parent.Value[i]);
            //}
            //Console.WriteLine();
            //Display(node123);
        }
        // find position of 0 in an array
        public int FindPosZero(int[] a)
        {
            int zero = 0;
            int index = Array.IndexOf(a, zero);
            return index;

        }
        //methods checking the position swapping and adding to a queue
        public Node PossibleMoveRight(Node node)
        {
            
                Node newcurrent = node.DeepClone();
                Node newParent = node.DeepClone();
                int[] tarray = new int[7];
                tarray = newcurrent.Value;
                int tempForSwap;
                int findPosZero = FindPosZero(tarray);
                if (findPosZero > 0)
                {
                    tempForSwap = tarray[findPosZero - 1];
                    tarray[findPosZero - 1] = 0;
                    tarray[findPosZero] = tempForSwap;
                    Node newArrayNode = new Node(tarray, newParent);
                if (IsInQueue(newArrayNode, states) == false)
                {
                    unchecked1.Enqueue(newArrayNode);
                    states.Enqueue(newArrayNode);
                    return newArrayNode;

                }
                else return null;
            }
            else { return null; }


        }
        public Node PossibleMoveDoubleRight(Node node)
        {
                Node newcurrent = node.DeepClone();
                Node newParrent = node.DeepClone();
                int[] tarray = new int[7];
                tarray = newcurrent.Value;
                int tempForSwap;
                int findPosZero = FindPosZero(tarray);
                if (findPosZero > 1)
                {
                    tempForSwap = tarray[findPosZero - 2];
                    tarray[findPosZero - 2] = 0;
                    tarray[findPosZero] = tempForSwap;
                    Node newArrayNode = new Node(tarray, newParrent);
                if (IsInQueue(newArrayNode, states) == false)
                {
                    unchecked1.Enqueue(newArrayNode);
                    states.Enqueue(newArrayNode);
                    return newArrayNode;

                }
                else { return null; }
            }
            else return null;
        }
        public Node PossibleMoveLeft(Node node)
        {
            
                Node newcurrent = node.DeepClone();
                Node newParent = node.DeepClone();
                int[] tarray = new int[7];
                tarray = newcurrent.Value;
                int findPosZero = FindPosZero(tarray);
                int tempForSwap;
                if (findPosZero < 6)
                {
                    tempForSwap = tarray[findPosZero + 1];
                    tarray[findPosZero + 1] = 0;
                    tarray[findPosZero] = tempForSwap;
                    Node newArrayNode = new Node(tarray, newParent);
                if (IsInQueue(newArrayNode, states) == false)
                {
                    unchecked1.Enqueue(newArrayNode);
                    states.Enqueue(newArrayNode);
                    return newArrayNode;

                }
                else { return null; }
            }
            else return null;
        }
        public Node PossibleMoveDoubleLeft(Node node)
        {
                Node newcurrent = node.DeepClone();
                Node newParrent = node.DeepClone();
                int[] tarray = new int[7];
                tarray = newcurrent.Value;
                int findPosZero = FindPosZero(tarray);
                int tempForSwap;
                if (findPosZero < 5)
                {
                    tempForSwap = tarray[findPosZero + 2];
                    tarray[findPosZero + 2] = 0;
                    tarray[findPosZero] = tempForSwap;
                    Node newArrayNode = new Node(tarray, newParrent);
                if (IsInQueue(newArrayNode, states) == false)
                {
                    unchecked1.Enqueue(newArrayNode);
                    states.Enqueue(newArrayNode);
                    return newArrayNode;

                }
                else { return null; }
            }
            else return null;
        }
        //compare
        public bool checkEquality<T>(T[] first, T[] second)
        {
            return Enumerable.SequenceEqual(first, second);
        }
        public bool IsInQueue(Node node, Queue<Node> nodes)
        {
            foreach (var item in nodes)
            {
                if (checkEquality(node.Value, item.Value))
                {
                    return true;
                }
            }
            return false;
        }
        //
        public void MakeParentQueue(Node node, Queue<Node> nodes)
        {
            Node current = node.DeepClone();
            if (current.Parent != null)
            {
                nodes.Enqueue(current.Parent);
                Node next = current.Parent.DeepClone();
                MakeParentQueue(next, nodes);
            }
            else;
        }
        //
        public void Display(Node node)
        {
            Node current = node.DeepClone();
            if (current.Parent != null)
            {
                for (int i = 0; i < 7; i++)
                {

                    Console.Write(current.Value[i]);
                }
                Console.WriteLine();
                Node next = current.Parent.DeepClone();
                Display(next);
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {

                    Console.Write(current.Value[i]);
                }
            }
        }

        public int countRight(int[] arr)
        {
            if (arr[6] == 2 && arr[5] == 2 && arr[4] == 2)
            {
                return 3;
            }
            else if ((arr[6] == 0 && arr[5] == 0) || (arr[6] == 0 && arr[4] == 0) || (arr[4] == 0 && arr[5] == 0))
            {
                return 2;
            }
            else if (arr[6] == 0 || arr[5] == 0 || arr[4] == 0)
            {
                return 1;
            }
            else return 0; 
        }
        public double returnChance(double e, double t)
        {
            return Math.Exp((-e / t));
        }
        public bool MakeTransaction(double chance)
        {
            Random rand = new Random();
            double temp; temp = rand.Next(1000);
            double result = temp / 1000.0;
            if (result <= chance)
            {
                return true;
            }
            else return false;

        }
        public double DecreaseTemperature(double currentTemperature, double counter)
        {
        //    double newTempetature = currentTemperature * 0.1 / counter;
            return currentTemperature-=1;
        }
        public void Aneal(Node root, double max, double min)
        {
            Queue<Node> checkQueue = new Queue<Node>();

            checkQueue.Enqueue(root);
            double counter = 0.0;
            while (max>min)
            {
                Node currentCheck = checkQueue.Dequeue();
                for (int i = 0; i < 7; i++)
                {

                    Console.Write(currentCheck.Value[i]);
                }
                Console.WriteLine();
                if (checkQueue.Count == 0)
                {
                    foreach (Node obj in currentCheck.Children)
                    {
                        checkQueue.Enqueue(obj);
                    }
                    Node possibleChoice = checkQueue.Peek();
                    if (countRight(possibleChoice.Value) >= countRight(currentCheck.Value))
                    {
                        counter++;
                        foreach (Node obj in possibleChoice.Children)
                        {
                            checkQueue.Enqueue(obj);
                        }
                        max = DecreaseTemperature(max,counter);
                    }
                    else 
                    {
                        double chance = returnChance(countRight(currentCheck.Value)-countRight(possibleChoice.Value),max);
                        bool ch = MakeTransaction(chance);
                        if (ch)
                        {
                            counter++;
                            foreach (Node obj in possibleChoice.Children)
                            {
                                checkQueue.Enqueue(obj);
                            }
                            max = DecreaseTemperature(max, counter);
                        }
                        else
                        {
                            Node goDown = checkQueue.Dequeue().DeepClone();
                            checkQueue.Enqueue(goDown);
                        }
                    }
                }
                else 
                {
                    Node possibleChoice = checkQueue.Peek();
                    if (countRight(possibleChoice.Value) >= countRight(currentCheck.Value))
                    {
                        counter++;
                        foreach (Node obj in possibleChoice.Children)
                        {
                            checkQueue.Enqueue(obj);
                        }
                        max = DecreaseTemperature(max, counter);
                    }
                    else
                    {
                        double chance = returnChance(countRight(currentCheck.Value) - countRight(possibleChoice.Value), max);
                        bool ch = MakeTransaction(chance);
                        if (ch)
                        {
                            counter++;
                            foreach (Node obj in possibleChoice.Children)
                            {
                                checkQueue.Enqueue(obj);
                            }
                            max = DecreaseTemperature(max, counter);
                        }
                        else
                        {
                            Node goDown = checkQueue.Dequeue().DeepClone();
                            checkQueue.Enqueue(goDown);
                        }
                    }
                }        
            }
        }
    }
}
