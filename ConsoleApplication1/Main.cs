using System;

namespace Kata18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //TODO
            TransitiveDependencies Tras = new TransitiveDependencies();

            Tras.AddDirect("A", new[] { "B", "C", "E", "F", "G", "H" });




            Console.WriteLine();
        }
    }
}
