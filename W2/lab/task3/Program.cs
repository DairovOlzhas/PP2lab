using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static bool IsPrime(int a)
        {
            for (int i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0) return false;

            return true;

        }

        static string Filereader(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();

            sr.Close();
            fs.Close();

            return s;
        }

        static void Filewriter(string path, string context)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(context);

            sw.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string context = Filereader(path);
            string res = "";

            int resmin = 2;
            Console.WriteLine(context);

            foreach (string t in context.Split(' '))
            {
                if (t != "" && IsPrime(int.Parse(t)))
                {
                    if (resmin > int.Parse(t)) resmin = int.Parse(t);
                }
                //   if(t != "" && IsPrime(int.Parse(t))) res = res + t +" ";
            }
            res = "min: " + resmin + ";";
            Console.WriteLine(res);

            Filewriter(path, res);


            Console.ReadKey();
        }
    }
}
