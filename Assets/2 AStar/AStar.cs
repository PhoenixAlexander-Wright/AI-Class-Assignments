using System.Collections.Generic;
using UnityEngine;
namespace AStarSearch {
    public abstract class AStar : MonoBehaviour {

        [HideInInspector]
        public int maxIterations = 1000;

        public List<Node> Search(Node start, Node end) {
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();

            open.Add(start);
            start.gCost = 0;
            int iterations = 0;
            while (open.Count > 0 && iterations < maxIterations) {
                iterations++;
                Node current = open[0];
                for(int i = 1; i < open.Count; i++) {   //find lowest cost node
                    if(open[i].fCost <= current.fCost) {
                        if (open[i].hCost < current.hCost)
                            current = open[i];
                    }
                }

                open.Remove(current);
                closed.Add(current);

                if(current.EndReached(end)) {
                    return ReconstructPath(start, current);
                }

                foreach(Node child in GetChildren(current)) {
                    if (closed.Contains(child))
                        continue;

                    bool newNode = !open.Contains(child);
                    if (newNode)
                        open.Add(child);

                    int newCostToChild = Cost(current, child);
                    if (newCostToChild > child.gCost)
                        continue;

                    child.gCost = newCostToChild;
                    child.hCost = Heuristic(child, end);
                    child.parent = current;
                }

            }

            return null;
        }

        List<Node> ReconstructPath(Node start, Node end) {
            List<Node> p = new List<Node>();
            Node current = end;

            while(current != start) {
                p.Add(current);
                current = current.parent;
            }
            p.Reverse();

            return p;
        }

        protected abstract List<Node> GetChildren(Node n);

        protected abstract int Cost(Node start, Node end);

        protected abstract int Heuristic(Node start, Node end);

    }
}
