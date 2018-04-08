using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Genetic {
    public class DemoNQGeneric : MonoBehaviour {

        NQueenGenetic algo;
        int size = 4, popSize = 10;
        float mutationProb = .1f;
        public int maxIterations = 1000;
        public GameObject visualAgent;
        public InputField inputSize, inputPopSize, inputMutProb, inputMaxIterations;
        public Text txtIterations;

        List<VisualAgent> agents;
        NQueenNode solution;

        private void Awake() {
            algo = GetComponent<NQueenGenetic>();
            agents = new List<VisualAgent>();
        }


        public void Run() {
            size = int.Parse(inputSize.text);
            if (size < 4)
                return;

            algo.popSize = int.Parse(inputPopSize.text);
            algo.mutationChance = float.Parse(inputMutProb.text);
            algo.maxIterations = int.Parse(inputMaxIterations.text);

            algo.numQueens = size;
            solution = algo.GenerateSol();

            txtIterations.text = "Iterations: " + algo.iterations;

            DestroyAgents();
            VisualGrid.instance.size = size;
            VisualGrid.instance.GenerateGrid();

            GenereateAgents();
        }

        void GenereateAgents() {
            for (int i = 0; i < size; i++) {
                Vector3 pos = new Vector3(i, 0, solution.queens[i]);
                GameObject go = Instantiate(visualAgent, pos, Quaternion.identity);
                agents.Add(go.GetComponent<VisualAgent>());
                agents[i].curPos = pos;
            }
        }

        void DestroyAgents() {
            for (int i = 0; i < agents.Count; i++) {
                Destroy(agents[i].transform.gameObject);
            }
            agents.Clear();
        }

    }
}