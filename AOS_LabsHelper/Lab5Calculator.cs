using System;
using System.Collections.Generic;

namespace AOS_LabsHelper
{
    public partial class Lab5Calculator
    {
        private const double t_obs = 0.1;
        private const double lambda_def = 520;
        public const int n = 53;
        private const double Pwx = 0.829;
        private const double Nx = 0.58;
        private double Pw = 0.307;

        //public const double t_obs = 0.2;
        //public const double lambda = 280;
        //public const int n = 58;

        // n opt = 58!!!!
        private double u = 1 / t_obs;

        public void Calculate()
        {
            Console.WriteLine("Po = " + Get_P_0());
            Console.WriteLine("Pw = " + Get_P_w());
            //var dictionary = Calculate_1_N();
            //var dictionary2 = Calculate_2_Lambda();
            //var dictionary3 = Calculate_3_t_obs();
            Console.WriteLine();
        }

        public Dictionary<int, double> Calculate_1_N()
        {
            var calc_n = n;
            double Pw = Get_P_w(n: calc_n);
            double Pw_increase = Get_P_w(n: calc_n + 1);
            double Pw_reduce = Get_P_w(n: calc_n - 1);
            var values_dictionary = new Dictionary<int, double>();
            int steps = 20;
            if (Pw_increase < Pw)
            {
                calc_n = n - 2;
                log("Increase better!", ConsoleColor.Green);
                for (int i = 0; i < steps; i++, calc_n++)
                {
                    var value = Get_P_w(n: calc_n);
                    if (calc_n == n || Math.Round(value, 3) == this.Pw)
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
                calc_n = n + 2;
                log("Reduce better!", ConsoleColor.Red);
                for (int i = 0; i < steps; i++, calc_n--)
                {
                    var value = Get_P_w(n: calc_n);
                    if (calc_n == n || Math.Round(value, 3) == this.Pw)
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

        public Dictionary<double, double> Calculate_2_Lambda()
        {
            var calc_lambda = lambda_def;
            double reduceStep = 0.5;
            double Pw = Get_P_w(lambda: calc_lambda);
            double Pw_increase = Get_P_w(lambda: calc_lambda + reduceStep);
            double Pw_reduce = Get_P_w(lambda: calc_lambda - reduceStep);
            var values_dictionary = new Dictionary<double, double>();
            int steps = 50;
            if (Pw_increase < Pw)
            {
                calc_lambda = lambda_def - 5;
                log("Increase better!", ConsoleColor.Green);
                for (int i = 0; i < steps; i++, calc_lambda += reduceStep)
                {
                    var value = Get_P_w(lambda: calc_lambda);
                    if (calc_lambda == lambda_def || Math.Round(value, 3) == this.Pw)
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Red);
                        Console.Beep();
                    }
                    else
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Cyan);
                    }
                    values_dictionary.Add(calc_lambda, value);
                }
            }
            else if (Pw_reduce < Pw)
            {
                calc_lambda = lambda_def + 5;
                log("Reduce better!", ConsoleColor.Red);
                for (int i = 0; i < steps; i++, calc_lambda -= reduceStep)
                {
                    var value = Get_P_w(lambda: calc_lambda);
                    if (calc_lambda == lambda_def || Math.Round(value, 3) == this.Pw)
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Red);
                        Console.Beep();
                    }
                    else
                    {
                        log($"lambda = {calc_lambda}\nPw={value}", ConsoleColor.Cyan);
                    }
                    values_dictionary.Add(calc_lambda, value);
                }
            }
            else
                log("Nothing...", ConsoleColor.Yellow);

            return values_dictionary;
        }

        public Dictionary<double, double> Calculate_3_t_obs()
        {
            var calc_t_obs = t_obs;
            double Pw = Get_P_w(t_obs: calc_t_obs);
            double Pw_increase = Get_P_w(t_obs: calc_t_obs + 0.1);
            double Pw_reduce = Get_P_w(t_obs: calc_t_obs - 0.1);
            var values_dictionary = new Dictionary<double, double>();
            int steps = 30;
            if (Pw_increase < Pw)
            {
                calc_t_obs = t_obs - 0.02;
                log("Increase better!", ConsoleColor.Green);
                for (int i = 0; i < steps; i++, calc_t_obs += 0.01)
                {
                    var value = Get_P_w(t_obs: calc_t_obs);
                    if (Math.Round(calc_t_obs, 2) == t_obs || Math.Round(value, 3) == this.Pw)
                    {
                        log($"t_obs = {calc_t_obs}\nPw={value}", ConsoleColor.Red);
                    }
                    else
                    {
                        log($"t_obs = {calc_t_obs}\nPw={value}", ConsoleColor.Cyan);
                    }
                    values_dictionary.Add(calc_t_obs, value);
                }
            }
            else if (Pw_reduce < Pw)
            {
                calc_t_obs = t_obs + 0.02;
                log("Reduce better!", ConsoleColor.Red);
                for (int i = 0; i < steps; i++, calc_t_obs -= 0.01)
                {
                    var value = Get_P_w(t_obs: calc_t_obs);
                    if (Math.Round(calc_t_obs, 1) == t_obs || Math.Round(value, 3) == this.Pw)
                    {
                        log($"t_obs = {calc_t_obs}\nPw={value}", ConsoleColor.Red);
                    }
                    else
                    {
                        log($"t_obs = {calc_t_obs}\nPw={value}", ConsoleColor.Blue);
                    }
                    values_dictionary.Add(calc_t_obs, value);
                }
            }
            else
                log("Nothing...", ConsoleColor.Yellow);

            return values_dictionary;
        }

        public double Get_P_0(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            u = 1 / t_obs;
            double row_sum = Get_Sum_Row(to: n);

            double second_part = u / Get_n_fact_minus(n: n, lambda: lambda); // u / (n-1)! * (nu-l)
            double third_part = Get_lambda_by_u(n, lambda);

            double answer = 1 / (row_sum + second_part * third_part); // Po

            return answer;
        }

        public double Get_P_w(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            u = 1 / t_obs;
            double top_part = u * Get_P_0(n: n, lambda: lambda); // u * Po
            double first_drib = top_part / Get_n_fact_minus(n: n, lambda: lambda);
            double answ = first_drib * Get_lambda_by_u(n, lambda);
            return answ;
        }

        private double Get_n_fact_minus(int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            double n_minus_1_fact = Helper.FactTree(n - 1); // (n-1)!
            double n_u_minus_lambda = (n * u) - lambda; // (n * u) - lambda
            double answ = n_minus_1_fact * n_u_minus_lambda;
            return answ;
        }

        private double Get_lambda_by_u(int pow, double l = lambda_def)
        {
            return Math.Pow(l / u, pow);
        }

        private double Get_Sum_Row(int from = 1, int to = n, double l = lambda_def)
        {
            double row_sum = 0;
            for (int i = from; i <= to; i++)
            {
                double k_fact = Helper.FactTree(i);
                double left_side = 1 / k_fact;
                double right_side = Get_lambda_by_u(i, l);
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

        public double Get_Pw()
        {
            return Pw;
        }

        public double Get_Lambda()
        {
            return lambda_def;
        }

        public double Get_t_obs()
        {
            return t_obs;
        }
    }
}