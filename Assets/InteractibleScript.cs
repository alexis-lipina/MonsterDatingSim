using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleScript : MonoBehaviour {

    public NPCDialogue testobj;
    public GameObject image;

    void OnMouseDown ()
    {
        print("Clicked!");
        testobj.StartDialogue();
    }

    void OnMouseOver()
    {
        Color tmp = image.GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        image.GetComponent<SpriteRenderer>().color = tmp;
    }

    void OnMouseExit()
    {
        Color tmp = image.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        image.GetComponent<SpriteRenderer>().color = tmp;
    }
}
