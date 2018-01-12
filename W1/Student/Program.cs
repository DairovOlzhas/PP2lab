using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string name;
        public int age;
        public float gpa;

        public Student()
        {
            name = "Student";
            age = 18;
            gpa = 0;
        }

        public Student(string n, int a, float g)
        {
            name = n;
            age = a;
            gpa = g;
        }
        public override string ToString()
        {
            return name + " " + age + " " + gpa;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
