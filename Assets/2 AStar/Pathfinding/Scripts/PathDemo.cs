using System.Collections.Generic;
using UnityEngine;

namespace AStarSearch {
    public class PathDemo : MonoBehaviour {

        public int maxIterations = 1000;
        public VisualAgent chaser, chased;

        PathfindingAStar aStar;
        List<PathNode> pathNodes = new List<PathNode>();
        int curState = 0;

        private void Awake() {
            aStar = GetComponent<PathfindingAStar>();
        }

        private void Start() {
            VisualGrid.instance.GenerateGrid();
            aStar.maxIterations = maxIterations;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                UpdateState();
            } else if (Input.GetKeyDown(KeyCode.G)) {
                GenerateSolution();
            } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                chased.curPos.z += 1;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                chased.curPos.z -= 1;
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                chased.curPos.x -= 1;
            } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                chased.curPos.x += 1;
            }

        }

        public void GenerateSolution() {
            Clear();

            aStar.GenerateGrid();
            PathNode start = aStar.NodeAtPos(chaser.curPos);
            PathNode end = aStar.NodeAtPos(chased.curPos);
            List<Node> l = new List<Node>();
            l = aStar.Search(start, end);

            for (int i = 0; i < l.Count; i++) {
                pathNodes.Add(l[i] as PathNode);
            }
        }

        void Clear() {
            curState = 0;
            pathNodes.Clear();
        }

        public void UpdateState() {            
            if (curState >= pathNodes.Count)
                return;

            chaser.curPos = pathNodes[curState].worldPos;
            curState++;
        }

    }
}
