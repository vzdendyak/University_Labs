using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS_LabsHelper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Lab5Calculator l5 = new Lab5Calculator();
            //l5.Calculate();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Choose part:\n1 - 1.1 (N)\n2 - 1.2 (lambda)\n3 - 1.3 (t_obs)\n0 - Exit");
                var ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        l5.Calculate_1_N();
                        break;

                    case "2":
                        l5.Calculate_2_Lambda();
                        break;

                    case "3":
                        l5.Calculate_3_t_obs();
                        break;

                    case "0":
                        loop = false;
                        Console.WriteLine("Good-bye");
                        break;

                    default:
                        break;
                }
            }
            Console.Read();
        }
    }
}