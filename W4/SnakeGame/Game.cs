using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        public Snake snake;
        public Food food;
        public Wall wall;
        public int level;
        public int score;

        public Game()
        {
            score = 0;
            wall = new Wall();
            snake = new Snake(1);
            food = new Food(snake, wall);
            level = 1;
        }

        public void ShowHeader()
        {
            Console.SetCursorPosition(3, 0);
            Console.WriteLine("Lvl " + level);

            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Score: " + (snake.body.Count - 4));

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("________________________________________________________________________________");
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(11, 12);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition(11, 13);
            Console.WriteLine(" #####   ###    # #   ####      ###   #   #  ####  ####  ");
            Console.SetCursorPosition(11, 14);
            Console.WriteLine(" #      #   #  # # #  #        #   #  #   #  #     #   # ");
            Console.SetCursorPosition(11, 15);
            Console.WriteLine(" #  ##  # # #  # # #  ####     #   #  #   #  ####  ####  ");
            Console.SetCursorPosition(11, 16);
            Console.WriteLine(" #   #  #   #  #   #  #        #   #   # #   #     #   # ");
            Console.SetCursorPosition(11, 17);
            Console.WriteLine(" #####  #   #  #   #  ####      ###     #    ####  #   # ");
            Console.SetCursorPosition(11, 18);
            Console.WriteLine("                                                         ");

            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            while (btn.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, 19);
                btn = Console.ReadKey();
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("    ");
                

            }

        }
    }
}
