using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using AlgorithmVisualizer.Tracers;
using AlgorithmVisualizer.GraphTheory.Utils;
using static AlgorithmVisualizer.GraphTheory.FDGV.GraphVisualizer;
using System.Drawing;
using static AlgorithmVisualizer.Threading.PauseResumeSleep;
using System.Windows.Forms;

namespace AlgorithmVisualizer.GraphTheory.Algorithms
{
	class BFS : GraphAlgorithm
	{
		public bool IsIgnoreDelay { get; private set; } = false;
		public bool IsToUp { get; private set; } = false;

		private readonly int from, to;
		private readonly Queue<int> q;
		private readonly HashSet<int> visited;

		private readonly QueueTracer<int> qTracer;

		private bool isWayFind = false;
		private List<int> way = new List<int>();

		public BFS(Graph graph, int _from, int _to, bool isToUp = false, bool isIgnoreDelay = false) : base(graph)
		{
			IsIgnoreDelay = isIgnoreDelay;
			IsToUp = isToUp;

			from = _from;
			to = _to;
			
			q = new Queue<int>();
			visited = new HashSet<int>();
			qTracer = new QueueTracer<int>(q, panelLogG, "q: ", new PointF(0, 5), new SizeF(500, 40));
			
			q.Enqueue(from);
			visited.Add(from);
		}

		public override bool Solve()
		{
			return Solve(out double msTime);
		}

		public bool Solve(out double msTime)
		{
			bool isSuccess = false;

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			if (!IsIgnoreDelay)
				Sleep(Delay.Long);

			while (q.Count > 0)
			{
				qTracer.Mark(0, Colors.Red);
				int at = q.Dequeue();

				if (!IsIgnoreDelay)
                {
					// Mark node on visit
					graph.MarkParticle(at, at == to ? Colors.Red : Colors.Orange);
					Sleep(Delay.Medium);
                }

				qTracer.Trace();

				if (!IsIgnoreDelay)
					Sleep(Delay.Medium);

				if (at == to)
				{
					isSuccess = true;
					break;
				}

				VisitNeighbors(at);

				if (!IsIgnoreDelay)
                {
					// Unmark node after visit
					graph.MarkParticle(at, Colors.Visited, Colors.VisitedBorder);
					Sleep(Delay.Medium);
                }
			}

			stopWatch.Stop();

			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = stopWatch.Elapsed;
			msTime = ts.TotalMilliseconds;

			string result = "";

			if (isWayFind)
            {
				var wlen = way.Count;


				for (int i = 0; i < wlen-1; i++)
				{ 
                    result += way[i] + " -> ";
                };

				result = $"[{result+way[wlen-1]}]";
            }
            else
				result = "was not find.";

            MessageBox.Show($"Visited: {visited.Count}\n" +
                $"Way {result}");

			return isSuccess;
		}

        private void VisitNeighbors(int at)
		{
			int len = graph.AdjList[at].Count;

            if (!isWayFind)
            {
				if (graph.AdjList[at].Any(ed => ed.From.Equals(at)))
                {
					way.Add(at);
				} 
				else
                {
					way.RemoveAt(way.Count-1);
					way.Add(at);
                }

				for (int i = IsToUp ? 0 : len - 1; (IsToUp ? i < len : i >= 0);)
                {
                    if (graph.AdjList[at][i].To.Equals(to))
                    {
						way.Add(to);
						isWayFind = true;
						break;
                    }

					if (IsToUp)
						i++;
					else
						i--;

				}
            }

            for (int i = IsToUp ? 0 : len - 1; (IsToUp ? i < len : i >= 0);)
            {
                Edge edge = graph.AdjList[at][i];

                // Mark edge on visit
                if (!IsIgnoreDelay)
                {
                    //Unmark edge after visit
                    graph.MarkSpring(edge, Colors.Orange, Dir.Directed);
                    Sleep(Delay.Medium);
                }

                // Avoid edges to visited nodes
                if (!visited.Contains(edge.To))
                {
                    visited.Add(edge.To);
                    q.Enqueue(edge.To);
                    qTracer.Trace();
                }

                if (!IsIgnoreDelay)
                {
                    //Unmark edge after visit
                    graph.MarkSpring(edge, Colors.Visited, Dir.Directed);
                    Sleep(Delay.Medium);
                }

                if (IsToUp)
                    i++;
                else
                    i--;
            }
        }
    }
}
