namespace Algorithms_CSharp.Network
{
    using System;

    static class MaxPipeFlow
    {
        const int ALPHABET_CNT = 52;
        private const int FLOW_MAX = 1000;
        private const int UNDEFINED = -1;
        static bool[] visited;
        static int[,] flow;

        public static void Run()
        {
            var nStr = Console.ReadLine();

            int N = int.Parse(nStr);

            visited = new bool[ALPHABET_CNT];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            flow = new int[ALPHABET_CNT, ALPHABET_CNT];

            for (int i = 0; i < ALPHABET_CNT; i++)
            {
                for (int j = 0; j < ALPHABET_CNT; j++)
                {
                    flow[i, j] = -1;
                }
            }

            for (int i = 0; i < N; i++)
            {
                var inputs = Console.ReadLine().Split();

                int p1, p2;
                p1 = inputs[0][0] >= 'a' && inputs[0][0] <= 'z' ? inputs[0][0] - 'a' : inputs[0][0] - 'A' + ALPHABET_CNT / 2;
                p2 = inputs[1][0] >= 'a' && inputs[1][0] <= 'z' ? inputs[1][0] - 'a' : inputs[1][0] - 'A' + ALPHABET_CNT / 2;

                flow[p1, p2] = int.Parse(inputs[2]);
                flow[p2, p1] = int.Parse(inputs[2]);
            }

            int ret = GetMaxFlow(ALPHABET_CNT / 2, FLOW_MAX);

            Console.WriteLine(ret);
        }

        private static int GetMaxFlow(int curIdx, int maxFlow)
        {
            if (curIdx == 'Z' - 'A' + ALPHABET_CNT / 2) return maxFlow;
            visited[curIdx] = true;

            int aggMaxFlow = UNDEFINED;
            for (int i = 0; i < ALPHABET_CNT; i++)
            {
                if (flow[curIdx, i] == UNDEFINED) continue;
                if (visited[i]) continue;

                int ret = GetMaxFlow(i, Math.Min(maxFlow, flow[curIdx, i]));
                aggMaxFlow = Math.Max(aggMaxFlow, ret);
            }

            visited[curIdx] = false;

            return aggMaxFlow;
        }
    }
}
