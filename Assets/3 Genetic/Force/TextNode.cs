using UnityEngine;

namespace Genetic {
    public class TextNode {

        public char[] txt;

        public int Size {
            get { return txt.Length; }
        }

        public TextNode(int size) {
            var chars = "abcdefghijklmnopqrstuvwxyz ";
            txt = new char[size];
            //random configuration
            for (int i = 0; i < size; i++) {
                txt[i] = chars[Random.Range(0, chars.Length)];
            }
        }

        public TextNode(char[] t) {
            txt = t;
        }

        public float Score(char[] goal) {
            float score = 0;
            for(int i = 0; i < goal.Length; i++) {
                if (txt[i] == goal[i]) {
                    score++;
                }
            }
            score /= goal.Length;
            score = (Mathf.Pow(2, score) - 1) / (2 - 1);

            return score;
        }

        public bool EndReached(char[] goal) {
            if (Score(goal) == 1)
                return true;

            return false;
        }

        public void Mutate() {
            var chars = "abcdefghijklmnopqrstuvwxyz ";
            int r = Random.Range(0, Size);
            txt[r] = chars[Random.Range(0, chars.Length)];
        }
    }
}