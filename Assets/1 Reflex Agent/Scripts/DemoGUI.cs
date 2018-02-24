using UnityEngine;
using UnityEngine.UI;

public class DemoGUI : MonoBehaviour {

    public InputField sizeX, sizeY, dirt, speed;


    public void RunSim() {
        Grid.instance.sizeX = int.Parse(sizeX.text);
        Grid.instance.sizeY = int.Parse(sizeY.text);
        Grid.instance.dirtyTilePercent = float.Parse(dirt.text);

        ReflexAgent.instance.stepsPerSecond = int.Parse(speed.text);

        Grid.instance.GenerateGrid();
        ReflexAgent.instance.Init();
    }

}
