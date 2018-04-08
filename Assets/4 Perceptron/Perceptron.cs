namespace Perceptron4 {
    public class Perceptron {

        float learningRate = .1f;
        float threshold = .5f;

        public void Train(int[][] inputs, int[] outputs, ref float[] weights, int iterations = 100) {
            if (inputs == null || outputs == null || weights == null)
                return;

            for (int a = 0; a < iterations; a++) {
                for (int i = 0; i < inputs.Length; i++) {

                    float output = Output(inputs[i], weights);
                    float error = outputs[i] - output;
                    float delta = learningRate * error;

                    for (int j = 0; j < weights.Length; j++) {
                        weights[j] += delta * inputs[i][j];
                    }

                }
            }
        }

        public float Output(int[] inputs, float[] weights) {
            float sum = 0;
            for (int i = 0; i < weights.Length; i++) {
                sum += inputs[i] * weights[i];
            }
            return sum > threshold ? 1 : 0;
        }
    }
}