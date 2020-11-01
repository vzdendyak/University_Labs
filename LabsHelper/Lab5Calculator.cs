using System;
using System.Collections.Generic;

namespace LabsHelper
{
    public class Lab5Calculator
    {
        private const double t_obs = 0.1;
        private const double lambda = 520;
        public const int n = 53;
        private const double Pwx = 0.829;
        private const double Nx = 0.58;

        //public const double t_obs = 0.2;
        //public const double lambda = 280;
        //public const int n = 58;

        private const double u = 1 / t_obs;

        public void Calculate()
        {
            Console.WriteLine("Po = " + Get_P_0());
            Console.WriteLine("Pw = " + Get_P_w());
            //var dictionary = Calculate_1_N();
            //Console.WriteLine();
        }

        public Dictionary<int, double> Calculate_1_N()
        {
            var calc_n = n;
            double Pw = Get_P_w(calc_n);
            double Pw_increase = Get_P_w(calc_n + 1);
            double Pw_reduce = Get_P_w(calc_n - 1);
            var values_dictionary = new Dictionary<int, double>();
            calc_n -= 5;
            if (Pw_increase < Pw)
            {
                log("Increase better!", ConsoleColor.Green);
                for (int i = 0; i < 20; i++, calc_n++)
                {
                    var value = Get_P_w(calc_n);
                    if (calc_n == n)
                    {
                        log($"N = {calc_n}\nPw={value}", ConsoleColor.Red);
                    }
                    else
                    {
                        log($"N = {calc_n}\nPw={value}", ConsoleColor.Cyan);
                    }
                    values_dictionary.Add(calc_n, value);
                }
            }
            else if (Pw_reduce < Pw)
            {
                log("Reduce better!", ConsoleColor.Red);
                for (int i = 0; i < 20; i++, calc_n--)
                {
                    var value = Get_P_w(calc_n);
                    if (calc_n == n)
                    {
                        log($"N = {calc_n}\nPw={value}", ConsoleColor.Red);
                    }
                    else
                    {
                        log($"N = {calc_n}\nPw={value}", ConsoleColor.Blue);
                    }
                    values_dictionary.Add(calc_n, value);
                }
            }
            else
            {
                log("Nothing...", ConsoleColor.Yellow);
            }
            return values_dictionary;
        }

        public double Get_P_0(int n = n)
        {
            double row_sum = Get_Sum_Row(to: n);

            double second_part = u / Get_n_fact_minus(n); // u / (n-1)! * (nu-l)
            double third_part = Get_labmbda_by_u(n);

            double answer = 1 / (row_sum + second_part * third_part); // Po

            return answer;
        }

        public double Get_P_w(int n = n)
        {
            double top_part = u * Get_P_0(n); // u * Po
            double first_drib = top_part / Get_n_fact_minus(n);
            double answ = first_drib * Get_labmbda_by_u(n);
            return answ;
        }

        private double Get_n_fact_minus(int n = n)
        {
            double n_minus_1_fact = Helper.FactTree(n - 1); // (n-1)!
            double n_u_minus_lambda = (n * u) - lambda; // (n * u) - lambda
            double answ = n_minus_1_fact * n_u_minus_lambda;
            return answ;
        }

        private double Get_labmbda_by_u(int pow)
        {
            return Math.Pow(lambda / u, pow);
        }

        private double Get_Sum_Row(int from = 1, int to = n)
        {
            double row_sum = 0;
            for (int i = from; i <= to; i++)
            {
                double k_fact = Helper.FactTree(i);
                double left_side = 1 / k_fact;
                double right_side = Get_labmbda_by_u(i);
                double answ = left_side * right_side;
                row_sum += answ;
            }
            return row_sum;
        }

        private void log(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------");
            Console.ResetColor();
        }

        public int Get_n()
        {
            return n;
        }
    }

    public class Chart_Answer
    {
        public double Key { get; set; }
        public double Value { get; set; }
    }
}