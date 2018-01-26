using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program
    {
        static void ShowFileContent(FileInfo file)
        {
            Console.Clear();
            
            string[] context = File.ReadAllLines(file.FullName);

            foreach (string s in context)
                Console.WriteLine(s);

            
            ConsoleKeyInfo btn = Console.ReadKey();
            while(btn.Key != ConsoleKey.Escape)
            {
                btn = Console.ReadKey();
            }
        }
        
        static void ShowDirectoryContent(DirectoryInfo dir, int pos)
        {
            

            FileSystemInfo[] cur = dir.GetFileSystemInfos();
            int fl = 0;
            int ll = cur.Length;
            if(cur.Length > 20)            
                ll = 20;
                        
            if (pos + 10 > ll)
                ll = pos + 10;

            if (pos > 10)
                fl = pos - 9;
                   
            if(pos + 10 > cur.Length)
            {
                fl = cur.Length - 20;
                ll = cur.Length;
            }
            
            for (int i = fl; i < ll; i++ )
            {

                if (cur[i].GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.White;
                if (cur[i].GetType() == typeof(FileInfo))
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                if (i != pos)
                    Console.BackgroundColor = ConsoleColor.Black;
               
                if (i == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(cur[i].Name);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void Main(string[] args)
        {
            string path = @"D:\IISemestr\PP2\task";
            DirectoryInfo dir = new DirectoryInfo(path);
            int pos = 0;

            Console.CursorVisible = false;


            while (true)
            {
                Console.Clear();
                ShowDirectoryContent(dir, pos);
                
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {                   
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos > dir.GetFileSystemInfos().Length - 1)
                            pos = 0;
                        break;

                    case ConsoleKey.Enter:
                        if (dir.GetFileSystemInfos()[pos].GetType() == typeof(FileInfo))
                        {
                            FileInfo f = new FileInfo(dir.GetFileSystemInfos()[pos].FullName);
                            ShowFileContent(f);
                        }
                        else
                        {
                            dir = new DirectoryInfo(dir.GetFileSystemInfos()[pos].FullName);                            
                        }
                        break;

                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        break;

                    case ConsoleKey.Backspace:
                        dir = dir.Parent;
                        break;
                }



            }
        }
    }
}
