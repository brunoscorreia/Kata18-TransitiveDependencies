// <copyright file="Main.cs" company="Concrete">
// Concrete Solutions all rights reserved
// </copyright>

using TransitiveDependencies.Model;

namespace Kata18
{
    using System;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            TransitiveDependencies transitiveDep = new TransitiveDependencies();

            Console.Write("------- Building Dependencies ------- \n \n");

            printClasses(transitiveDep.AddDirect("A", new[] { "B", "C", "E", "F", "G", "H" }));

            printClasses(transitiveDep.AddDirect("B", new[] { "C", "E", "F", "G", "H" }));

            printClasses(transitiveDep.AddDirect("C", new[] { "G" }));

            printClasses(transitiveDep.AddDirect("D", new[] { "A", "B", "C", "E", "F", "G", "H" }));

            printClasses(transitiveDep.AddDirect("E", new[] { "F", "H" }));

            printClasses(transitiveDep.AddDirect("F", new[] { "H" }));

            Console.Write("\n\n");

            Console.Write("------- Answers ------- \n \n");

            var fullDep = transitiveDep.Dependecies_For("A");

            printArray(fullDep);

            fullDep = transitiveDep.Dependecies_For("B");

            printArray(fullDep);

            fullDep = transitiveDep.Dependecies_For("C");

            printArray(fullDep);

            fullDep = transitiveDep.Dependecies_For("D");

            printArray(fullDep);

            fullDep = transitiveDep.Dependecies_For("E");

            printArray(fullDep);

            fullDep = transitiveDep.Dependecies_For("F");

            printArray(fullDep);

        }

        public static void printArray(string[] array)
        {
            Console.Write(array[0] + "   ");

            for (int i = 1; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public static void printClasses(Base collection)
        {
            Console.Write(collection.Name + "   "); 

            foreach (var item in collection.Childrens)
            {
                Console.Write(item.Name + " ");
            }

            Console.WriteLine();
        }
    }
}
