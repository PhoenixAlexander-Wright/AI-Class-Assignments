using UnityEngine;

public class FlyCam : MonoBehaviour {

    public float speed = 2;
    Transform trans;

    private void Awake() {
        trans = GetComponent<Transform>();
    }

    void Update () {
        if (Input.GetKey(KeyCode.W)) {
            trans.position += trans.GetChild(0).forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S)) {
            trans.position += -trans.GetChild(0).forward * Time.deltaTime * speed;
        } else if (Input.GetKey(KeyCode.A)) {
            trans.position += -trans.GetChild(0).right * Time.deltaTime * speed;
        } else if (Input.GetKey(KeyCode.D)) {
            trans.position += trans.GetChild(0).right * Time.deltaTime * speed;
        }
    }
}
