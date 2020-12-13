using System;
using System.Collections.Generic;

namespace AOS_LabsHelper
{
    public partial class Lab5Calculator
    {
        public Dictionary<double, double> Calculate_21_K()
        {
            var values_dictionary = new Dictionary<double, double>();
            int steps = 80;

            for (double i = 0; i < steps; i += 3)
            {
                double value = 0;
                if (i < n)
                {
                    value = Get_P_k_1(k: i, n: 58);
                    log($"K = {i}\nPk={value}", ConsoleColor.Cyan);
                }
                else
                {
                    value = Get_P_k_2(k: i);
                    log($"K = {i}\nPk={value}", ConsoleColor.Cyan);
                }

                values_dictionary.Add(i, value);
            }
            return values_dictionary;
        }

        public double Get_P_k_1(double k, int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            u = 1 / t_obs;
            double k_fact = Helper.FactTree((int)k);
            double first = 1 / k_fact;
            double sec_one = calc_lambda_div_u_pow(pow: k);
            double second = sec_one * Get_P_0(n: n);

            double answ = first * second;
            return answ;
        }

        public double Get_P_k_2(double k, int n = n, double t_obs = t_obs, double lambda = lambda_def)
        {
            u = 1 / t_obs;
            double n_fact = Helper.FactTree(n); // n!
            double n_pow = Math.Pow(n, k - n); // n^k-n
            double first = 1 / n_fact * n_pow;
            double sec_one = calc_lambda_div_u_pow(pow: k);
            double second = sec_one * Get_P_0();

            double answ = first * second;
            return answ;
        }

        public double calc_lambda_div_u_pow(double lambda = lambda_def, double u = 1 / t_obs, double pow = 1)
        {
            return Math.Pow(lambda / u, pow);
        }
    }
}