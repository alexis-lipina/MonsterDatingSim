using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleScript : MonoBehaviour {

    public NPCDialogue testobj;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown ()
    {
        print("Clicked!");
        testobj.StartDialogue();
    }
}
