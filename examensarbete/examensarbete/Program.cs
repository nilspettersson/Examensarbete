using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examensarbete
{
    class Program
    {
        static void Main(string[] args)
        {

            NodeA[] tree1 = new NodeA[10];

            for(int i=0; i < tree1.Length; i++)
            {
                tree1[i] = new NodeA();
                if(i > 0)
                {
                    tree1[i].setChildren(new []{tree1[i - 1].getId()});
                }
            }

            printTree1(tree1);


            //stop program.
            Console.WriteLine("Click enter to close program");
            Console.In.ReadLine();
        }

        public static void printTree1(NodeA[] nodes)
        {

            for (int currentIndex = 0; currentIndex < nodes.Length; currentIndex++)
            {
                bool isChild = false;
                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < nodes[i].getChildren().Length; j++)
                    {
                        if (nodes[currentIndex].getId() == nodes[i].getChildren()[j])
                        {
                            isChild = true;
                        }

                    }
                }

                if (!isChild)
                {
                    Console.WriteLine(nodes[currentIndex].getId());
                    printChildren1(nodes[currentIndex], nodes, 2);
                }

            }

        }

        public static void printChildren1(NodeA current, NodeA[] nodes, int depth)
        {
            for (int childIndex = 0; childIndex < current.getChildren().Length; childIndex++)
            {
                for (int nodeIndex = 0; nodeIndex < nodes.Length; nodeIndex++)
                {
                    if(current.getChildren()[childIndex] == nodes[nodeIndex].getId())
                    {
                        for(int i = 0; i < depth; i++)
                        {
                            Console.Write("     ");
                        }
                        Console.WriteLine(nodes[nodeIndex].getId());

                        printChildren1(nodes[nodeIndex], nodes, depth + 1);

                    }
                }
            }
        }

    }
}
