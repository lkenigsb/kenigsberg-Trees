// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;

Console.WriteLine("Hello, World!");

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
        public void InsertionAVL()
        {
            //begins calculating the execution time
            AVLInsertWatch = Stopwatch.StartNew();

            //Create AVL tree

            for (int i = 0; i < 999999; i++)
            {
                //treeName.insert(i)
            }

            Boolean allThere = true;
            for(int i = 0; i < 999999; i++)
            {
                //check that all numbers were inserted - use contains method
                if(//treeName.contains(i) == false)
                {
                    allThere = false;
                    Console.WriteLine("Not all numbers are in the AVL Tree correctly");
                    break;
                }
            }

            AVLInsertWatch.Stop(); 
        }

        public void InsertionBST()
        {

            //begins calculating the execution time
            BSTInsertionWatch = Stopwatch.StartNew();

            //Create BST tree


            for (int i = 0; i < 999999; i++)
            {
                //treeName.insert(i)
            }

            Boolean allThere = true;
            for (int i = 0; i < 999999; i++)
            {
                //check that all numbers were inserted - use contains method
                if (//treeName.contains(i) == false)
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

            //Create Splay tree


            for (int i = 0; i < 999999; i++)
            {
                //treeName.insert(i)
            }

            Boolean allThere = true;
            for (int i = 0; i < 999999; i++)
            {
                //check that all numbers were inserted - use contains method
                if (//treeName.contains(i) == false)
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

            //create AVL Tree
            //insert numbers 0-9999999

            for(int i = 0; i < 9999999; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    //if(treeName.contains(i) == false)
                    {
                        Console.WriteLine("Error, number not found");
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

            //create BST Tree
            //insert numbers 0-9999999

            for (int i = 0; i < 9999999; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //if(treeName.contains(i) == false)
                    {
                        Console.WriteLine("Error, number not found");
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

            //create Splay Tree
            //insert numbers 0-9999999

            for (int i = 0; i < 9999999; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //if(treeName.contains(i) == false)
                    {
                        Console.WriteLine("Error, number not found");
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

            //create AVL tree
            //Insert numers 0-999999

            for(int i = 0; i < 999999; i++)
            {
                //AVLTree.remove(i)
            }

            AVLRemovalWatch.Stop();
        }

        public void BSTRemoval()
        {
            //start watch
            BSTRemovalWatch = Stopwatch.StartNew();

            //create BST tree
            //Insert numers 0-999999

            for (int i = 0; i < 999999; i++)
            {
                //AVLTree.remove(i)
            }

            BSTRemovalWatch.Stop();
        }

        public void SplayRemoval()
        {
            //start watch
            SplayRemovalWatch = Stopwatch.StartNew();

            //create Splay tree
            //Insert numers 0-999999

            for (int i = 0; i < 999999; i++)
            {
                //AVLTree.remove(i)
            }

            SplayRemovalWatch.Stop();
        }

        static public void Main(String[] args)
        {
            Program program = new Program();

            program.InsertionAVL();
            program.InsertionBST();
            program.InsertionSplay();

            program.ContainsAVL();
            program.ContainsBST();
            program.ContainsSplay();

            program.AVLRemoval();
            program.BSTRemoval();
            program.SplayRemoval();

            Console.WriteLine("Test:\t\tInsert:\t|\tContains\t|\tRemove\t|");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"AVL:\t|\t{program.AVLInsertWatch}\t|\t{program.AVLContainsWatch}\t|\t{program.AVLRemovalWatch}\t|");
            Console.WriteLine($"BST:\t|\t{program.BSTInsertionWatch}\t|\t{program.BSTContainsWatch}\t|\t{program.BSTRemovalWatch}\t|");
            Console.WriteLine($"Splay:\t|\t{program.SplayInsertWatch}\t|\t{program.SplayContainsWatch}\t|\t{program.SplayRemovalWatch}\t|");


        }

    }
}
