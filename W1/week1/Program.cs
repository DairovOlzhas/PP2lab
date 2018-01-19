using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    class Program
    {
        static bool Prime(int a) // Функция на проверку является ли число простым
        {
            for (int i = 2; i <= Math.Sqrt(a); i++) // ищем делитель 
            {
                if (a % i == 0) /* если найдем хотя бы один делитель число не будует простым */
                    return false;
            }
            return true;

        }
        static void Main(string[] args)
        {
            foreach (string s in args)
            {
                if (Prime(int.Parse(s))) Console.WriteLine(s); // конвертируем из int в string b и кидаем в фнкцию выводим если простое
            }
            
            Console.ReadKey();
        }
    }
}
