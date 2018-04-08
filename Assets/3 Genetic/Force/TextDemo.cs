using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Genetic {
    public class TextDemo : MonoBehaviour {

        TextGA algo;
        int popSize = 10;
        float mutationProb = .1f;
        public int maxIterations = 1000;
        public InputField inputGoal, inputPopSize, inputMutProb, inputMaxIterations;
        public Text txtIterations, answer;

        TextNode solution;

        private void Awake() {
            algo = GetComponent<TextGA>();
        }


        public void Run() {
            algo.popSize = int.Parse(inputPopSize.text);
            algo.mutationChance = float.Parse(inputMutProb.text);
            algo.maxIterations = int.Parse(inputMaxIterations.text);

            solution = algo.GenerateSol(inputGoal.text.ToCharArray());

            txtIterations.text = "Iterations: " + algo.iterations;
            answer.text = new string(solution.txt);
        }


    }
}