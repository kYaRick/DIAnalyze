﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using AlgorithmVisualizer.Forms.Dialogs;
using AlgorithmVisualizer.GraphTheory.FDGV;
using AlgorithmVisualizer.Utils;

namespace AlgorithmVisualizer.GraphTheory
{
	/* A directed graph represented by an adjacency list.
	 * 
	 * Doesn't support multigraphs, i.e, has the following limitations:
	 * Edges of the form (u, u, x) MAY NOT exist. (self loop)
	 * Edges of the form (u, v, x1), (u, v, x2) MAY NOT coexist, even if x1 = x2. (parallel edges)
	 *
	 * The above limitations are imposed because the graph visualizer doesn't support visualizing such edges.
	 * 
	 * Note:
	 * Edges of the form (u, v, x1), (v, u, x2) MAY co-exist IFF x1 = x2, denoting a single undirected edge. */

	public class Graph : GraphVisualizer
	{
		// The adjacencey list
		public Dictionary<int, List<Edge>> AdjList { get; private set; }
		public int NodeCount { get { return nodeLookup.Count; } private set { } }
		public int EdgeCount { get; private set; } = 0;

		public Graph(PictureBox canvas, Graphics gLog) : base(canvas, gLog) =>
			AdjList = new Dictionary<int, List<Edge>>();

		#region Graph manipulation
		public void ClearGraph()
		{
			nodeLookup.Clear();
			AdjList.Clear();
			EdgeCount = 0;
			// Visuals
			ClearParticlesAndSprings();
		}
		public bool IsEmpty() => NodeCount == 0;
		public bool ContainsNode(int id) => nodeLookup.ContainsKey(id);
		public Edge GetRndEdge()
		{
			var edgeList = GetUndirectedEdgeList();
			return edgeList.Count > 0 ? edgeList[rnd.Next(edgeList.Count - 1)] : null;
		}

		public bool AddNode(int id)
		{
			if (ContainsNode(id)) return false;
			return AddNode(id, RndPosWithinCanvas());
		}
		public bool AddNode(Vector posVector)
		{
			for (int i = 0; i <= NodeCount; i++)
				if (!ContainsNode(i)) return AddNode(i, posVector);
			return false;
		}
		private bool AddNode(int id, Vector posVector)
		{
			Particle particle = new Particle(id, 0, posVector);
			nodeLookup[id] = particle;
			AdjList[id] = new List<Edge>();
			// For visualization
			AddParticle(particle);
			//Console.WriteLine("Node count: " + NodeCount);
			return true;
		}
		public bool RemoveNode(int id)
		{
			// Remove all edges coming from or going to 'id' (if exist) and update node/edge counts
			if (!ContainsNode(id)) return false;
			// Remove edges coming to 'id' in AdjList and update EdgeCount
			foreach (KeyValuePair<int, List<Edge>> entry in AdjList)
			{
				if (entry.Key != id) // ignore id's edge list
				{
					List<Edge> edgeList = entry.Value;
					for (int i = 0; i < edgeList.Count; )
					{
						if (edgeList[i].To == id)
						{
							edgeList.RemoveAt(i);
							EdgeCount--;
						}
						else i++;
					}
				}
			}
			// Remove id from AdjList and update edgeCount
			EdgeCount -= AdjList[id].Count;
			AdjList.Remove(id);
			// Visualization
			RemoveParticle(id);
			// Remove entry in nodeLookup
			// (can only be done after RemoveParticle as it uses nodeLookup)
			nodeLookup.Remove(id);
			return true;
		}

		public bool AddDirectedEdge(int from, int to, int cost)
		{
			// Both node id's present in nodeLookup and not trying to create a self loop
			if (to != from && ContainsNode(from) && ContainsNode(to))
			{
				// Creating the edge for addition (as a spring)
				Particle p1 = (Particle)nodeLookup[from], p2 = (Particle)nodeLookup[to];
				Spring spring = new Spring(p1, p2, cost);
				// If the adjList does not already contain the same edge (even of different cost)
				if (!(ResultsInParallelEdge(spring) || ResultsInInverseEdgesOfDiffCost(spring)))
				{
					// Add edge into AdjList
					AdjList[from].Add(spring);
					// For visualization
					AddSpring(spring);
					EdgeCount++;
					return true;
				}
			}
			return false;
		}
		public bool AddUndirectedEdge(int from, int to, int cost)
		{
			// Both node id's present in nodeLookup and not trying to create a self loop
			if (to != from && ContainsNode(from) && ContainsNode(to))
			{
				// Creating both edges for addition: (u, v, x), (v, u, x)
				// The first edge is created as a Spring extending the edge for the visualization
				Particle p1 = GetParticle(from), p2 = GetParticle(to);
				Spring spring = new Spring(p1, p2, cost),
					revSpring = new Spring(p2, p1, cost);
				// Prohibit More then 1 edge from A to B and vise versa
				if (!(ResultsInParallelEdge(spring) || ResultsInParallelEdge(revSpring)))
				{
					AdjList[from].Add(spring);
					AdjList[to].Add(revSpring);
					// Visualization (Adding the doubly linked spring):
					AddSpring(spring);
					AddSpring(revSpring);
					EdgeCount += 2;
					return true;
				}
			}
			return false;
		}
		public bool RemoveDirectedEdge(int from, int to, int cost)
		{
			// Removes specified edge, removes only 1 link if edge was doubly linked

			// Both node id's present in nodeLookup and not trying to remove a self loop
			if (to != from && ContainsNode(from) && ContainsNode(to))
			{
				// Creating a clone spring(edge) for removal
				Particle p1 = GetParticle(from), p2 = GetParticle(to);
				Spring edgeToRem = new Spring(p1, p2, cost);
				List<Edge> fromEdgeList = AdjList[from];
				// for each edge in fromEdgeList
				for (int i = 0; i < fromEdgeList.Count; i++)
				{
					// Cuurent edge is the same as the clone edge
					if (fromEdgeList[i].Equals(edgeToRem))
					{
						// remove edge from edge list
						fromEdgeList.RemoveAt(i);
						EdgeCount--;
						// Visuals
						RemoveSpring(edgeToRem);
						return true;
					}
				}
			}
			return false;
		}
		public bool RemoveUndirectedEdge(int from, int to, int cost)
		{
			// Removes specified edge only if found to be doubly linked

			// Both node id's present in nodeLookup and not trying to remove a self loop
			if (to != from && ContainsNode(from) && ContainsNode(to))
			{
				// Creating a clone springs(edges) for removals
				Particle p1 = GetParticle(from), p2 = GetParticle(to);
				Spring remSpring1 = new Spring(p1, p2, cost),
					remSpring2 = new Spring(p2, p1, cost);
				List<Edge> fromEdgeList = AdjList[from], toEdgeList = AdjList[to];
				// Find the edge (from, to, cost)
				for (int i = 0; i < fromEdgeList.Count; i++)
				{
					if (fromEdgeList[i].Equals(remSpring1))
					{
						// Find the edge (to, from, cost)
						for (int j = 0; j < toEdgeList.Count; j++)
						{
							if (toEdgeList[j].Equals(remSpring2))
							{
								// Removal of both edges, not that only both can be removed or none at all
								fromEdgeList.RemoveAt(i);
								toEdgeList.RemoveAt(j);
								EdgeCount -= 2;
								// Visuals
								RemoveSpring(remSpring1);
								RemoveSpring(remSpring2);
								return true;
							}
						}
					}
				}
			}
			return false;
		}
		#endregion

		#region Miscellaneous
		// Some data structures require node id's to be in the range 0 - V non inclusive
		public void FixNodeIdNumbering()
		{
			// Fix the node id numbering in case it is not sequential starting from 0.
			// Total runtime: O(Vlog(V) + E) = O(Vlog(V) + V^2) = O(V^2)

			// Create a sorted array containing all node ids
			// O(V)
			int[] nodeIdArray = nodeLookup.Keys.ToArray();
			// Assumed to take O(VLog(V)) time (uses introsort?).
			Array.Sort(nodeIdArray);
			int N = nodeIdArray.Length;
			// Array values are not sequntial starting from 0
			if(nodeIdArray[0] > 0 || nodeIdArray[N - 1] - nodeIdArray[0] > N - 1)
			{
				// Tell the user changes to the vertex id's are about to happen.
				SimpleDialog.ShowMessage("Notice", $"Shifting vertex ids to the domain [0, {NodeCount - 1}]");

				// Note that each index denotes the new node id,
				// and the value denotes the old node id.

				// inverseNodeIdDict - inverse mapping for nodeIdArray, where
				// keys (old node ids) map to the new node id.
				// A dictionary is used becuase nodeIdArray's values are not sequential
				Dictionary<int, int> inverseNodeIdDict = new Dictionary<int, int>();

				// O(V + E)
				UpdateNodeIds(nodeIdArray, N, inverseNodeIdDict);
			}
		}
		private void UpdateNodeIds(int[] nodeIdArray, int N, Dictionary<int, int> inverseNodeIdDict)
		{
			// O(V)
			// go over each node id in nodeIdArray
			Console.WriteLine("List of updated node ids:");
			for (int i = 0; i < N; i++)
			{
				int newId = i, oldId = nodeIdArray[i];
				inverseNodeIdDict[oldId] = newId;
				if (newId != oldId)
				{
					// Update nodeLookup
					nodeLookup[newId] = nodeLookup[oldId];
					nodeLookup.Remove(oldId);
					// Update adjList
					AdjList[newId] = AdjList[oldId];
					AdjList.Remove(oldId);
					// Update node id (GNode instance)
					nodeLookup[newId].Id = newId;
					// Output some info for the user
					Console.WriteLine($"oldID: {oldId}, newID: {newId}");
				}
			}
			// O(E)
			UpdateNodeIdsInEdges(inverseNodeIdDict);
		}
		private void UpdateNodeIdsInEdges(Dictionary<int, int> inverseNodeIdDict)
		{
			// O(E)
			// Update all node ids (from/to) for each edge using inverseNodeIdDict
			foreach (List<Edge> edgeList in AdjList.Values)
			{
				foreach (Edge edge in edgeList)
				{
					edge.From = inverseNodeIdDict[edge.From];
					edge.To = inverseNodeIdDict[edge.To];
				}
			}
		}

		private bool ResultsInParallelEdge(Edge cmpEdge)
		{
			// forbid parlel edges, i.e, (u, v, x1), (u, v, x2).
			int from = cmpEdge.From, to = cmpEdge.To;

			foreach (Edge edge in AdjList[from])
			{
				if (edge.From == from && edge.To == to)
				{
					Console.WriteLine("ResultInParallelEdge1");
					return true;
				}
			}
			return false;
		}
		private bool ResultsInInverseEdgesOfDiffCost(Edge cmpEdge)
		{
			// forbid coexistance of edges of the form (u, v, x1), (v, u, x2) if x1 != x2
			int from = cmpEdge.From, to = cmpEdge.To, cost = cmpEdge.Cost;
			List<Edge> toEdgeList = AdjList[to];

			for (int i = 0; i < toEdgeList.Count; i++)
			{
				if (toEdgeList[i].From == to &&
					toEdgeList[i].To == from &&
					toEdgeList[i].Cost != cost)
				{
					Console.WriteLine("ResultInParallelEdge2");
					return true;
				}
			}
			return false;
		}

		public Dictionary<int, List<Edge>> GetGTranspose()
		{
			// Returns a new adjacency list, Gt, where each edge(u, v, x) becomes(v, u, x)
			Dictionary<int, List<Edge>> Gt = new Dictionary<int, List<Edge>>();
			for (int id = 0; id < NodeCount; id++) Gt[id] = new List<Edge>();

			for (int id = 0; id < NodeCount; id++)
			{
				foreach (Edge edge in AdjList[id])
				{
					// Compute reversed edge, store in Gt
					Edge revEdge = Edge.ReversedCopy(edge);
					Gt[revEdge.From].Add(revEdge);
				}
			}
			return Gt;
		}

		public List<Edge> GetUndirectedEdgeList()
		{
			// *** SHOULD ONLY BE USED FOR UNDIRECTED GRAPHS! ***

			// O(E)
			// Assumes the graph is "undirected"; for each edge (u, v, x)
			// there exists an edge (v, u, x).
			// Returns a list of all edges(u, v, x) in the graph where u < v
			List<Edge> edgeList = new List<Edge>();
			foreach (List<Edge> curEdgeList in AdjList.Values)
			{
				if (curEdgeList != null)
					foreach (Edge edge in curEdgeList)
						if (edge.From < edge.To) edgeList.Add(edge);

			}
			return edgeList;
		}
		#endregion
	}
}
