using UnityEngine;

namespace AStarSearch {
    public class PathNode : Node {

        public bool walkable;
        public Vector3 worldPos;
        public int gridX, gridY;

        public PathNode(bool walkable, Vector3 worldPos, int gridX, int gridY) {
            this.walkable = walkable;
            this.worldPos = worldPos;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public override bool EndReached(Node other) {
            PathNode n = other as PathNode;
            if (gridX == n.gridX && gridY == n.gridY)
                return true;


            return false;
        }
    }
}