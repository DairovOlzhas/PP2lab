using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Snake
    {
        public List<Point> body;

        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
        }

        public void Move(int dx, int dy)
        {
            

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;           

        }
        public void Draw()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("*");
            }
        }
    }
}
