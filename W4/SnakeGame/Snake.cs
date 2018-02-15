using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public List<Point> body;
        public char sign = '*';
        public ConsoleColor color = ConsoleColor.Yellow;

        public Snake() { }
        public Snake(int a)
        {
            body = new List<Point>();
            body.Add(new Point(35, 10));
            body.Add(new Point(36, 10));
            body.Add(new Point(37, 10));
            body.Add(new Point(38, 10));
        }

        public bool Collision(Wall wall)
        {
            foreach(Point p in wall.body)
            {
                if (p.x == body[0].x
                    && p.y == body[0].y)
                    return true;                               
            }

            for(int i = 1; i < body.Count; i++)
            {
                if (body[i].x == body[0].x
                    && body[i].y == body[0].y)
                    return true;
            }
            return false;
        }

        public void Eat(Food food, Wall wall, Snake snake)
        {
            if(body[0].x == food.location.x 
                && body[0].y == food.location.y)
            {
                food.SetRandomFood(snake, wall);
                body.Add(new Point(0, 0));
                Console.SetCursorPosition(32, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((snake.body.Count - 4) + " ");
            }
                
        }

        public void Move(int dx, int dy)
        {
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > 79)
                body[0].x = 0;
            if (body[0].x < 0)
                body[0].x = 79;
            if (body[0].y > 29)
                body[0].y = 2;
            if (body[0].y < 2)
                body[0].y = 29;
        }
        
        public void Draw()
        {
            int i = 0;
            while(i < body.Count)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.ForegroundColor = (i == 0) ? ConsoleColor.Red : color;
                char signs = (i == body.Count - 1) ? ' ' : sign;
                Console.Write(signs);
                i++;
            }
        }
    }
}
