using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeGame
{
    class Program
    {
        public static string gamen = "new Game";
        public static Game game = new Game();
        static void GameProcess(Game a)
        {        

            Console.Clear();
            ConsoleKeyInfo btn = new ConsoleKeyInfo();

            int level = 1;
            a.ShowHeader();

            while(btn.Key != ConsoleKey.Escape)
            {

                if (level > a.level)
                {
                    a.level++;
                    a.wall.ReadLevel(level);
                    Console.SetCursorPosition(7, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(level + "  ");
                }

                a.snake.Draw();
                a.food.Draw();
                a.wall.Draw();

                btn = Console.ReadKey();

                if (btn.Key == ConsoleKey.UpArrow)
                    a.snake.Move(0, -1);
                if (btn.Key == ConsoleKey.DownArrow)
                    a.snake.Move(0, 1);
                if (btn.Key == ConsoleKey.LeftArrow)
                    a.snake.Move(-1, 0);
                if (btn.Key == ConsoleKey.RightArrow)
                    a.snake.Move(1, 0);
                
                a.snake.Eat(a.food, a.wall, a.snake);
                if (a.snake.Collision(a.wall))
                {
                    a = new Game();
                    a.GameOver();
                    
                    break;

                }
                if(a.snake.body.Count > a.wall.score)
                {
                    level++;
                }
            }
            game = a;
            SaveDataGame(game, false);

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
                            ShowUsersBack();
                        if (pos == 3)
                            SaveDataGame(game, true);
                        if (pos == 4)
                            exit = true;
                        break;
                }
                if (exit) break;
            }
        }

        static void ShowUsers(int pos)
        {
            DirectoryInfo users = new DirectoryInfo("Users");

            for(int i = 0; i < users.GetFiles().Length; i++)
            {
                if(i == pos)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(users.GetFiles()[i]);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
        static void ShowUsersBack()
        {
            int pos = 0;
            DirectoryInfo users = new DirectoryInfo("Users");

            while (true)
            {
                if (pos > users.GetFiles().Length - 1)
                    pos = 0;
                if (pos < 0)
                    pos = users.GetFiles().Length - 1;
                Console.Clear();
                ShowUsers(pos);
                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.UpArrow)
                    pos--;
                if (btn.Key == ConsoleKey.DownArrow)
                    pos++;
                if (btn.Key == ConsoleKey.Enter)
                {
                    gamen = users.GetFiles()[pos].Name;
                    GameProcess(ReadDataGame(gamen));
                    
                    break;
                }
                if (btn.Key == ConsoleKey.Escape)
                    break;
                if (btn.Key == ConsoleKey.Delete)
                    users.GetFiles()[pos].Delete();                
            }
        }

        static Game ReadDataGame(string s)
        {
            string path = string.Format(@"Users/{0}", s);
            
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Game));

            Game a = new Game();

            a.snake.body.Clear();
            a.wall.body.Clear();
            

            a = xs.Deserialize(fs) as Game;
            
            fs.Close();
            return a;
        }
        static void SaveDataGame(Game a, bool s)
        {
            string name;
            if (s)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 11);
                Console.WriteLine("Only letters");
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Your Name:");
                Console.SetCursorPosition(41, 12);
                name = Console.ReadLine();
            }
            else
            {
                name = "new Game" + gamen.Split('.').Length;

            }


            string path = string.Format(@"Users/{0}.xml", name);
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
            Console.SetWindowSize(80, 30);
            Console.CursorVisible = false;
            ShowMenuBack();
            
            // GameProcess(game);
           
        }
    }
}
