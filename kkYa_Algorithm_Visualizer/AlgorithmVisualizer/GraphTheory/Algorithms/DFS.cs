using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AlgorithmVisualizer.GraphTheory.Utils;
using AlgorithmVisualizer.Tracers;
using static AlgorithmVisualizer.GraphTheory.FDGV.GraphVisualizer;
using static AlgorithmVisualizer.Threading.PauseResumeSleep;

namespace AlgorithmVisualizer.GraphTheory.Algorithms
{
	class DFS : GraphAlgorithm
	{
		public bool IsIgnoreDelay { get; private set; } = false;
		public bool IsToUp { get; private set; } = false;

		private readonly int from, to;
		private readonly HashSet<int> visited;

		private readonly Queue<int> q;
		private readonly QueueTracer<int> qTracer;

		private bool isWayFind = false;
		private List<int> way = new List<int>();

		public DFS(Graph graph, int _from, int _to, bool isToUp = false, bool isIgnoreDelay= false) : base(graph)
		{
			IsIgnoreDelay = isIgnoreDelay;
			IsToUp = isToUp;

			from = _from;
			to = _to;
			
			visited = new HashSet<int>();
			q = new Queue<int>();
			qTracer = new QueueTracer<int>(q, panelLogG, "q: ", new PointF(0, 5), new SizeF(500, 40));
			q.Enqueue(from);
		}

		public override bool Solve()
        {
			return false;
        }

		public bool Solve(int at, out double msTime)
		{
			bool isSuccess = prSolve(from, out msTime);

			string result = "";
			int len = way.Count;

			if (len > 0)
            {
				for (int i = len-1; i>-1; i--)
                {
					result += way[i] + " -> ";
                }
				result = $"[{result + to}]";
            }
			else
				result = "was not find.";

			MessageBox.Show($"Visited: {visited.Count}\n" +
				$"Way {result}");

			return isSuccess;
		}
		public bool prSolve(int at, out double msTime)
		{
			bool isSuccess = false;
			visited.Add(at);

            if (!IsIgnoreDelay)
            {
				// Mark node on visit
				graph.MarkParticle(at, at == to ? Colors.Red : Colors.Orange);
                Sleep(Delay.Long);
            }

            if (at == to) isSuccess=true;

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			qTracer.Trace();
			
			int len = graph.AdjList[at].Count;
			
			for (int i = IsToUp ? 0 : len - 1; (IsToUp ? i < len : i >= 0);)
			{
				Edge edge = graph.AdjList[at][i];

				// Does not mark edges to already visited nodes to better show backtracking
				if (!visited.Contains(edge.To))
				{
					q.Enqueue(edge.To);
					qTracer.Trace();

					if (!IsIgnoreDelay)
					{
						// Mark edge on visit
						graph.MarkSpring(edge, Colors.Orange, Dir.Directed);
						Sleep(Delay.Medium);
					}

					if (prSolve(edge.To, out double unusedTime)) // Current edge is in a path to 'to'
					{
						// Mark edge, note that DFS does not guarantee the SP!
						graph.MarkSpring(edge, Colors.Green, Dir.Directed);
						graph.MarkParticle(at, Colors.Green);
						
						if (!IsIgnoreDelay)
						{
							Sleep(Delay.Long);
						}

						way.Add(at);

						isSuccess = true;
						break;
					}

                    graph.MarkSpring(edge, Colors.Visited, Dir.Directed);
                    
					if (!IsIgnoreDelay)
                    {
                        // Unmark edge after visit if not in path to 'to'
                        Sleep(Delay.Medium);
                    }
                }

				if (IsToUp)
					i++;
				else
					i--;
			}

            // Unmark node after visit
            graph.MarkParticle(at, Colors.Visited, Colors.VisitedBorder);
            
			if (!IsIgnoreDelay)
            {
                Sleep(Delay.Medium);
            }

            stopWatch.Stop();

			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = stopWatch.Elapsed;
			msTime = ts.TotalMilliseconds;

			return isSuccess;
		}
	}
}
