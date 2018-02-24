using System.Collections.Generic;
using UnityEngine;

namespace AStarSearch {
    public class NQueenAStar : AStar {

        protected override List<Node> GetChildren(Node n) {
            NQueenNode qNode = n as NQueenNode;
            List<Node> children = new List<Node>();
            //create all movements of one queen
            for(int i = 0; i < qNode.Size; i++) {
                for (int j = 0; j < qNode.Size; j++) {
                    int[] queens = qNode.Queens;
                    if (queens[i] != j) {
                        queens[i] = j;
                        children.Add(new NQueenNode(queens));
                    }
                }
            }
            return children;
        }

        protected override int Cost(Node start, Node end) {
            return 0;
        }

        protected override int Heuristic(Node start, Node end) {
            NQueenNode n = start as NQueenNode;
            return n.AttackedQueens();
        }
    }
}