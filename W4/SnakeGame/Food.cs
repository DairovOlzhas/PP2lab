using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food
    {
        public Point location;
        public char sign = '@';
        public ConsoleColor color = ConsoleColor.Green;

        public Food() { }
        public Food(Snake snake, Wall wall)
        {
            location = new Point();
            SetRandomFood(snake, wall);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }

        public void SetRandomFood(Snake snake, Wall wall)
        {
            int x = new Random().Next(2, 79);
            int y = new Random().Next(2, 29);

            location = new Point(x, y);
            bool res = true;
            foreach (Point p in wall.body)
            {
                if (p.x == location.x
                    && p.y == location.y)
                {
                    SetRandomFood(snake, wall);
                    res = false;
                    break;
                }


            }

            for (int i = 0; i < snake.body.Count && res; i++)
            {
                if (snake.body[i].x == location.x
                    && snake.body[i].y == location.y)
                {
                    SetRandomFood(snake, wall);
                    break;
                }
            }
                 
        }
      
    }
}
