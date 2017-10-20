using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    public string DestinationScene;

    void OnMouseDown()
    {
        print("Portal clicked!");
        LevelManager.ChangeScene(DestinationScene);
    }


}
