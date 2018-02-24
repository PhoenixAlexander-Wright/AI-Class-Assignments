using UnityEngine;
namespace ReflexAgent {
    public class ReflexAgent : MonoBehaviour {

        public static ReflexAgent instance;

        Vector3 curPos = Vector3.zero;
        Transform trans;
        public int stepsPerSecond = 2;
        float stepTimer, timerEnd;

        private void Awake() {
            instance = this;
            trans = GetComponent<Transform>();
            Init();
        }

        private void Update() {
            stepTimer += Time.deltaTime;
            if (stepTimer > timerEnd) {
                stepTimer = 0;
                Step();
            }
            //update position
            trans.position = Vector3.Lerp(trans.position, curPos, Time.deltaTime * stepsPerSecond * 5);
        }

        public void Init() {
            curPos = Vector3.zero;
            stepTimer = 0;
            timerEnd = 1f / stepsPerSecond;
        }

        void Step() {
            Tile t = CurrentTile();
            if (!t)
                return;

            if (t.isDirty)
                t.isDirty = false;
            else
                MoveRandomValidDirection();
        }

        void MoveRandomValidDirection() {
            float r = Random.value; //determines axis
            int sign = Random.value < .5 ? 1 : -1;
            if (r >= .5) {  //move on x axis
                int tmpX = (int)curPos.x + sign;
                if (tmpX >= 0 && tmpX < Grid.instance.sizeX) {   //if inside grid, update pos
                    curPos.x = tmpX;
                } else {
                    MoveRandomValidDirection(); //try again
                }
            } else {    //move on z axis
                int tmpZ = (int)curPos.z + sign;
                if (tmpZ >= 0 && tmpZ < Grid.instance.sizeY) {
                    curPos.z = tmpZ;
                } else {
                    MoveRandomValidDirection();
                }
            }
        }

        Tile CurrentTile() {
            RaycastHit hit;
            if (Physics.Raycast(trans.position + Vector3.up, Vector3.down, out hit, 3)) {
                return hit.transform.GetComponent<Tile>();
            }
            return null;
        }
    }
}