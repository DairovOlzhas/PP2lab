using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        string name;
        float wage;

        public Employee()
        {
            name = "Person";
            wage = 500;
        }

        public Employee(string a, int b)
        {
            name = a;
            wage = b;
        }

        public Employee(string a)
        {
            name = a;
        }

        public Employee(int a)
        {
            wage = a;
        }

        public override string ToString()
        {
            return name + " " + wage;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
