using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        public int lenght;
        public int width;
        public int area;
        public int perim;

        public Rectangle()
        {
            lenght = 0;
            width = 0;
        }

        public Rectangle(int a, int b)
        {
            lenght = a;
            width = b;
        }

        public void FindArea()
        {
            area = lenght * width;
        }

        public void FindPerim()
        {
            perim = 2 * (lenght + width);
        }

        public override string ToString()
        {
            return "Area:" + area + " Perim: " + perim;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] par = Console.ReadLine().Split(' ');
            int a = int.Parse(par[0]);
            int b = int.Parse(par[1]);


            Rectangle r = new Rectangle(a, b);

            r.FindArea();
            r.FindPerim();

            Console.WriteLine(r);
            Console.ReadKey();

       

        }
    }
}
