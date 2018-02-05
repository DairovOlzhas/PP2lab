using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Point
    {
        public int x, y;

        public Point() { }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("*");
        }
    }
}
