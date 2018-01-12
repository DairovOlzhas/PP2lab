using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    class Program
    {
        static bool ispal(int a) // Функция на проверку является ли число простым
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
            string[] a = Console.ReadLine().Split(' '); // читаем строку и разделяем прбела помещяя результат в массив
            for (int i = 0; i < a.Length; i++)
            {
                if (ispal(int.Parse(a[i]))) // конвертируем из int в string b и кидаем в фнкцию
                    Console.WriteLine(a[i]); // выводим если простое 
            }
            Console.ReadKey();
        }
    }
}
