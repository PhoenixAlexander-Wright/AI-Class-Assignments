using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perceptron4 {
    public class Driver {

        //Problem: given 2x2 image, classfy if bright or dark
        //bright = > 1 pixels are white.

        public void Run(out string befW, out string aftW, out string outputB, out string outputA) {
            Perceptron p = new Perceptron();
            int[][] inputs = new int[16][];
            int index = 0;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        for (int l = 0; l < 2; l++) {
                            inputs[index] = new int[] { i,j,k,l };
                            index++;
                        }
                    }
                }
            }

            int[] outputs = new int[] {0,0,0,1,0,1,1,1,0,1,1,1,1,1,1,1};

            float[] weights = new float[4];
            befW = "";
            for (int i = 0; i < weights.Length; i++) {
                weights[i] = Random.Range(-10,11) * .1f;
                befW += weights[i].ToString() + "\n";
            }

            outputB = "";
            for (int i = 0; i < inputs.Length; i++) {
                outputB += "[" + inputs[i][0] + ", " + inputs[i][1] + ", " + inputs[i][2] + ", " + inputs[i][3] + "] = " + p.Output(inputs[i], weights) + "\n";
            }

            p.Train(inputs, outputs, ref weights, 100);

            aftW = "";
            for (int i = 0; i < weights.Length; i++) {
                aftW += weights[i].ToString() + "\n";
            }

            outputA = "";
            for (int i = 0; i < inputs.Length; i++) {
                outputA += "[" + inputs[i][0] + ", " + inputs[i][1] + ", " + inputs[i][2] + ", " + inputs[i][3] + "] = " + p.Output(inputs[i], weights) + "\n";
            }          

        }

    }
}