using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            bool isRunning = true;

            Console.WriteLine("Введите начальное значение для создания дерева:");
            int initialValue = Convert.ToInt32(Console.ReadLine());
            tree.Add(initialValue);

            while (isRunning)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("[1] Добавить элемент");
                Console.WriteLine("[2] Переместиться вперёд (++)");
                Console.WriteLine("[3] Переместиться назад (--)");
                Console.WriteLine("[4] Получить текущий узел");
                Console.WriteLine("[5] Обход дерева (foreach)");
                Console.WriteLine("[6] Обход дерева с сортировкой (внешний итератор)");
                Console.WriteLine("[7] Выход");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите значение для добавления:");
                        int value = Convert.ToInt32(Console.ReadLine());
                        tree.Add(value);
                        break;

                    case 2:
                        ++tree;
                        Console.WriteLine($"Текущий узел: {tree.Current()?.Data}");
                        break;

                    case 3:
                        --tree;
                        Console.WriteLine($"Текущий узел: {tree.Current()?.Data}");
                        break;

                    case 4:
                        Console.WriteLine($"Текущий узел: {tree.Current()?.Data}");
                        break;

                    case 5:
                        Console.WriteLine("Обход дерева (foreach):");
                        foreach (var item in tree)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Обход дерева с сортировкой:");

                        // Лямбда-выражение передается в метод при вызове
                        var sortedNodes = tree.GetSortedNodes((x, y) => x.CompareTo(y));
                        foreach (var item in sortedNodes)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case 7:
                        isRunning = false;
                        Console.WriteLine("Выход из программы");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова");
                        break;
                }
            }
        }
    }
}
