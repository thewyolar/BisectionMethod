using System;

namespace BisectionMethod
{
    class Program
    {
        /** Функция, определяющая знак.
         * Если число положительное, возвращает true.
         * Если же число отрицательное, возвращает false. 
        */
        public static bool Sign(double x)
        {
            return (x > 0) ? true : false;
        }

        /** Функция, реализующая метод половинного деления (бисекции).
         * xn - начало отрезка по x.
         * xk - конец отрезка по x.
         * xi - середина отрезка по x;
         * eps - требуемая точность вычислений по y.
        */
        public static double BisectionMethod(Func<double, double> F, double xn, double xk, double eps = 1e-10)
        {
            double dx, xi = 0;

            if (F(xn) == 0)
                return xn;

            if (F(xk) == 0)
                return xk;

            while (xk - xn > eps)
            {
                dx = (xk - xn) / 2;
                xi = xn + dx;

                if (Sign(F(xn)) != Sign(F(xi)))
                {
                    xk = xi;
                }
                else
                {
                    xn = xi;
                }
            }

            return xi;
        }

        static void Main(string[] args)
        {
            //локальная функция
            double f(double x) => Math.Log(x) * Math.Log(x) - Math.Log(x) - 2;

            Console.WriteLine("Метод бисекции\n");
            Console.Write("Введите начало отрезка: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите конец отрезка: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите точность вычислений: ");
            double eps = double.Parse(Console.ReadLine());

            double result = BisectionMethod(f, a, b, eps);

            Console.WriteLine($"x = {result}");
            Console.WriteLine($"f({result}) = {f(result)}");

            Console.WriteLine("Для выхода нажмите клавишу Enter...");
            Console.ReadKey();
        }
    }
}
