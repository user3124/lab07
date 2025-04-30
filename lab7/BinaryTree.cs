using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        private BinaryTreeNode<T> _root; // Корень дерева
        private BinaryTreeNode<T> _currentNode; // Текущий узел

        // Конструктор
        public BinaryTree()
        {
            _root = null;
            _currentNode = null;
        }

        // Текущий узел
        public BinaryTreeNode<T> Current()
        {
            return _currentNode;
        }

        // Сброс позиции
        public void Reset()
        {
            _currentNode = GetLeftmostNode(_root);
        }

        private BinaryTreeNode<T> GetLeftmostNode(BinaryTreeNode<T> node)
        {
            while (node?.Left != null)
            {
                node = node.Left;
            }
            return node;
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

        // Реализуем перечислитель, чтобы можно было использовать дерево в цикле foreach
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var item in InOrderTraversal(node.Left))
                {
                    yield return item;
                }
                yield return node.Data;

                foreach (var item in InOrderTraversal(node.Right))
                {
                    yield return item;
                }
            }
        }

        // Метод для внешнего итератора
        public IEnumerable<T> GetSortedNodes(Func<T, T, int> comparison)
        {
            var sortedList = new List<T>();
            InOrderTraversalWithLambda(_root, sortedList, comparison);
            return sortedList;
        }

        private void InOrderTraversalWithLambda(BinaryTreeNode<T> node, List<T> list, Func<T, T, int> comparison)
        {
            if (node != null)
            {
                InOrderTraversalWithLambda(node.Left, list, comparison);
                list.Add(node.Data);
                InOrderTraversalWithLambda(node.Right, list, comparison);
            }
        }
    }
}
