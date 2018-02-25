using System.Collections.Generic;
using UnityEngine;

namespace AStarSearch {
    public class PathfindingAStar : AStar {

        public LayerMask unwalkableMask;
        public int gridSizeX, gridSizeY;
        public float nodeRadius;
        PathNode[,] grid;

        float nodeDiameter;

        private void Awake() {
            nodeDiameter = nodeRadius * 2;
            GenerateGrid();
        }

        public void GenerateGrid() {
            grid = new PathNode[gridSizeX, gridSizeY];
            for(int x = 0; x < gridSizeX; x++) {
                for (int y = 0; y < gridSizeY; y++) {
                    Vector3 worldPos = new Vector3(nodeDiameter * x, 0, nodeDiameter * y);
                    bool walkable = !Physics.CheckSphere(worldPos, nodeRadius, unwalkableMask);
                    grid[x, y] = new PathNode(walkable, worldPos, x, y);
                }
            }
        }


        public PathNode NodeAtPos(Vector3 worldPos) {
            float percentX = Mathf.Clamp01(worldPos.x / gridSizeX);
            float percentY = Mathf.Clamp01(worldPos.z / gridSizeY);

            int x = Mathf.RoundToInt(gridSizeX * percentX);
            int y = Mathf.RoundToInt(gridSizeY * percentY);
            if (x >= gridSizeX) x = gridSizeX - 1;
            if (y >= gridSizeY) y = gridSizeY - 1;
            return grid[x, y];
        }

        protected override int Cost(Node start, Node end) {
            return start.gCost + Heuristic(start, end);
        }

        protected override List<Node> GetChildren(Node n) {
            List<Node> children = new List<Node>();
            PathNode pathN = n as PathNode;
            //3x3 window
            for(int x = -1; x <= 1; x++) {
                for (int y = -1; y <= 1; y++) {
                    if (x == 0 && y == 0)
                        continue;

                    int tmpX = pathN.gridX + x;
                    int tmpY = pathN.gridY + y;

                    if (tmpX >= 0 && tmpX < gridSizeX && tmpY >= 0 && tmpY < gridSizeY) {
                        PathNode possibleChild = grid[tmpX, tmpY];
                        if (possibleChild.walkable)
                            children.Add(possibleChild);
                    }                        
                }
            }

            return children;
        }

        protected override int Heuristic(Node start, Node end) {
            PathNode a = start as PathNode;
            PathNode b = end as PathNode;
            int dX = Mathf.Abs(a.gridX - b.gridX);
            int dY = Mathf.Abs(a.gridY - b.gridY);

            if (dY > dX)
                return 14 * dX + 10 * (dY - dX);

            return 14 * dY + 10 * (dX - dY);
        }

    }
}