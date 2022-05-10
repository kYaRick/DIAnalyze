﻿using System.Collections.Generic;
using System.Drawing;
using AlgorithmVisualizer.GraphTheory.Utils;
using AlgorithmVisualizer.Tracers;
using static AlgorithmVisualizer.GraphTheory.FDGV.GraphVisualizer;
using static AlgorithmVisualizer.Threading.PauseResumeSleep;

namespace AlgorithmVisualizer.GraphTheory.Algorithms
{
	class DFS : GraphAlgorithm
	{
		private readonly int from, to;
		private readonly HashSet<int> visited;

		private readonly Queue<int> q;
		private readonly QueueTracer<int> qTracer;

		public DFS(Graph graph, int _from, int _to) : base(graph)
		{
			from = _from;
			to = _to;
			visited = new HashSet<int>();
			q = new Queue<int>();
			qTracer = new QueueTracer<int>(q, panelLogG, "q: ", new PointF(0, 5), new SizeF(500, 40));
			q.Enqueue(from);
		}

		public override bool Solve() => Solve(from);
		private bool Solve(int at)
		{
			visited.Add(at);
			// Mark node on visit
			graph.MarkParticle(at, at == to ? Colors.Red : Colors.Orange);
			Sleep(Delay.Long);
			if (at == to) return true;
			qTracer.Trace();
			foreach (Edge edge in graph.AdjList[at])
			{
				// Does not mark edges to already visited nodes to better show backtracking
				if (!visited.Contains(edge.To))
				{
					// Mark edge on visit
					graph.MarkSpring(edge, Colors.Orange, Dir.Directed);
					q.Enqueue(edge.To);
					qTracer.Trace();

					Sleep(Delay.Medium);

					if (Solve(edge.To)) // Current edge is in a path to 'to'
					{
						// Mark edge, note that DFS does not guarantee the SP!
						graph.MarkSpring(edge, Colors.Green, Dir.Directed);
						graph.MarkParticle(at, Colors.Green);
						Sleep(Delay.Long);
						return true;
					}
					// Unmark edge after visit if not in path to 'to'
					graph.MarkSpring(edge, Colors.Visited, Dir.Directed);
					Sleep(Delay.Medium);
				}
			}
			// Unmark node after visit
			graph.MarkParticle(at, Colors.Visited, Colors.VisitedBorder);
			Sleep(Delay.Medium);
			return false;
		}
	}
}
