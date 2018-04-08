using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Perceptron4 {
    public class DemoGUI : MonoBehaviour {

        public Text beforeW, afterW, outputB, outputA;
        Driver d;

        private void Start() {
            d = new Driver();
        }

        public void StartRun() {
            string b, a, oB, oA;
            d.Run(out b, out a, out oB, out oA);
            beforeW.text = b;
            afterW.text = a;
            outputB.text = oB;
            outputA.text = oA;
        }
    }
}