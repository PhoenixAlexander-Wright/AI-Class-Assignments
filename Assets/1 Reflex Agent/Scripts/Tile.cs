using UnityEngine;
public class Tile : MonoBehaviour {

    bool dirty = false;
    public Material dirtyMat;
    public Material cleanMat;

    MeshRenderer render;

	public bool isDirty {
        get { return dirty; }
        set {
            dirty = value;
            if (value == true)
                render.material = dirtyMat;
            else
                render.material = cleanMat;
        }
    }

    private void Awake() {
        render = GetComponent<MeshRenderer>();
    }

}
