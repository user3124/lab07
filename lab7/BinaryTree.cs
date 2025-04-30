using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root; // Корень дерева
        private BinaryTreeNode<T> _currentNode; // Текущий узел

        // Конструктор
        public BinaryTree()
        {
            _root = null;
            _currentNode = null;
        }

        public BinaryTreeNode<T> Next(BinaryTreeNode<T> node)
        {
            if (node == null) return null;

            if (node.Right != null)
            {
                var current = node.Right;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current;
            }
            else
            {
                var parent = node.Parent;
                while (parent != null && node == parent.Right)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public BinaryTreeNode<T> Previous(BinaryTreeNode<T> node)
        {
            if (node == null) return null;

            if (node.Left != null)
            {
                var current = node.Left;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                return current;
            }
            else
            {
                var parent = node.Parent;
                while (parent != null && node == parent.Left)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public void Add(T value)
        {
            _root = AddRecursive(_root, value, null);
        }

        private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> node, T value, BinaryTreeNode<T> parent)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T> { Data = value, Parent = parent };
            }

            if (value.CompareTo(node.Data) < 0)
            {
                node.Left = AddRecursive(node.Left, value, node);
            }
            else if (value.CompareTo(node.Data) > 0)
            {
                node.Right = AddRecursive(node.Right, value, node);
            }

            return node;
        }

        public static BinaryTree<T> operator ++(BinaryTree<T> tree)
        {
            if (tree._currentNode == null)
            {
                tree._currentNode = tree.Next(tree._root);
            }
            else
            {
                tree._currentNode = tree.Next(tree._currentNode);
            }
            return tree;
        }

        public static BinaryTree<T> operator --(BinaryTree<T> tree)
        {
            if (tree._currentNode == null)
            {
                tree._currentNode = tree.Previous(tree._root);
            }
            else
            {
                tree._currentNode = tree.Previous(tree._currentNode);
            }
            return tree;
        }
    }
}
