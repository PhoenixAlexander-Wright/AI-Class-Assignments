using UnityEngine;

public class VisualAgent : MonoBehaviour {

    public Vector3 curPos = Vector3.zero;
    Transform trans;
    public int speed = 2;

    private void Awake() {
        trans = GetComponent<Transform>();
    }

    public void Init() {
        curPos = Vector3.zero;
    }

    private void Update() {
        trans.position = Vector3.Lerp(trans.position, curPos, Time.deltaTime * speed * 5);
    }


}
