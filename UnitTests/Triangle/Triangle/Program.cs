using System;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = TriangleManager.IsExist(1, 1, 1);

            Console.WriteLine(triangle);
            Console.ReadLine();
        }
    }
}
