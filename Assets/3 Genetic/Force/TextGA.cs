using UnityEngine;

namespace Genetic {
    public class TextGA : MonoBehaviour {

        public int popSize = 50;
        public int maxIterations = 1000;
        public float mutationChance = .1f;
        public TextNode[] population;
        public int iterations = 0;
        char[] goal;

        public TextNode GenerateSol(char[] goal) {
            this.goal = goal;
            TextNode[] tmpPop = new TextNode[popSize];
            GeneratePopulation();

            TextNode child;
            TextNode bestChild = null;
            iterations = 0;

            while (iterations < maxIterations) {
                iterations++;

                for (int i = 0; i < popSize; i++) {
                    child = Crossover(ChooseParent(), ChooseParent());

                    if (child.EndReached(goal)) {
                        return child;
                    }

                    if (mutationChance > Random.Range(0f, 1f)) {
                        child.Mutate();
                    }

                    if (bestChild == null)
                        bestChild = child;

                    if (child.Score(goal) > bestChild.Score(goal)) {
                        bestChild = child;
                    }

                    tmpPop[i] = child;
                }

                population = tmpPop;

            }
            return bestChild;
        }

        void GeneratePopulation() {
            population = new TextNode[popSize];
            for (int i = 0; i < popSize; i++)
                population[i] = new TextNode(goal.Length);
        }

        TextNode Crossover(TextNode a, TextNode b) {
            int r = Random.Range(1, goal.Length - 1);
            TextNode n = new TextNode(goal.Length);
            for (int i = 0; i < goal.Length; i++) {
                if (i < r) {
                    n.txt[i] = a.txt[i];
                } else {
                    n.txt[i] = b.txt[i];
                }
            }

            return n;
        }

        TextNode ChooseParent() {
            float total = 0;
            for (int i = 0; i < popSize; i++) {
                total += population[i].Score(goal);
            }

            float r = Random.Range(0f, total);

            for (int i = 0; i < popSize; i++) {
                if (r < population[i].Score(goal)) {
                    return population[i];
                }

                r -= population[i].Score(goal);
            }

            return null;
        }
    }
}
