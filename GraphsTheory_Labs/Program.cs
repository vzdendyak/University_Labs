using System;
using System.Collections.Generic;

namespace GraphsTheory_Labs
{
    internal class Program
    {
        public static List<Vershyna> arr;
        public static Stack<Vershyna> path;

        private static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n\n\n---------\n[1] - Пошук в глибину\n[2] - Пошук в ширину\n[3] - Вихiд");
                var res = Console.ReadLine();
                int.TryParse(res, out int i);
                if (i == 3)
                {
                    loop = false;
                    break;
                }
                Console.WriteLine("Задайте вершину початку 0..7");
                res = Console.ReadLine();
                int.TryParse(res, out int index);
                switch (i)
                {
                    case 1:
                        CalculateDFS(index, 1);
                        break;

                    case 2:
                        CalculateBFS(index, 1);
                        break;

                    case 3:
                        loop = false;
                        break;
                }
            }
        }

        public static void CalculateDFS(int index, int logs = 0)
        {
            initialize();
            path = new Stack<Vershyna>();
            Show(index);
            DFS(index, logs);
        }

        private static void DFS(int index, int logs = 0)
        {
            arr[index].visited = true;
            path.Push(arr[index]);
            if (logs == 1) Console.WriteLine($"Пройдено вершину {arr[index].n}, v: {arr[index].visited}");
            for (int i = 0; i < arr[index].dots.Count; i++)
            {
                var s = arr[arr[index].dots[i]];
                if (logs == 1) Console.WriteLine($"Сусiд-вершина: {s.n}, v: {s.visited}");
                if (!s.visited)
                {
                    var ind = arr.FindIndex(v => v.dots == s.dots);
                    if (logs == 1) Console.WriteLine($"Рухаємось до вершини: {ind}");
                    Show(ind);
                    DFS(ind, logs);
                    if (logs == 1) Console.WriteLine($"Повертаємось i видаляємо: {path.Peek().n}");
                    path.Pop();
                }
            }
        }

        /// <param name="logs">If you want to see logs, make 1</param>
        public static void CalculateBFS(int index, int logs = 0)
        {
            initialize();
            var queue = new Queue<Vershyna>();
            queue.Enqueue(arr[index]);
            arr[index].visited = true;
            Show(index);
            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                if (logs == 1) Console.WriteLine($"Пройдено вершину {element.n}, v = {element.visited}");

                for (int i = 0; i < element.dots.Count; i++)
                {
                    var s = arr[element.dots[i]];
                    if (logs == 1) Console.WriteLine($"Сусiд-вершина: {s.n}, v: {s.visited}");

                    if (!s.visited)
                    {
                        queue.Enqueue(s);
                        s.visited = true;
                        if (logs == 1) Console.WriteLine($"Пройшли вершину: {s.n}, v: {s.visited}");
                        var ind = arr.FindIndex(v => v.dots == s.dots);
                        Show(ind);
                    }
                }
            }
        }

        private static void ShowFull()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine($"Вершина {i}, сусiди: ");
                for (int j = 0; j < arr[i].dots.Count; j++)
                {
                    Console.WriteLine($"{arr[i].dots[j]}, v = {arr[i].visited}");
                }
                Console.WriteLine("---------------");
            }
        }

        private static void Show(int uniq = -1)
        {
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < arr.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (uniq == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Вершина {i}, v: {arr[i].visited}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Вершина {i}, v: {arr[i].visited}");
                }
            }
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();
        }

        private static void initialize()
        {
            arr = new List<Vershyna>
            {
                new Vershyna(new List<int> { 1, 3}, 0), // 0
                new Vershyna(new List<int> { 0, 5}, 1), // 1
                new Vershyna(new List<int> { 5, 4}, 2), // 2
                new Vershyna(new List<int> { 0, 5 , 7 }, 3), // 3
                new Vershyna(new List<int> { 2 }, 4),   // 4
                new Vershyna(new List<int> { 1,2,3,6 }, 5),     // 5
                new Vershyna(new List<int> { 5 }, 6),     // 6
                new Vershyna(new List<int> { 3 }, 7)     // 7
            };
        }
    }

    public class Vershyna
    {
        public List<int> dots;
        public bool visited;
        public int n;

        public Vershyna(List<int> dots, int n)
        {
            this.n = n;
            this.dots = dots;
            visited = false;
        }
    }
}