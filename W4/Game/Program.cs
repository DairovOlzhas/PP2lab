using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game
{
    class Program
    {
        static Game game = new Game();

        static void GameProcess(Game a)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            Console.Clear();

            Snake snake = a.snake;
            int cnt = 0;
            snake.Draw();
            while (btn.Key != ConsoleKey.Escape)
            {

                  if (cnt % 5 == 1)
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
            game = a;


        }
        static void ShowMenuBack()
        {
            int pos = 0;
            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            bool exit = false;
            while (true)
            {
                if (pos > 4) pos = 0;
                if (pos < 0) pos = 4;
                ShowMenu(pos);
                btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        pos++;
                        break;

                    case ConsoleKey.Enter:
                        if (pos == 0)
                            GameProcess(new Game());
                        if (pos == 1)
                            GameProcess(game);
                        if (pos == 2)
                            GameProcess(ReadDataGame());
                        if (pos == 3)
                            SaveDataGame(game);
                        if (pos == 4)
                            exit = true;
                        break;
                }
                if (exit) break;
            }
        }

        static void ShowMenu(int pos)
        {
            Console.Clear();
            string[] buttons = { "New Game", "Resume", "Load Game", "Save Game", "Exit" };            
            for (int i = 0; i < buttons.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(buttons[i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static Game ReadDataGame()
        {
            string path = "data.xml";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Game));

            Game a = xs.Deserialize(fs) as Game;
            fs.Close();
            return a;
        }

        static void SaveDataGame(Game a)
        {
            string path = "data.xml";
            FileInfo file = new FileInfo(path);
            file.Delete();
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            XmlSerializer xs = new XmlSerializer(typeof(Game));

            try
            {
                xs.Serialize(fs, a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                fs.Close();
            }
            
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            ShowMenuBack();
            
        }
    }
}
