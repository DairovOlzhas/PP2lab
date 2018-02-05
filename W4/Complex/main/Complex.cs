using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    class Complex
    {
        int x;
        int y;



        public Complex() { }

        public Complex(string a)
        {
            x = int.Parse(a.Split('/')[0]);
            y = int.Parse(a.Split('/')[1]);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            int xr = new int();
            int yr = new int();

            int a1 = Math.Max(a.y, b.y);
            int b1 = Math.Min(a.y, b.y);

            int A = new int();
            int B = new int();

            for (int i = 1; i * a1 <= a1 * b1; i++)
            {
                if ((a1 * i) % b1 == 0)
                {
                    B = a1 * i;

                    break;
                }
            }

            A = (B / a.y) * a.x + (B / b.y) * b.x;

            for (int i = Math.Min(A, B); i > 0; i--)
            {
                if (A % i == 0 && B % i == 0)
                {
                    xr = A / i;
                    yr = B / i;
                    break;
                }
            }
            string res = xr + "/" + yr;
            Complex result = new Complex(res);
            return result;

        }

        public override string ToString()
        {
            return x + "/" + y;
        }
    }
}
