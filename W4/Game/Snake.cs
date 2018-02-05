using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Snake
    {
        public List<Point> body;
        public Snake(int a)
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
        }
        public Snake()
        {
            body = new List<Point>();
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

            if (body[0].x < 0) body[0].x = Console.WindowWidth;
            if (body[0].x > Console.WindowWidth) body[0].x = 0;

            if (body[0].y < 0) body[0].y = Console.WindowHeight;
            if (body[0].y > Console.WindowHeight) body[0].y =0;

        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(body.Count);
            foreach (Point p in this.body)
            {
                if (p == this.body[0])
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("*");
              
            }
        }
    }
}
