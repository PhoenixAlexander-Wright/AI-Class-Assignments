using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AStarSearch {
    public class Demo : MonoBehaviour {

        public int size = 4;
        public int maxIterations = 1000;
        public GameObject visualAgent;
        public InputField inputSize;
        public Text txtPathLength;

        NQueenAStar aStar;
        List<VisualAgent> agents;
        List<NQueenNode> queenStates = new List<NQueenNode>();
        int curState = 0;

        private void Awake() {
            aStar = GetComponent<NQueenAStar>();
            agents = new List<VisualAgent>();
        }

        public void GenerateSolution() {
            size = int.Parse(inputSize.text);

            if (size < 4)
                return;

            Clear();
            
            VisualGrid.instance.size = size;
            VisualGrid.instance.GenerateGrid();
            aStar.maxIterations = maxIterations;

            NQueenNode start = new NQueenNode(size);
            NQueenNode end = null;
            List<Node> l = aStar.Search(start, end);
            txtPathLength.text = "Path Length: " + l.Count;
            
            for (int i = 0; i < l.Count; i++) {
                queenStates.Add(l[i] as NQueenNode);
            }

            GenereateAgents();
        }

        void GenereateAgents() {
            for (int i = 0; i < size; i++) {
                Vector3 pos = new Vector3(i, 0, queenStates[0].Queens[i]);
                GameObject go = Instantiate(visualAgent, pos, Quaternion.identity);
                agents.Add(go.GetComponent<VisualAgent>());
                agents[i].curPos = pos;
            }
        }

        void Clear() {
            curState = 0;
            DestroyAgents();
            queenStates.Clear();
        }

        void DestroyAgents() {
            for (int i = 0; i < agents.Count; i++) {
                Destroy(agents[i].transform.gameObject);
            }
            agents.Clear();
        }

        public void UpdateState() {
            curState++;
            if (curState >= queenStates.Count)
                return;

            for (int i = 0; i < size; i++) {
                Vector3 pos = new Vector3(i, 0, queenStates[curState].Queens[i]);
                agents[i].curPos = pos;
            }
        }



    }
}
