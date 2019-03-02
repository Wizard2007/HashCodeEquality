using ArrayHashCodeEquality.Comparers;
using System;
using System.Collections.Generic;

namespace ArrayHashCodeEquality
{
    class ArrayHashCodeEquality
    {
        static void Main(string[] args)
        {

            int[] x = { 1, 2, 3 };
            int[] y = { 1, 2, 3 };
            int[] z = { 4, 5, 6 };

            var comparer = new ArrayEqualityComparer<int>();

            Console.WriteLine(comparer.GetHashCode(x));
            Console.WriteLine(comparer.GetHashCode(y));
            Console.WriteLine(comparer.GetHashCode(z));
            Console.WriteLine(comparer.Equals(x, y));
            Console.WriteLine(comparer.Equals(x, z));


            Console.WriteLine();
            Console.WriteLine("Byte comparers");
            byte[] x1 = { 1, 2, 3 };
            byte[] y1 = { 1, 2, 3 };
            byte[] z1 = { 4, 5, 6 };

            var comparer1 = new ByteArrayEqualityComparer();

            Console.WriteLine(comparer1.GetHashCode(x1));
            Console.WriteLine(comparer1.GetHashCode(y1));
            Console.WriteLine(comparer1.GetHashCode(z1));
            Console.WriteLine(comparer1.Equals(x1, y1));
            Console.WriteLine(comparer1.Equals(x1, z1));

            var t = new Dictionary<byte[], string>(comparer1);

            t.Add(x1, "x");
            t.Add(z1, "z");

            Console.WriteLine($"t[y] = {t[y1]} ");

            Console.WriteLine("Press [Enter] for continue ...");
            Console.ReadLine();
        }
    }
}
