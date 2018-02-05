using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo btn = new ConsoleKeyInfo();

            Snake snake = new Snake();
            int cnt = 0;
            snake.Draw();
            while (btn.Key != ConsoleKey.Escape)
            {
                
                if (cnt % 5 == 0)
                    snake.body.Add(new Point(0, 0));
                btn = Console.ReadKey();
                Console.Clear();
                if (btn.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (btn.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (btn.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (btn.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                cnt++;
                snake.Draw();
            }

        }
    }
}
