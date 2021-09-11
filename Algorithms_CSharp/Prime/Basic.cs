namespace Algorithms_CSharp.Prime
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class BasicPrime
    {
        private const int MAX_NUM = 1000000;
        private static int[] era;

        public static void Run()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int m = int.Parse(inputs[0]);
            int n = int.Parse(inputs[1]);

            MakeEra();

            List<int> results = new List<int>();
            for (int i = m; i <= n; i++)
            {
                if (era[i] != 0)
                {
                    results.Add(i);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < results.Count; i++)
            {
                sb.Append(results[i] + Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }

        private static void MakeEra()
        {
            era = new int[MAX_NUM + 1];

            for (int i = 0; i < MAX_NUM + 1; i++)
            {
                era[i] = i;
            }

            era[0] = 0;
            era[1] = 0;

            for (int i = 2; i < Math.Sqrt(MAX_NUM); i++)
            {
                if (era[i] == 0) continue;

                for (int j = i + i; j < MAX_NUM + 1; j += i)
                {
                    era[j] = 0;
                }
            }
        }
    }
}
