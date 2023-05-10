using System;
using System.Security.AccessControl;
using System.Text;

namespace AVL_Trees_PA3
{

    // BinarySearchTree class
    //
    // CONSTRUCTION: with no initializer
    //
    // ***************************************************************
    // void insert( x ) --> Insert x
    // void remove( x ) --> Remove x
    // boolean contains( x ) --> Return true if x is present
    // Comparable findMin( ) --> Return smallest item
    // Comparable findMax( ) --> Return largest item
    // boolean isEmpty( ) --> Return true if empty; else false
    // void makeEmpty( ) --> Remove all items
    // void printTree( ) --> Print tree in sorted order
    // String toString() --> Print Tree in a visual fashion
    // ****************************************************************
    // Throws UnderflowException as appropriate
    /**
    * Implements an unbalanced binary search tree.
    * Note that all "matching" is based on the compareTo method.
    * @author Mark Allen Weiss
    * modified slightly by AK:
    * added toString()
    * removed reliance on UnderflowException
    * rearranged the order of methods
    */
    public class BinarySearchTree<AnyType> where AnyType : IComparable
    {
        // Basic node stored in unbalanced binary search trees

        class BinaryNode<AnyType>
        {
            // Constructors
            public BinaryNode(AnyType theElement)
            {
                element = theElement;
                left = null;
                right = null;            }
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

        /** The tree root. */
        private BinaryNode<AnyType> root;
        /**
        * Construct the tree.
    */
        public BinarySearchTree()
        {
            root = null;
        }


        /**
        * Insert into the tree; duplicates are ignored.
        * @param x the item to insert.
        */
        public void insert(AnyType x)
        {
            root = insert(x, root);
        }

        /**
        * Remove from the tree. Nothing is done if x is not found.
        * @param x the item to remove.
        */
        public void remove(AnyType x)
        {
            root = remove(x, root);
        }

        /**
        * Find the smallest item in the tree.
        * @return smallest item or null if empty.
        */
        public AnyType findMin()
        {
            AnyType found = default(AnyType);
            if (!isEmpty())
            {
                found = findMin(root).element;
            }
            return found;
        }

        /**
        * Find the largest item in the tree.
        *
        * @return the largest item or null if empty.
        */
        public AnyType findMax()
        {
            AnyType found = default(AnyType);
            if (!isEmpty())
            {
                found = findMax(root).element;
            }
            return found;
        }

        /**
        * Find an item in the tree.
        * @param x the item to search for.
        * @return true if not found.
        */
        public Boolean contains(AnyType x)
        {
            return contains(x, root);
        }

        /**
        * Make the tree logically empty.
        */
        public void makeEmpty()
        {
            root = null;
        }

        /**
        * Test if the tree is logically empty.
        * @return true if empty, false otherwise.
        */
        public Boolean isEmpty()
        {
            return root == null;
        }

        /**
        * Print the tree contents in sorted order.
        */
        public void printTree()
        {
            if (isEmpty())
                Console.WriteLine("Empty tree");
            else
                printTree(root);
        }

        /**
        * return a string with a visual representation of BST
        * @return String representation of the tree
        */
        public override String ToString()
        {
            StringBuilder buffer = new StringBuilder(50);
            toStr(root, buffer, "", "");
            return buffer.ToString();
        }
        /*----------------------------------------------------------
        *
        * Private Methods
        *
        ----------------------------------------------------------*/
        /**
        * Internal method to insert into a subtree.
        * @param x the item to insert.
        * @param t the node that roots the subtree.
        * @return the new root of the subtree.
    */
        private BinaryNode<AnyType> insert(AnyType x, BinaryNode<AnyType> t)
        {
            if (t == null)
                return new BinaryNode<AnyType>(x, null, null);
            int compareResult = x.CompareTo(t.element);
            if (compareResult < 0)
                t.left = insert(x, t.left);
            else if (compareResult > 0)
                t.right = insert(x, t.right);
            else
                ; // Duplicate; do nothing. Explicitly emphasized
            return t;
        }

        /**
        * Internal method to remove from a subtree.
        * @param x the item to remove.
        * @param t the node that roots the subtree.
        * @return the new root of the subtree.
    */
        private BinaryNode<AnyType> remove(AnyType x, BinaryNode<AnyType> t)
        {
            if (t == null)
                return t; // Item not found; do nothing
            int compareResult = x.CompareTo(t.element);
            if (compareResult < 0)
                t.left = remove(x, t.left);
            else if (compareResult > 0)
                t.right = remove(x, t.right);
            else if (t.left != null && t.right != null) // Two children
            {
                t.element = findMin(t.right).element;
                t.right = remove(t.element, t.right);
            }
            else
                t = (t.left != null) ? t.left : t.right;
            return t;
        }

        /**
        * Internal method to find the smallest item in a subtree.
        * @param t the node that roots the subtree.
        * @return node containing the smallest item.
        */
        private BinaryNode<AnyType> findMin(BinaryNode<AnyType> t)
        {
            if (t == null)
                return null;
            else if (t.left == null)
                return t;
            return findMin(t.left);
        }

        /**
        * Internal method to find the largest item in a subtree.
        * @param t the node that roots the subtree.
        * @return node containing the largest item.
        */
        private BinaryNode<AnyType> findMax(BinaryNode<AnyType> t)
        {
            if (t != null)
                while (t.right != null)
                    t = t.right;
            return t;
        }

        /**
        * Internal method to find an item in a subtree.
        * @param x is item to search for.
        * @param t the node that roots the subtree.
        * @return node containing the matched item.
        */
        private Boolean contains(AnyType x, BinaryNode<AnyType> t)
        {
            if (t == null)
                return false;
            int compareResult = x.CompareTo(t.element);
            if (compareResult < 0)
                return contains(x, t.left);
            else if (compareResult > 0)
                return contains(x, t.right);
            else
                return true; // Match
        }

        /**
        * Internal method to print a subtree in sorted order.
        * @param t the node that roots the subtree.
        */
        private void printTree(BinaryNode<AnyType> t)
        {
            if (t != null)
            {
                printTree(t.left);
                Console.WriteLine(t.element);
                printTree(t.right);
            }
        }

        /** Internal method to prepare a string display
        * of a BST in a manner of DOS-file structure
        * @param node starting node
        * @param buffer - dynamically generated connections
        * @param prefix - connection prefix for the node
        * @param childrenPrefix - connection prefix for the children
        */
        private void toStr(BinaryNode<AnyType> node,
        StringBuilder buffer,
        String prefix,
        String childrenPrefix)
        {
            buffer.Append(prefix);
            buffer.Append(node.element.ToString());
            buffer.Append('\n');
            if (node.right != null)
            {
                toStr(node.right, buffer, childrenPrefix + ">── ",
                node.left != null
                ? childrenPrefix + "│ "
                : childrenPrefix + " ");
            }
            if (node.left != null)
            {
                toStr(node.left, buffer, childrenPrefix + "<── ", childrenPrefix + " ");
            }
        }

        /**
        * Internal method to compute height of a subtree.
        * @param t the node that roots the subtree.
    */
        // private int height( BinaryNode<AnyType> t )
        // {
        // if( t == null )
        // return -1;
        // else
        // return 1 + Math.max( height( t.left ), height( t.right ) );
        // }
        //
    }
}
