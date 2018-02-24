using UnityEngine;
public class Grid : MonoBehaviour {

    public static Grid instance;

    public GameObject tile;
    public int sizeX = 5, sizeY = 5;
    public float dirtyTilePercent = .4f;
    Transform trans;

    private void Awake() {
        instance = this;
        trans = GetComponent<Transform>();
    }

    public void GenerateGrid() {
        DestroyCurrentGrid();

        for(int x = 0; x < sizeX; x++) {
            for (int y = 0; y < sizeY; y++) {
                Vector3 pos = new Vector3(x, 0, y);
                GameObject go = Instantiate(tile, pos, Quaternion.identity, trans);
                if(Random.Range(0f,1f) < dirtyTilePercent)
                    go.GetComponentInChildren<Tile>().isDirty = true;
            }
        }
    }

    void DestroyCurrentGrid() {
        foreach (Transform child in trans) {
            Destroy(child.gameObject);
        }
    }
}
