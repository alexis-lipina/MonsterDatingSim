using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    public string DestinationScene;
    public LevelManager LevMan;

    void OnMouseDown()
    {
        print("Portal clicked!");
        LevMan.ChangeScene(DestinationScene);
    }


}
