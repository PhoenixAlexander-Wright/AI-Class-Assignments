using UnityEngine;
using UnityEngine.UI;

namespace ANN {
    public class DemoGUI : MonoBehaviour {

        public InputField hiddenLayers, learningRate, epoch;
        public Text output;

        public void Generate() {
            Tester test = new Tester();
            int hLayers = int.Parse(hiddenLayers.text);
            string sol;
            test.GenerateSolution(new int[] { 4, hLayers, hLayers, 1 }, float.Parse(learningRate.text), int.Parse(epoch.text), out sol);
            output.text = sol;
        }

    }
}