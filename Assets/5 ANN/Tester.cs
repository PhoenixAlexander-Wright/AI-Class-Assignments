using UnityEngine;

namespace ANN {
    public class Tester {

        public void GenerateSolution(int[] layers, float learningRate, int epoch, out string solution) {

            NeuralNetwork net = new NeuralNetwork(layers, learningRate);

            float[][] inputs = new float[16][];
            int index = 0;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        for (int l = 0; l < 2; l++) {
                            inputs[index] = new float[] { i, j, k, l };
                            index++;
                        }
                    }
                }
            }

            float[] outputs = new float[] { 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 };

            for (int i = 0; i < epoch; i++) {
                for (int j = 0; j < inputs.Length; j++)
                    net.Train(inputs[j], new float[] { outputs[j] });
            }

            solution = "";
            for (int i = 0; i < inputs.Length; i++) {
                solution += "[" + inputs[i][0] + ", " + inputs[i][1] + ", " + inputs[i][2] + ", " + inputs[i][3] + "] = " + net.FeedForward(inputs[i])[0] + "\n";
            }
        }

    }
}