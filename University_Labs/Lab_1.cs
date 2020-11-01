using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace University_Labs
{
    public class Lab_1
    {
        public double t_obs = 0.1;
        public double lambda = 100;
        public double n = 12;
        public double P_nobs = 0.943;
        public double P_t = 0.9;
        public double P_lambda = 0.64;
        //public double t_obs = 0.18;
        //public double n = 6;
        //public double lambda = 50;
        //public double P_n = 0.946;
        //public double P_t = 0.827;
        //public double P_lambda = 0.949;

        public void calculateMain(Chart chart)
        {
            int ans = 0;
            //ans = calculate(n, chart);
            //while (ans != 0)
            //{
            //    if (ans == 1)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("--------------------");
            //        Console.ResetColor();
            //        n += 1;
            //        ans = calculate(n, chart);
            //        continue;
            //    }
            //    else if (ans == -1)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("--------------------");
            //        Console.ResetColor();
            //        n -= 1;
            //        ans = calculate(n, chart);
            //        continue;
            //    }
            //}
            for (double i = 60; i < 260; i += 20)
            {
                calculate(i, chart);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"answer = {ans}\nn={n}");
            Console.ResetColor();
        }

        public int calculate(double t, Chart chart)
        {
            Console.ResetColor();
            double P_0, P_n, P_obs, alfa, sum, N_k, K_zan, N_0, K_prostoiu;
            P_0 = P_n = P_obs = sum = alfa = N_k = K_zan = 0;
            lambda = t;
            alfa = lambda * t_obs;
            Console.WriteLine($"alfa = lambda * t_obs = {lambda} * {t_obs} = {alfa}");

            for (int i = 0; i <= n; i++)
            {
                var pow = Math.Pow(alfa, i);
                var fact = FactTree(i);
                var temp = pow / fact;
                sum += temp;
                if (i == n)
                    Console.WriteLine($"----------\ni = {i}\npow = {pow}\nfact = {fact}\ntemp = {temp}\nsum = {sum}");
            }
            P_0 = 1 / sum;
            Console.ResetColor();
            Console.WriteLine($"P_0 = {P_0}");
            P_n = Math.Pow(alfa, n) / (FactTree((int)n)) * P_0;
            Console.WriteLine($"P_n = {P_n}");
            P_obs = 1 - P_n;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"P_обслуговування = {P_obs}");
            Console.ResetColor();
            N_k = alfa * P_obs;
            Console.WriteLine($"N_k = {N_k}");
            K_zan = N_k / n;
            Console.WriteLine($"K_занятостi = {K_zan}");
            sum = 0;
            for (int k = 0; k <= n; k++)
            {
                var pow = Math.Pow(alfa, k);
                var fact = FactTree(k);
                var temp = (pow * (n - k)) / fact;
                sum += temp;
                if (k == n)
                    Console.WriteLine($"----------\ni = {k}\npow = {pow}\nfact = {fact}\ntemp = {temp}\nsum = {sum}");
            }
            Console.ResetColor();
            N_0 = sum * P_0;
            Console.WriteLine($"N_0 = {N_0}");
            K_prostoiu = N_0 / n;
            Console.WriteLine($"K_prostoiu = {K_prostoiu}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"t_obs = {t_obs}");
            Console.ResetColor();
            chart.Series[0].Points.AddXY(lambda, P_lambda);
            chart.Series[1].Points.AddXY(lambda, P_obs);

            if (Math.Round(P_lambda, 3) == Math.Round(P_obs, 3))
                return 0;
            else if (Math.Round(P_lambda, 3) < Math.Round(P_obs, 3))
                return -1;
            else
                return 1;
            //chart.Series[0].Points.AddXY(n, P_nobs);
            //chart.Series[1].Points.AddXY(n, P_obs);

            //if (Math.Round(P_nobs, 3) == Math.Round(P_obs, 3))
            //    return 0;
            //else if (Math.Round(P_nobs, 3) < Math.Round(P_obs, 3))
            //    return -1;
            //else
            //    return 1;
        }

        private static double ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (double)l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        private static double FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }
    }
}