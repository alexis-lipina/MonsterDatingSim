using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleScript : MonoBehaviour {

    public NPCDialogue testobj;

    void OnMouseDown ()
    {
        print("Clicked!");
        testobj.StartDialogue();
    }
}
