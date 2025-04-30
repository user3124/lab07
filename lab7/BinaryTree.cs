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
    }
}
