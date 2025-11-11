using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

using PowerOfUsingRightDataStructures;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== C# Data Structure Demonstrations ===\n");

        Example1_DictionaryFastLookup();
        Example2_SortedDictionary();
        Example3_HashSetUniqueItems();
        Example4_QueueFIFO();
        Example5_StackUndo();
        Example6_GraphAdjacencyList();
        Example7_PriorityQueue();
        Example8_ArrayConstantAccess();
        Example9_ListBinarySearch();
        Example10_LinkedListFastInsert();
        Example11_MultiValueDictionary();
        Example12_ConcurrentCollections();

        Console.WriteLine("\n=== End of Demonstrations ===");
    }

    // ----------------------------------------------------------
    // 1. Fast Lookup using Dictionary
    // ----------------------------------------------------------
    static void Example1_DictionaryFastLookup()
    {
        Console.WriteLine("Preparing data...");

        // Create List<T>
        var list = new List<ParentItem>();
        for (int i = 0; i < 1000000; i++)
        {
            var parent = new ParentItem { Id = i, Children = new List<ChildItem>() };
            for (int j = 0; j < 10; j++)
            {
                parent.Children.Add(new ChildItem { Id = j, Value = $"Child_{i}_{j}" });
            }
            list.Add(parent);
        }

        // Create Dictionary<T>
        var dict = new Dictionary<int, ParentItem>();
        for (int i = 0; i < 1000000; i++)
        {
            var parent = new ParentItem { Id = i, Children = new List<ChildItem>() };
            for (int j = 0; j < 10; j++)
            {
                parent.Children.Add(new ChildItem { Id = j, Value = $"Child_{i}_{j}" });
            }
            dict[i] = parent;
        }

        Console.WriteLine("Data prepared. Starting benchmarks...\n");

        var sw = new Stopwatch();

        // Search in List<T>
        int targetParent = 987665;
        int targetChild = 9;

        sw.Start();
        var listParent = list.FirstOrDefault(p => p.Id == targetParent);
        var listChild = listParent?.Children.FirstOrDefault(c => c.Id == targetChild);
        sw.Stop();
        Console.WriteLine($"List<T> search time: {sw.ElapsedMilliseconds} ms");

        // Search in Dictionary<T>
        sw.Restart();
        dict.TryGetValue(targetParent, out var dictParent);
        var dictChild = dictParent?.Children.FirstOrDefault(c => c.Id == targetChild);
        sw.Stop();
        Console.WriteLine($"Dictionary<T> search time: {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\nBenchmark complete.");
    }

    // ----------------------------------------------------------
    // 2. SortedDictionary
    // ----------------------------------------------------------
    static void Example2_SortedDictionary()
    {
        Console.WriteLine("\n2) SortedDictionary → Automatically Sorted");

        var scores = new SortedDictionary<int, string>();
        scores[90] = "Alice";
        scores[70] = "Bob";
        scores[85] = "Chris";

        foreach (var s in scores)
            Console.WriteLine($"{s.Value} scored {s.Key}"); // sorted by key
    }

    // ----------------------------------------------------------
    // 3. HashSet for Unique Items
    // ----------------------------------------------------------
    static void Example3_HashSetUniqueItems()
    {
        Console.WriteLine("\n3) HashSet<T> → Unique Values Only");

        var emails = new HashSet<string>();
        emails.Add("a@test.com");
        emails.Add("b@test.com");
        emails.Add("a@test.com"); // duplicate ignored

        Console.WriteLine("Total unique emails: " + emails.Count);
    }

    // ----------------------------------------------------------
    // 4. Queue (FIFO)
    // ----------------------------------------------------------
    static void Example4_QueueFIFO()
    {
        Console.WriteLine("\n4) Queue<T> → First-In-First-Out");

        var queue = new Queue<string>();
        queue.Enqueue("Task 1");
        queue.Enqueue("Task 2");

        Console.WriteLine("Processing: " + queue.Dequeue());
    }

    // ----------------------------------------------------------
    // 5. Stack (LIFO)
    // ----------------------------------------------------------
    static void Example5_StackUndo()
    {
        Console.WriteLine("\n5) Stack<T> → Undo Functionality (LIFO)");

        var stack = new Stack<string>();
        stack.Push("State 1");
        stack.Push("State 2");

        Console.WriteLine("Undo: restore " + stack.Pop());
    }

    // ----------------------------------------------------------
    // 6. Graph using Adjacency List
    // ----------------------------------------------------------
    static void Example6_GraphAdjacencyList()
    {
        Console.WriteLine("\n6) Graph → Dictionary<T, List<T>>");

        var graph = new Dictionary<string, List<string>>
        {
            ["A"] = new List<string> { "B", "C" },
            ["B"] = new List<string> { "D" }
        };

        Console.WriteLine("Neighbors of A: " + string.Join(", ", graph["A"]));
    }

    // ----------------------------------------------------------
    // 7. PriorityQueue
    // ----------------------------------------------------------
    static void Example7_PriorityQueue()
    {
        Console.WriteLine("\n7) PriorityQueue → Highest Priority First");

        var pq = new PriorityQueue<string, int>();
        pq.Enqueue("Low Priority Task", 3);
        pq.Enqueue("High Priority Task", 1);

        Console.WriteLine("Next task: " + pq.Dequeue());
    }

    // ----------------------------------------------------------
    // 8. Array: Constant-Time Index Access
    // ----------------------------------------------------------
    static void Example8_ArrayConstantAccess()
    {
        Console.WriteLine("\n8) Array → Fastest Index Access");

        int[] numbers = new int[5] { 10, 20, 30, 40, 50 };
        Console.WriteLine("Element at index 3 → " + numbers[3]);
    }

    // ----------------------------------------------------------
    // 9. List + BinarySearch
    // ----------------------------------------------------------
    static void Example9_ListBinarySearch()
    {
        Console.WriteLine("\n9) List<T> + BinarySearch → Fast Searching in Sorted List");

        var list = new List<int> { 50, 10, 30, 20, 40 };
        list.Sort();

        int index = list.BinarySearch(30);
        Console.WriteLine("Index of 30 → " + index);
    }

    // ----------------------------------------------------------
    // 10. LinkedList: Fast Insert/Remove in Middle
    // ----------------------------------------------------------
    static void Example10_LinkedListFastInsert()
    {
        Console.WriteLine("\n10) LinkedList<T> → Fast Insert in Middle");

        var linked = new LinkedList<string>();
        var first = linked.AddFirst("Song A");
        linked.AddAfter(first, "Song B");

        Console.WriteLine("Playlist order: " + string.Join(" → ", linked));
    }

    // ----------------------------------------------------------
    // 11. Multi-Value Dictionary (Dictionary<T, List<T>>)
    // ----------------------------------------------------------
    static void Example11_MultiValueDictionary()
    {
        Console.WriteLine("\n11) Multi-Value Dictionary → One Key with Many Values");

        var products = new Dictionary<string, List<string>>();
        products["Electronics"] = new List<string> { "Phone", "Laptop" };

        Console.WriteLine("Electronics: " + string.Join(", ", products["Electronics"]));
    }

    // ----------------------------------------------------------
    // 12. Concurrent Dictionaries & Queues
    // ----------------------------------------------------------
    static void Example12_ConcurrentCollections()
    {
        Console.WriteLine("\n12) Concurrent Collections → Thread-Safe Operations");

        var cache = new ConcurrentDictionary<int, string>();
        cache.TryAdd(1, "value");

        Console.WriteLine("Cache item 1 → " + cache[1]);
    }
}


namespace PowerOfUsingRightDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing data...");

            // Create List<T>
            var list = new List<ParentItem>();
            for (int i = 0; i < 1000000; i++)
            {
                var parent = new ParentItem { Id = i, Children = new List<ChildItem>() };
                for (int j = 0; j < 10; j++)
                {
                    parent.Children.Add(new ChildItem { Id = j, Value = $"Child_{i}_{j}" });
                }
                list.Add(parent);
            }

            // Create Dictionary<T>
            var dict = new Dictionary<int, ParentItem>();
            for (int i = 0; i < 1000000; i++)
            {
                var parent = new ParentItem { Id = i, Children = new List<ChildItem>() };
                for (int j = 0; j < 10; j++)
                {
                    parent.Children.Add(new ChildItem { Id = j, Value = $"Child_{i}_{j}" });
                }
                dict[i] = parent;
            }

            Console.WriteLine("Data prepared. Starting benchmarks...\n");

            var sw = new Stopwatch();

            // Search in List<T>
            int targetParent = 987665;
            int targetChild = 9;

            sw.Start();
            var listParent = list.FirstOrDefault(p => p.Id == targetParent);
            var listChild = listParent?.Children.FirstOrDefault(c => c.Id == targetChild);
            sw.Stop();
            Console.WriteLine($"List<T> search time: {sw.ElapsedMilliseconds} ms");

            // Search in Dictionary<T>
            sw.Restart();
            dict.TryGetValue(targetParent, out var dictParent);
            var dictChild = dictParent?.Children.FirstOrDefault(c => c.Id == targetChild);
            sw.Stop();
            Console.WriteLine($"Dictionary<T> search time: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("\nBenchmark complete.");
            Console.ReadLine();
        }
    }

    public class ParentItem
    {
        public int Id { get; set; }
        public List<ChildItem> Children { get; set; }
    }

    public class ChildItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}


