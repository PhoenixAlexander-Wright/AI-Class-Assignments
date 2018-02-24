namespace AStarSearch {
    public abstract class Node {

        public Node parent;
        public int gCost, hCost;

        public int fCost {
            get { return gCost + hCost; }
        }

        public Node() {
            gCost = int.MaxValue;
        }


        public abstract bool EndReached(Node other);

    }
}
