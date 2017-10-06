using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueWindowHandler : MonoBehaviour {

    public Text NPCText;
    public Text ButtonA;
    public Text ButtonB;
    public Text ButtonC;
    public GameObject NPCObject;
    public char PressedButton;


    //Open and close dialogue
    public void openDialogue()
    {
        transform.SetAsLastSibling();
    }
    public void closeDialogue()
    {
        transform.SetAsFirstSibling();
    }

    //Button press listeners
    public void ButtonAPressed()
    {
        PressedButton = 'A';
    }
    public void ButtonBPressed()
    {
        PressedButton = 'B';
    }
    public void ButtonCPressed()
    {
        PressedButton = 'C';
    }
    public void NextButtonPressed()
    {
        PressedButton = 'N';
    }


    //Function called by NPC Dialogue Tree Handler script which modifies the displayed text
    void ChangeText(string NPCTextString, string ButtonAString, string ButtonBString, string ButtonCString)
    {
        NPCText.text = NPCTextString;
        ButtonA.text = ButtonAString;
        ButtonB.text = ButtonBString;
        ButtonC.text = ButtonCString;
    }



    void Update()
    {
        //Switch statement sends choice to NPC-specific script which proceeds along the dialog tree
        switch (PressedButton)
        {
            case 'A':
                Debug.Log("Button A pressed");
                PressedButton = ' ';
                break;
            case 'B':
                Debug.Log("Button B pressed");
                PressedButton = ' ';
                break;
            case 'C':
                Debug.Log("Button C pressed");
                PressedButton = ' ';
                break;
            case 'N':
                Debug.Log("Next Button Pressed");
                PressedButton = ' ';
                break;

            default:
                break;
        }    
    }
}
