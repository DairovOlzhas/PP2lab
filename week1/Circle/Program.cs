using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        public int r;
        public int area;
        public int per;

        public Circle()
        {
            r = 1;
        }

        public Circle(int a)
        {
            r = a;
        }

        public void FindArea()
        {
            area = 3 * r * r;
        }
        public void FindPer()
        {
            per = 2 * 3 * r;
        }

        public override string ToString()
        {
            return r + " " + area + " " + per;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = Console.Read();

            Circle c = new Circle(a);

            c.FindArea();
            c.FindPer();

            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
