using UnityEngine;

public class VisualGrid : MonoBehaviour {

    public static VisualGrid instance;

    public GameObject tile;
    public int size;
    public Material black;
    Transform trans;

    private void Awake() {
        instance = this;
        trans = GetComponent<Transform>();
    }

    public void GenerateGrid() {
        DestroyCurrentGrid();

        bool alt = false;
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                Vector3 pos = new Vector3(x, 0, y);
                GameObject go = Instantiate(tile, pos, Quaternion.identity, trans);
                if (alt) {
                    go.GetComponentInChildren<Renderer>().material = black;
                }
                alt = !alt;
            }
            if(size % 2 == 0)
                alt = !alt;
        }
    }

    void DestroyCurrentGrid() {
        foreach (Transform child in trans) {
            Destroy(child.gameObject);
        }
    }
}

