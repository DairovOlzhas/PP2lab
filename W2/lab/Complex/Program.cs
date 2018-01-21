using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Write two complex number like '1/8 2/8'");
                string s = Console.ReadLine();
                Complex a = new Complex(s.Split(' ')[0]);
                Complex b = new Complex(s.Split(' ')[1]);

                Console.WriteLine(a + b);

                Console.ReadKey();
            }
            
        }
    }
}
