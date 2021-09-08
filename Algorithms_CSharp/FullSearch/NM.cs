namespace Algorithms_CSharp.FullSearch
{
    using System;

    class NM
    {
        static int N;
        static int M;

        static bool[] visited;

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            var inputs = line.Split(' ');
            N = int.Parse(inputs[0]);
            M = int.Parse(inputs[1]);

            visited = new bool[N];
            for (int i = 0; i < N; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < N; i++)
            {
                Search("", i, M);
            }
        }

        static void Search(string prevPerm, int startIdx, int remained)
        {
            if (startIdx == N) return;
            if (visited[startIdx]) return;

            visited[startIdx] = true;

            string curPerm = remained == M ? (startIdx + 1) + "" : prevPerm + " " + (startIdx + 1);

            if (remained == 1)
            {
                Console.WriteLine(curPerm);
                visited[startIdx] = false;

                return;
            }

            for (int i = 0; i < N; i++)
            {
                if (visited[i]) continue;

                Search(curPerm, i, remained - 1);
            }

            visited[startIdx] = false;
        }
    }
}
