namespace Algorithms_CSharp.FullSearch
{
    using System;
    using System.Collections.Generic;

    class Loc
    {
        public int pos;
        public int depth;

        public Loc(int pos, int depth)
        {
            this.pos = pos;
            this.depth = depth;
        }
    }

    static class Hiding
    {
        static bool[] visited;

        public static void Run()
        {
            string line = Console.ReadLine();
            var inputs = line.Split(' ');

            int n = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            visited = new bool[200001];
            for (int i = 0; i < 200001; i++)
            {
                visited[i] = false;
            }

            Queue<Loc> q = new Queue<Loc>();

            q.Enqueue(new Loc(n, 0));

            while (q.Count != 0)
            {
                var curLoc = q.Dequeue();

                if (curLoc.pos < 0) continue;
                if (visited[curLoc.pos]) continue;

                visited[curLoc.pos] = true;

                if (curLoc.pos == k)
                {
                    Console.WriteLine(curLoc.depth);

                    break;
                }


                q.Enqueue(new Loc(curLoc.pos + 1, curLoc.depth + 1));
                q.Enqueue(new Loc(curLoc.pos - 1, curLoc.depth + 1));

                if (curLoc.pos < k)
                {
                    q.Enqueue(new Loc(curLoc.pos * 2, curLoc.depth + 1));
                }
            }
        }
    }
}
