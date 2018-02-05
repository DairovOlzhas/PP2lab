using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace main
{
    class Program
    {
        static List<string> results = new List<string>();


        static void Calculator()
        {
            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            while (btn.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                bool exit = false;
                Console.WriteLine("Write two complex number like '1/8 2/8'");
                string s;
                try
                {
                    s = Console.ReadLine();

                    Complex a = new Complex(s.Split(' ')[0]);
                    Complex b = new Complex(s.Split(' ')[1]);

                    Console.WriteLine(a + b);
                    Complex res = a + b;
                    Console.ReadKey();
                    SaveToBuffer(a + " + " + b + " = " + res);
                    btn = Console.ReadKey();
                }
                catch
                {
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
                    else continue;

                }
            }
        }
        static void ShowResults()
        {
            Console.Clear();
            foreach (string res in results)
            {
                Console.WriteLine(res);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
            SaveData(results);
        }
        static void SaveToBuffer(string text)
        {
            results.Add(text);
            SaveData(results);
        }


        static void ShowMenuBack()
        {
            int pos = 0;
            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            bool exit = false;
            while (true)
            {
                if (pos > 2) pos = 0;
                if (pos < 0) pos = 2;
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
                            Calculator();
                        if (pos == 1)
                            ShowResults();
                        if (pos == 2)
                            exit = true;
                        break;
                }
                if (exit) break;
            }
        }
        static void ShowMenu(int pos)
        {
            Console.Clear();
            string[] buttons = { "Calculator", "Show History", "Exit" };
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


        static List<string> ReadData()
        {
            string path = "data.xml";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<string>));

            List<string> a = xs.Deserialize(fs) as List<string>;
            fs.Close();
            return a;
        }
        static void SaveData(List<string> a)
        {
            string path = "data.xml";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<string>));

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
            results = ReadData();
            ShowMenuBack();
            SaveData(results);
        }
    }
}
