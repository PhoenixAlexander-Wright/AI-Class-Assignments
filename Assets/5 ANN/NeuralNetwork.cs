namespace ANN {
    public class NeuralNetwork {

        Layer[] layers;
        
        public NeuralNetwork(int[] layer, float learningRate) {
            layers = new Layer[layer.Length - 1];
            for(int i = 0; i < layer.Length - 1; i++) {
                layers[i] = new Layer(layer[i], layer[i + 1], learningRate);
            }
        }

        public void Train(float[] inputs, float[] expectedOutput) {
            FeedForward(inputs);
            BackPropagate(expectedOutput);
        }

        public float[] FeedForward(float[] inputs) {
            layers[0].FeedForward(inputs);
            for (int i = 1; i < layers.Length; i++) {
                layers[i].FeedForward(layers[i - 1].outputs);
            }

            return layers[layers.Length - 1].outputs;
        }

        void BackPropagate(float[] expectedOutput) {
            layers[layers.Length - 1].BackPropagateOutput(expectedOutput);
            for (int i = layers.Length - 2; i >= 0; i--) {
                layers[i].BackPropagateHidden(layers[i + 1].errorTerm, layers[i + 1].weights);                
            }

            for (int i = 0; i < layers.Length; i++) {
                layers[i].UpdateWeights();
            }
        }

    }
}