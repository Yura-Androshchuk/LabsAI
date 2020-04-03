using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AiLab2Search
{
    public class TreeOfStates
    {
        //queue of unchecked states
        Queue<Node> unchecked1 = new Queue<Node>();

        //Tree
        public void CreateTree()
        {
            Node rootElement = new Node(new int[] { 3, 3, 3, 1, 2, 2 }, new int[] {0,0,0,0,0,0}, new int[] {0,0 });
            //adding root element
            unchecked1.Enqueue(rootElement);
            while (unchecked1.Count>0)
            {

                Node current = unchecked1.Dequeue();
                //Display
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(current.ValueShoreLeft[i]);
                }
                Console.Write(" ");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write(current.ValueBoat[i]);
                }
                Console.Write(" ");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(current.ValueShoreRight[i]);
                }
                Console.WriteLine(" ");
                //check
                Node temp1 = CanTakePersonToRShorePerson(current);
                if (temp1 != null)
                {
                    current.AddChild(temp1);
                }
                Node temp2 = CanTakePersonToRShoreBigM(current);
                if (temp2 != null)
                {
                    current.AddChild(temp2);
                }
                Node temp3 = CanTakeBigMToRShorePerson(current);
                if (temp3 != null)
                {
                    current.AddChild(temp3);
                }
                Node temp4 = CanTakeBigMToRShoreBigM(current);
                if (temp4 != null)
                {
                    current.AddChild(temp4);
                }
                Node temp5 = CanTakeSmallMToRShorePerson(current);
                if (temp5 != null)
                {
                    current.AddChild(temp5);
                }
                Node temp6 = CanTakeSmallMToRShoreBigM(current);
                if (temp6 != null)
                {
                    current.AddChild(temp6);
                }
                Node temp7 = LastMove(current);
                if (temp7 != null)
                {
                    current.AddChild(temp7);
                }
                
            }
            Console.WriteLine("Do you know de way?");
            Node problem = new Node(new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 3, 3, 3, 1, 2, 2 }, new int[] { 0, 0 });
            RBFS(problem, rootElement, 6);
            
        }

        //Check
        public Node CanTakePersonToRShorePerson(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //PersontoBoat person right to shore
            int isPersonLeftShore = Array.IndexOf(tarrayL, 3);
            if (isPersonLeftShore != -1)
            {
                tarrayB[Array.IndexOf(tarrayB, 0)] = 3;
                tarrayL[Array.IndexOf(tarrayL, 3)] = 0;
            }
            else return null;

            int isPersonLeftShore1 = Array.IndexOf(tarrayL, 3);
            if (isPersonLeftShore1 != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 3)] = 0;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 3;
            }
            else return null;

            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;

        }
        public Node CanTakePersonToRShoreBigM(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm==0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //Bm to boat, person to right shore
            int isPersonLeftShore = Array.IndexOf(tarrayL, 3);
            int isBmLeftShore = Array.IndexOf(tarrayL, 1);
            if (isPersonLeftShore != -1 && isBmLeftShore != -1)
            {
                tarrayB[Array.IndexOf(tarrayB, 0)] = 1;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 3;
                tarrayL[Array.IndexOf(tarrayL, 3)] = 0;
                tarrayL[Array.IndexOf(tarrayL, 1)] = 0;
            }
            else return null;
            //check if posiible
            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;
        }
        public Node CanTakeBigMToRShorePerson(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //Bm to rshore person to boat
            int isPersonLeftShore = Array.IndexOf(tarrayL, 3);
            int isBmLeftShore = Array.IndexOf(tarrayL, 1);
            if (isPersonLeftShore != -1 && isBmLeftShore != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 1)] = 0;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 1;
                tarrayL[Array.IndexOf(tarrayL, 3)] = 0;
                tarrayB[Array.IndexOf(tarrayB, 0)] = 3;
            }
            else return null;

            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;


        }
        public Node CanTakeBigMToRShoreBigM(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //Bm to rshore Bm to boat
            int isBmLeftShore = Array.IndexOf(tarrayL, 1);
            if (isBmLeftShore != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 1)] = 0;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 1;
            }
            else return null;
            int isBmLeftShore1 = Array.IndexOf(tarrayL, 1);
            if (isBmLeftShore1 != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 1)] = 0;
                tarrayB[Array.IndexOf(tarrayB, 0)] = 1;
            }
            else return null;

            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;


        }

        public Node CanTakeSmallMToRShorePerson(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //Sm to rshore Person to boat
            int isSmLeftShore = Array.IndexOf(tarrayL, 2);
            int isPersonLeftShore = Array.IndexOf(tarrayL, 3);
            if (isPersonLeftShore != -1 && isSmLeftShore != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 2)] = 0;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 2;
                tarrayL[Array.IndexOf(tarrayL, 3)] = 0;
                tarrayB[Array.IndexOf(tarrayB, 0)] = 3;
            }
            else return null;

            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;


        }

        public Node CanTakeSmallMToRShoreBigM(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            //Boat driver back to left shore
            int inBoatPerson = Array.IndexOf(tarrayB, 3);
            int inBoatBm = Array.IndexOf(tarrayB, 1);
            if (inBoatPerson == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 3;
                tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
            }
            else if (inBoatBm == 0)
            {
                tarrayL[Array.IndexOf(tarrayL, 0)] = 1;
                tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
            }
            //Sm to rshore Bm to boat
            int isSmLeftShore = Array.IndexOf(tarrayL, 2);
            int isBmLeftShore = Array.IndexOf(tarrayL, 1);
            if (isBmLeftShore != -1 && isSmLeftShore != -1)
            {
                tarrayL[Array.IndexOf(tarrayL, 2)] = 0;
                tarrayR[Array.IndexOf(tarrayR, 0)] = 2;

                tarrayL[Array.IndexOf(tarrayL, 1)] = 0;
                tarrayB[Array.IndexOf(tarrayB, 0)] = 1;
            }
            else return null;

            if (CountMonkeys(tarrayL) <= CountPeople(tarrayL) && CountMonkeys(tarrayR) <= CountPeople(tarrayR))
            {
                Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                unchecked1.Enqueue(newArrayNode);
                return newArrayNode;
            }
            else return null;


        }
        public Node LastMove(Node node)
        {
            Node newcurrent = node.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayR = new int[6]; int[] tarrayB = new int[2];
            tarrayL = newcurrent.ValueShoreLeft; tarrayR = newcurrent.ValueShoreRight; tarrayB = newcurrent.ValueBoat;
            if (CountZeros(tarrayL) == tarrayL.Length)
            {
                int isPersonInBoat = Array.IndexOf(tarrayB, 3);
                int isBmInBoat = Array.IndexOf(tarrayB, 1);
                if (isPersonInBoat != -1)
                {
                    tarrayB[Array.IndexOf(tarrayB, 3)] = 0;
                    tarrayR[Array.IndexOf(tarrayR, 0)] = 3;
                    Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                    unchecked1.Enqueue(newArrayNode);
                    return newArrayNode;
                }
                else if (isBmInBoat != -1)
                {
                    tarrayB[Array.IndexOf(tarrayB, 1)] = 0;
                    tarrayR[Array.IndexOf(tarrayR, 0)] = 1;
                    Node newArrayNode = new Node(tarrayL, tarrayR, tarrayB);
                    unchecked1.Enqueue(newArrayNode);
                    return newArrayNode;
                }
                else return null;
            }
            else return null;
        }

        //countElements
        public int CountPeople(int[] arr)
        {
            int totalPeople = arr.Count(n => n == 3);
            return totalPeople;
        }
        public int CountMonkeys(int[] arr)
        {
            int totalMonkeys = arr.Count(n => n < 3 && n > 0);
            return totalMonkeys;
        }
        public int CountZeros(int[] arr)
        {
            int totalZeros = arr.Count(n => n == 0);
            return totalZeros;
        }
        public bool IsFreePlace(int[] arr)
        {
            int totalPeople = arr.Count(n => n == 0);
            if (totalPeople > 0) return true;
            else return false;
        }
        //RBFS
        List<Node> wayList = new List<Node>();
        List<Node> checkList = new List<Node>();
        Queue<Node> checkQueue = new Queue<Node>();
        public void RBFS(Node problem, Node start, int flimit)
        {
            Node current = start.DeepClone();
            int[] tarrayL = new int[6]; int[] tarrayB = new int[2];
            tarrayL = current.ValueShoreLeft;
            tarrayB = current.ValueBoat;
            wayList.Add(start);
            if (CountZeros(tarrayL) == CountZeros(problem.ValueShoreLeft)&& CountZeros(tarrayB) == CountZeros(problem.ValueBoat))
            {

            }
            else
            {
                foreach (Node obj in current.Children)
                {
                    checkList.Add(obj);
                }
                checkList.ForEach(o => checkQueue.Enqueue(o));
                checkQueue = new Queue<Node>(checkQueue.OrderBy(o => CountZeros(o.ValueShoreRight)));
                checkList.Clear();
                Node next = checkQueue.Dequeue();
                
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write(next.ValueShoreLeft[i]);
                    }
                    Console.Write(" ");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write(next.ValueBoat[i]);
                    }
                    Console.Write(" ");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write(next.ValueShoreRight[i]);
                    }
                    Console.WriteLine(" ");
                
                RBFS(problem, next, flimit);
                  
            }
        }

        //compare
        public bool checkEquality<T>(T[] first, T[] second)
        {
            return Enumerable.SequenceEqual(first, second);
        }
    }
}
