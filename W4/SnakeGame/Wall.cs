using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Wall
    {
        public List<Point> body;
        public char sign = '#';
        public int level;
        public int score;
        public ConsoleColor color = ConsoleColor.Magenta;

        public Wall()
        {
            body = new List<Point>();
            ReadLevel(1);
        }

        public void Draw()
        {
            foreach(Point p in body)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void ReadLevel(int level)
        {
            string FullName = string.Format(@"Levels/Level{0}.txt", level);
            FileStream fs = new FileStream(FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            score = int.Parse(sr.ReadLine());

            int row = 0;
            while(row < 30)
            {
                string r = sr.ReadLine();
                for(int col = 0; col < r.Length; col++)
                {
                    if (r[col] == '#')
                        body.Add(new Point(col, row));
                }
                row++;
            }
            sr.Close();
            fs.Close();
        }

    }
}
