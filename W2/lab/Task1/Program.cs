using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Stack(string path, int depth = 0, int alldepth = 5)
        {
            Stack<DirectoryInfo> s = new Stack<DirectoryInfo>();
            Stack<Stack<DirectoryInfo>> ss = new Stack<Stack<DirectoryInfo>>();            
            
            int x = -1;
            bool _x = true;

            while(ss.Count > x)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (_x)
                {
                    x = 0;
                    ss.Push(s);
                    _x = false;
                }
                else if(dir.FullName != ss.Peek().Peek().Parent.FullName)ss.Push(s);

                if (dir.GetDirectories().Length > ss.Peek().Count)
                {
                   
                    DirectoryInfo d = dir.GetDirectories()[ss.Peek().Count];
                    
                    for (int i = 0; i < depth; i++) Console.Write(" ");
                    Console.WriteLine(d.Name);
                    
                    ss.Peek().Push(d);
                    s = new Stack<DirectoryInfo>();
                    path = d.FullName;
                    depth += alldepth;
                    continue;
                }

                foreach (FileInfo f in dir.GetFiles())
                {
                    for (int i = 0; i < depth; i++) Console.Write(" ");
                    Console.WriteLine(f.Name);
                }
                depth -= alldepth;
                ss.Pop();
                path = dir.Parent.FullName;               
            }
        }

        static void Recourse(string path, int depth = 0, int alldepth = 5)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach(DirectoryInfo d in dir.GetDirectories())
            {
                for (int i = 0; i < depth; i++) Console.Write(" ");
                Console.WriteLine(d.Name);
                Recourse(d.FullName, depth + alldepth, alldepth);
            }

            foreach(FileInfo f in dir.GetFiles())
            {
                for (int i = 0; i < depth; i++) Console.Write(" ");
                Console.WriteLine(f.Name);
            }
        }

        static void Main(string[] args)
        {
            
            Stack(@"D:\IISemestr\PP2\task", 10, 3 );
            Console.WriteLine("-----------------------------------------------");
            Recourse(@"D:\IISemestr\PP2\task" , 10, 3);
            Console.ReadKey();
        }
    }
}
