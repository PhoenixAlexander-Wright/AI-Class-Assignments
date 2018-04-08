using UnityEngine;

namespace Genetic {
    public class NQueenGenetic : MonoBehaviour {

        public int numQueens = 8;
        public int popSize = 50;
        public int maxIterations = 1000;
        public float mutationChance = .1f;
        NQueenNode[] population;
        public int iterations = 0;

        public NQueenNode GenerateSol() {
            NQueenNode[] tmpPop = new NQueenNode[popSize];
            GeneratePopulation();

            NQueenNode child;
            NQueenNode bestChild = null;
            iterations = 0;

            while (iterations < maxIterations) {
                iterations++;

                for(int i = 0; i < popSize; i++) {
                    child = Crossover(ChooseParent(), ChooseParent());

                    if (child.EndReached()) {
                        return child;
                    }

                    if(mutationChance > Random.Range(0f, 1f)) {
                        child.Mutate();
                    }

                    if (bestChild == null)
                        bestChild = child;

                    if(child.AttackedQueens() < bestChild.AttackedQueens()) {
                        bestChild = child;
                    }
                    
                    tmpPop[i] = child;
                }

                population = tmpPop;

            }
            return bestChild;
        }

        void GeneratePopulation() {
            population = new NQueenNode[popSize];
            for (int i = 0; i < popSize; i++)
                population[i] = new NQueenNode(numQueens);
        }

        NQueenNode Crossover(NQueenNode a, NQueenNode b) {
            int r = Random.Range(1, numQueens-1);
            NQueenNode n = new NQueenNode(numQueens);
            for(int i = 0; i < numQueens; i++) {
                if(i < r) {
                    n.queens[i] = a.queens[i];
                } else {
                    n.queens[i] = b.queens[i];
                }
            }

            return n;
        }

        NQueenNode ChooseParent() {
            int total = 0;
            for(int i = 0; i < popSize; i++) {
                total += population[i].AttackedQueens();
            }

            int r = Random.Range(0, total);

            for(int i = 0; i < popSize; i++) {
                if(r > population[i].AttackedQueens()) {
                    return population[i];
                }

                r = r + population[i].AttackedQueens();
            }

            return null;
        }

    }
}
