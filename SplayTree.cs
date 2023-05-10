using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Trees_PA3
{
    // SplayTree class
    //
    // CONSTRUCTION: with no initializer
    //
    // ******************PUBLIC OPERATIONS*********************
    // void insert( x ) --> Insert x
    // void remove( x ) --> Remove x
    // boolean contains( x ) --> Return true if x is found
    // Comparable findMin( ) --> Return smallest item
    // Comparable findMax( ) --> Return largest item
    // boolean isEmpty( ) --> Return true if empty; else false
    // void makeEmpty( ) --> Remove all items
    // ******************ERRORS********************************
    // Throws UnderflowException as appropriate
    /**
    * Implements a top-down splay tree.
    * Note that all "matching" is based on the compareTo method.
    * @author Mark Allen Weiss
*/
    public class SplayTree<AnyType> where AnyType : IComparable
    {
        /**
        * Construct the tree.
        */
        public SplayTree()
        {
            nullNode = new BinaryNode<AnyType>(default(AnyType));
            nullNode.left = nullNode.right = nullNode;
            root = nullNode;
        }

        private BinaryNode<AnyType> newNode = null; // Used between different inserts

        /**
        * Insert into the tree.
        *
        * @param x the item to insert.
        */
        public void insert(AnyType x)
        {
            if (newNode == null)
                newNode = new BinaryNode<AnyType>(default(AnyType));
            newNode.element = x;
            if (root == nullNode)
            {
                newNode.left = newNode.right = nullNode;
                root = newNode;
            }
            else
            {
                root = splay(x, root);
                int compareResult = x.CompareTo(root.element);
                if (compareResult < 0)
                {
                    newNode.left = root.left;
                    newNode.right = root;
                    root.left = nullNode;
                    root = newNode;
                }
                else if (compareResult > 0)
                {
                    newNode.right = root.right;
                    newNode.left = root;
                    root.right = nullNode;
                    root = newNode;
                }
                else
                    return; // No duplicates
            }
            newNode = null; // So next insert will call new
        }

        /**
        * Remove from the tree.
        *
        * @param x the item to remove.
        */
        public void remove(AnyType x)
        {
            if (!contains(x))
                return;
            BinaryNode<AnyType> newTree;
            // If x is found, it will be splayed to the root by contains
            if (root.left == nullNode)
                newTree = root.right;
            else
            {
                // Find the maximum in the left subtree
                // Splay it to the root; and then attach right child
                newTree = root.left;
                newTree = splay(x, newTree);
                newTree.right = root.right;
            }
            root = newTree;
        }

        /**
        * Find the smallest item in the tree.
        * Not the most efficient implementation (uses two passes), but has correct
        * amortized behavior.
        * A good alternative is to first call find with parameter
        * smaller than any item in the tree, then call findMin.
        *
        * @return the smallest item or null if empty.
        */
        public AnyType findMin()
        {
            AnyType min = default(AnyType);
            if (!isEmpty())
            {
                BinaryNode<AnyType> ptr = root;
                while (ptr.left != nullNode)
                    ptr = ptr.left;
                root = splay(ptr.element, root);
                return ptr.element;
            }
            return min;
        }

        /**
        * Find the largest item in the tree.
        * Not the most efficient implementation (uses two passes), but has correct
        * amortized behavior.
        * A good alternative is to first call find with parameter
        * larger than any item in the tree, then call findMax.
        *
        * @return the largest item or throw null if empty.
        */
        public AnyType findMax()
        {
            AnyType max = default(AnyType);
            if (!isEmpty())
            {
                BinaryNode<AnyType> ptr = root;
                while (ptr.right != nullNode)
                    ptr = ptr.right;
                root = splay(ptr.element, root);
                return ptr.element;
            }
            return max;
        }

        /**
        * Find an item in the tree.
        *
        * @param x the item to search for.
        * @return true if x is found; otherwise false.
        */
        public Boolean contains(AnyType x)
        {
            if (isEmpty())
                return false;
            root = splay(x, root);
            return root.element.CompareTo(x) == 0;
        }

        /**
        * Make the tree logically empty.
        */
        public void makeEmpty()
        {
            root = nullNode;
        }

        /**
        * Test if the tree is logically empty.
        *
        * @return true if empty, false otherwise.
        */
        public Boolean isEmpty()
        {
            return root == nullNode;
        }

        private BinaryNode<AnyType> header = new BinaryNode<AnyType>(default(AnyType)); // For splay

        /**
        * Internal method to perform a top-down splay.
        * The last accessed node becomes the new root.
        *
        * @param x the target item to splay around.
        * @param t the root of the subtree to splay.
        * @return the subtree after the splay.
        */
        private BinaryNode<AnyType> splay(AnyType x, BinaryNode<AnyType> t)
        {
            BinaryNode<AnyType> leftTreeMax, rightTreeMin;
            header.left = header.right = nullNode;
            leftTreeMax = rightTreeMin = header;
            nullNode.element = x; // Guarantee a match
            for (; ; )
            {
                int compareResult = x.CompareTo(t.element);
                if (compareResult < 0)
                {
                    if (x.CompareTo(t.left.element) < 0)
                        t = rotateWithLeftChild(t);
                    if (t.left == nullNode)
                        break;
                    // Link Right
                    rightTreeMin.left = t;
                    rightTreeMin = t;
                    t = t.left;
                }
                else if (compareResult > 0)
                {
                    if (x.CompareTo(t.right.element) > 0)
                        t = rotateWithRightChild(t);
                    if (t.right == nullNode)
                        break;
                    // Link Left
                    leftTreeMax.right = t;
                    leftTreeMax = t;
                    t = t.right;
                }
                else
                    break;
            }
            leftTreeMax.right = t.left;
            rightTreeMin.left = t.right;
            t.left = header.right;
            t.right = header.left;
            return t;
        }

        /**
        * Rotate binary tree node with left child.
        * For AVL trees, this is a single rotation for case 1.
        */
        private BinaryNode<AnyType> rotateWithLeftChild(BinaryNode<AnyType> k2)
        {
            BinaryNode<AnyType> k1 = k2.left;
            k2.left = k1.right;
            k1.right = k2;
            return k1;
        }

        /**
        * Rotate binary tree node with right child.
        * For AVL trees, this is a single rotation for case 4.
        */
        private BinaryNode<AnyType> rotateWithRightChild(BinaryNode<AnyType> k1)
        {
            BinaryNode<AnyType> k2 = k1.right;
            k1.right = k2.left;
            k2.left = k1;
            return k2;
        }

        // Basic node stored in unbalanced binary search trees
        class BinaryNode<AnyType>
        {
            // Constructors
            public BinaryNode(AnyType theElement)
            {
                element = theElement;
                left = null;
                right = null;
            }

            public BinaryNode(AnyType theElement, BinaryNode<AnyType> lt, BinaryNode<AnyType> rt)
            {
                element = theElement;
                left = lt;
                right = rt;
            }
            public AnyType element; // The data in the node
            public BinaryNode<AnyType> left; // Left child
            public BinaryNode<AnyType> right; // Right child
        }
        private BinaryNode<AnyType> root;
        private BinaryNode<AnyType> nullNode;
    }
}
