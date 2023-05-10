// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using AVL_Trees_PA3;


/**
 * 
 * TO DO:
 * 1. time the insertion method
 * 2. time the contains method
 * 3. time the remove method
 *  
 * Refer to https://www.geeksforgeeks.org/how-to-calculate-the-code-execution-time-in-c-sharp/ to
 * time execution.
 */

namespace AVL_Trees_PA3
{

    public class Program
    {

        /**
         * Your ****insertion**** test should time inserting 1,000,000 numbers from 0 to 999,999 in random 
         * order into a tree. 
         * Make sure that there are no repetitions and that all the numbers are, in fact, inserted.
         */

        Stopwatch AVLInsertWatch;
        Stopwatch BSTInsertionWatch;
        Stopwatch SplayInsertWatch;

        Stopwatch AVLContainsWatch;
        Stopwatch BSTContainsWatch;
        Stopwatch SplayContainsWatch;

        Stopwatch AVLRemovalWatch;
        Stopwatch BSTRemovalWatch;
        Stopwatch SplayRemovalWatch;

        AvlTree<int> AvlTree;
        BinarySearchTree<int> BinarySearchTree;
        SplayTree<int> SplayTree;

        public Program() {
            AvlTree = new AvlTree<int>();
            BinarySearchTree= new BinarySearchTree<int>();
            SplayTree = new SplayTree<int>();
        }
        

        public void InsertionAVL()
        {
            //begins calculating the execution time
            AVLInsertWatch = Stopwatch.StartNew();

            int gap = 7919;
            
            for (int i = 0; i < 1000000; ++i)
            {
                AvlTree.insert(gap);
                gap += 7919;
                if(gap > 1000000)
                {
                    gap %= 1000000;
                }
            }

            Boolean allThere = true;
            for(int i = 1; i <= 1000000; i++)
            {
                //check that all numbers were inserted - use contains method
                if(AvlTree.contains(i) == false)
                {
                    allThere = false;
                    Console.WriteLine("When inserting - Not all numbers are in the AVL Tree correctly");
                    break;
                }
            }

            AVLInsertWatch.Stop(); 
        }

        public void InsertionBST()
        {

            //begins calculating the execution time
            BSTInsertionWatch = Stopwatch.StartNew();

            int gap = 7919;

            for (int i = 0; i < 1000000; ++i)
            {
                BinarySearchTree.insert(gap);
                gap += 7919;
                if (gap > 1000000)
                {
                    gap %= 1000000;
                }
            }

            Boolean allThere = true;
            for (int i = 1; i <= 1000000; i++)
            {
                //check that all numbers were inserted - use contains method
                if (BinarySearchTree.contains(i) == false)
                {
                    allThere = false;
                    Console.WriteLine("Not all numbers are in the BST Tree correctly");
                    break;
                }
            }

            BSTInsertionWatch.Stop();
        }

        public void InsertionSplay()
        {
            //begins calculating the execution time
            SplayInsertWatch = Stopwatch.StartNew();

            int gap = 7919;

            for (int i = 0; i < 1000000; ++i)
            {
                SplayTree.insert(gap);
                gap += 7919;
                if (gap > 1000000)
                {
                    gap %= 1000000;
                }
            }

            Boolean allThere = true;
            for (int i = 1; i <= 1000000; i++)
            {
                //check that all numbers were inserted - use contains method
                if (SplayTree.contains(i) == false)
                {
                    allThere = false;
                    Console.WriteLine("Not all numbers are in the Splay Tree correctly");
                    break;
                }
            }

            SplayInsertWatch.Stop();
        }
        /**
        ****Containment**** test should time testing contains method ten times for each number from 0 to 999,999 in
         * the tree created above: 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, ..., 2, 2, 2, etc. 
         * If any number is not found, an error should be printed.
         */
        public void ContainsAVL()
        {
            //Start watch
            AVLContainsWatch = Stopwatch.StartNew();

            Boolean allThere = true;
            for (int i = 1; i <= 1000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //check that all numbers were inserted - use contains method
                    if (AvlTree.contains(i) == false)
                    {
                        allThere = false;
                        Console.WriteLine("Not all numbers are in the AVL Tree correctly");
                        break;
                    }
                }
            }

            AVLContainsWatch.Stop();
        }

        public void ContainsBST()
        {
            //Start watch
            BSTContainsWatch = Stopwatch.StartNew();

            Boolean allThere = true;
            for (int i = 1; i <= 1000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //check that all numbers were inserted - use contains method
                    if (BinarySearchTree.contains(i) == false)
                    {
                        allThere = false;
                        Console.WriteLine("Not all numbers are in the BST Tree correctly");
                        break;
                    }
                }
            }

            BSTContainsWatch.Stop();
        }

        public void ContainsSplay()
        {
            //Start watch
            SplayContainsWatch = Stopwatch.StartNew();


            Boolean allThere = true;
            for (int i = 1; i <= 1000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //check that all numbers were inserted - use contains method
                    if (SplayTree.contains(i) == false)
                    {
                        allThere = false;
                        Console.WriteLine("Not all numbers are in the Splay Tree correctly");
                        break;
                    }
                }
            }

            SplayContainsWatch.Stop();
        }

        /**
         * ****Removal**** test should time remove method for all numbers 0 to 999,999 in that order
         */
        public void AVLRemoval()
        {
            //start watch
            AVLRemovalWatch = Stopwatch.StartNew();


            for(int i = 1; i <= 1000000; i++)
            {
                AvlTree.remove(i);
            }

            AVLRemovalWatch.Stop();
        }

        public void BSTRemoval()
        {
            //start watch
            BSTRemovalWatch = Stopwatch.StartNew();


            for (int i = 1; i <= 1000000; i++)
            {
                BinarySearchTree.remove(i);
            }

            BSTRemovalWatch.Stop();
        }

        public void SplayRemoval()
        {
            //start watch
            SplayRemovalWatch = Stopwatch.StartNew();


            for (int i = 1; i <= 1000000; i++)
            {
                SplayTree.remove(i);
            }

            SplayRemovalWatch.Stop();
        }

        static void Main(String[] args)
        {
            Program program = new Program();

            Console.WriteLine("Test:\t|\tInsert:\t|\tContains\t|\tRemove\t|");
            Console.WriteLine("-----------------------------------------------------------------");

            program.InsertionAVL();
            program.ContainsAVL();
            program.AVLRemoval();
            Console.WriteLine($"AVL:\t|\t" + program.AVLInsertWatch.ElapsedMilliseconds + "\t|\t" + program.AVLContainsWatch.ElapsedMilliseconds + "\t\t|\t" + program.AVLRemovalWatch.ElapsedMilliseconds + "\t|");


            program.InsertionSplay();
            program.ContainsSplay();
            program.SplayRemoval();
            Console.WriteLine($"Splay:\t|\t" + program.SplayInsertWatch.ElapsedMilliseconds + "\t|\t" + program.SplayContainsWatch.ElapsedMilliseconds + "\t\t|\t" + program.SplayRemovalWatch.ElapsedMilliseconds + "\t|");


            program.InsertionBST();
            program.ContainsBST();
            program.BSTRemoval();
            Console.WriteLine($"BST:\t|\t" + program.BSTInsertionWatch.ElapsedMilliseconds + "\t|\t" + program.BSTContainsWatch.ElapsedMilliseconds + "\t\t|\t" + program.BSTRemovalWatch.ElapsedMilliseconds + "\t|");
            




        }

    }
}
