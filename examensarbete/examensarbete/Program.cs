using System;
using System.Collections;
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

            printTreeA(tree1);

            NodeB[] treeB = toRecursiveTree(tree1);
            printTreeB(treeB);
            


            //stop program.
            Console.WriteLine("Click enter to close program");
            Console.In.ReadLine();
        }



        public static NodeB[] toRecursiveTree(NodeA[] treeA)
        {
            ArrayList treeB = new ArrayList();
            
            for(int currentIndex = 0; currentIndex < treeA.Length; currentIndex++)
            {
                bool isChild = false;
                for (int i = 0; i < treeA.Length; i++)
                {
                    for (int j = 0; j < treeA[i].getChildren().Length; j++)
                    {
                        //check if id = some nodes child id. if no child is found the current index is at the top of the tree.
                        if (treeA[currentIndex].getId() == treeA[i].getChildren()[j])
                        {
                            isChild = true;
                        }
                    }
                }
                if (!isChild)
                {
                    NodeB child = new NodeB(treeA[currentIndex].getId());
                    child.setChildren(addRecursiveChildren(treeA, treeA[currentIndex]));
                    treeB.Add(child);
                }
            }

            NodeB[] recursiveTree = new NodeB[treeB.Count];
            for (int i = 0; i < treeB.Count; i++)
            {
                recursiveTree[i] = (NodeB)treeB[i];
            }

            return recursiveTree;
        }

        public static NodeB[] addRecursiveChildren(NodeA[] treeA, NodeA parent)
        {
            NodeB[] treeB = new NodeB[parent.getChildren().Length];
            int index = 0;
            for (int i = 0; i < treeA.Length; i++)
            {
                for (int j = 0; j < parent.getChildren().Length; j++)
                {
                    if (treeA[i].getId() == parent.getChildren()[j])
                    {
                        NodeB child = new NodeB(treeA[i].getId());
                        child.setChildren(addRecursiveChildren(treeA, treeA[i]));
                        treeB[index] = child;
                        index++;
                    }

                }
            }
            return treeB;
        }



        public static void printTreeA(NodeA[] treeA)
        {

            for (int currentIndex = 0; currentIndex < treeA.Length; currentIndex++)
            {
                bool isChild = false;
                for (int i = 0; i < treeA.Length; i++)
                {
                    for (int j = 0; j < treeA[i].getChildren().Length; j++)
                    {
                        if (treeA[currentIndex].getId() == treeA[i].getChildren()[j])
                        {
                            isChild = true;
                        }

                    }
                }

                if (!isChild)
                {
                    Console.WriteLine(treeA[currentIndex].getId());
                    printChildrenA(treeA[currentIndex], treeA, 2);
                }

            }

        }

        public static void printChildrenA(NodeA current, NodeA[] nodes, int depth)
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

                        printChildrenA(nodes[nodeIndex], nodes, depth + 1);

                    }
                }
            }
        }


        public static void printTreeB(NodeB[] treeB, int depth=0)
        {
            for (int i = 0; i < treeB.Length; i++)
            {
                for(int j = 0; j < depth; j++)
                {
                    Console.Write("     ");
                }
                Console.WriteLine(treeB[i].getId());
                printTreeB(treeB[i].getChildren(), depth+1);
            }
        }

    }
}
