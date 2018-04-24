using UnityEngine;

namespace ANN {
    public class Layer {

        float learningRate = .2f;
        int numInputs, numOutput;

        public float[] inputs, outputs;
        public float[,] weights, weightsDelta;
        public float[] errorTerm;

        public Layer(int numIn, int numOut, float learningRate) {
            numInputs = numIn;
            numOutput = numOut;
            this.learningRate = learningRate;

            outputs = new float[numOutput];
            inputs = new float[numInputs];
            weights = new float[numOutput, numInputs];
            weightsDelta = new float[numOutput, numInputs];
            errorTerm = new float[numOutput];

            for (int i = 0; i < numOutput; i++) {
                for (int j = 0; j < numInputs; j++) {
                    weights[i, j] = Random.value - 0.5f;
                }
            }
        }

        public float Sigmoid(float x) {
            return 1 / (1 + Mathf.Exp(-x));
        }

        public float Derivative(float x) {
            return x * (1f - x);
        }

        public void FeedForward(float[] inputs) {
            this.inputs = inputs;

            for(int i = 0; i < numOutput; i++) {
                outputs[i] = 0;
                for(int j = 0; j < numInputs; j++) {
                    outputs[i] += inputs[j] * weights[i, j];
                }
                outputs[i] = Sigmoid(outputs[i]);
            }
        }

        public void BackPropagateOutput(float[] expectedOutput) {
            for (int i = 0; i < numOutput; i++) {
                errorTerm[i] = (expectedOutput[i] - outputs[i]) * Derivative(outputs[i]);

                for (int j = 0; j < numInputs; j++) {
                    weightsDelta[i, j] = errorTerm[i] * inputs[j];
                }
            }
        }

        public void BackPropagateHidden(float[] errorTermForward, float[,] weightsFoward) {
            for (int i = 0; i < numOutput; i++) {
                errorTerm[i] = 0;

                for (int j = 0; j < errorTermForward.Length; j++) {
                    errorTerm[i] += errorTermForward[j] * weightsFoward[j, i];
                }

                errorTerm[i] *= Derivative(outputs[i]);
            }

            for (int i = 0; i < numOutput; i++) {
                for (int j = 0; j < numInputs; j++) {
                    weightsDelta[i, j] = errorTerm[i] * inputs[j];
                }
            }
        }

        public void UpdateWeights() {
            for (int i = 0; i < numOutput; i++) {
                for (int j = 0; j < numInputs; j++) {
                    weights[i, j] += weightsDelta[i, j] * learningRate;
                }
            }
        }

    }
}