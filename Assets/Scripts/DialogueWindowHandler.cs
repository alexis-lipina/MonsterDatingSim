/**  Dialogue Window Handler
 *  Author - Mark Lipina
 *  This class provides methods to the NPCDialogue class which change the different elements of the NPC Dialogue UI,
 *  as well providing control over opening and closing it. It also accepts user input via buttons and sends this input 
 *  back to the NPCDialogueScript to allow procession through dialogue.
 * */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueWindowHandler : MonoBehaviour {

    public Text NPCText;
    public Text SpeakerName;
    public Text ButtonAText;
    public Text ButtonBText;
    public Text ButtonCText;
    public Button ButtonA;
    public Button ButtonB;
    public Button ButtonC;
    public Button NextButton;
    public GameObject NPCObject;
    public NPCDialogue NPCScript;
    public GameObject DialoguePanel;
    public char PressedButton;


    //Open and close dialogue
    public void openDialogue(string npcobj)
    {
        transform.SetAsLastSibling();
        DialoguePanel.SetActive(true);
        NPCObject = GameObject.Find(npcobj);
        NPCScript = NPCObject.GetComponent<NPCDialogue>();
        NPCObject.SetActive(false);
        GameObject[] interactibles = GameObject.FindGameObjectsWithTag("Interactible");
        for (int i = 0; i < interactibles.Length; i++)
        {
            interactibles[i].gameObject.SetActive(false);
        }
    }

    public void closeDialogue()
    {
        transform.SetAsFirstSibling();
        DialoguePanel.SetActive(false);
        NPCObject.SetActive(true);
        GameObject[] interactibles = GameObject.FindGameObjectsWithTag("Interactible");
        for (int i = 0; i < interactibles.Length; i++)
        {
            interactibles[i].gameObject.SetActive(true);
        }
        NPCObject.SetActive(true);
        NPCObject = null;
        NPCScript = null;
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



    //===========================================================================| Methods for editing UI Elements
    public void SetBodyText(string NPCTextString)
    {
        // This method changes the main body text displayed in the dialogue window.
        NPCText.text = NPCTextString;
    }
    public void SetButtonAText(string ButtonText)
    {
        // This method changes the text displayed by Button A
        if (ButtonText.Equals(""))
        {
            ButtonA.enabled = false;
        }
        else
        {
            ButtonAText.text = ButtonText;
            ButtonA.enabled = true;
        }
    }
    public void SetButtonBText(string ButtonText)
    {
        // This method changes the text displayed by Button B
        if (ButtonText.Equals(""))
        {
            ButtonB.enabled = false;
        }
        else
        {
            ButtonBText.text = ButtonText;
            ButtonB.enabled = true;
        }
    }
    public void SetButtonCText(string ButtonText)
    {
        // This method changes the text displayed by Button C
        if (ButtonText.Equals(""))
        {
            ButtonC.enabled = false;
        }
        else
        {
            ButtonCText.text = ButtonText;
            ButtonC.enabled = true;
        }
    }

    public void EnableButtonA()
    {
        ButtonA.gameObject.SetActive(true);
    }
    public void EnableButtonB()
    {
        ButtonB.gameObject.SetActive(true);
    }
    public void EnableButtonC()
    {
        ButtonC.gameObject.SetActive(true);
    }
    public void EnableButtonNext()
    {
        NextButton.gameObject.SetActive(true);
    }

    public void DisableButtonA()
    {
        ButtonA.gameObject.SetActive(false);
    }
    public void DisableButtonB()
    {
        ButtonB.gameObject.SetActive(false);
    }
    public void DisableButtonC()
    {
        ButtonC.gameObject.SetActive(false);
    }
    public void DisableButtonNext()
    {
        NextButton.gameObject.SetActive(false);
    }






    void Update()
    {
        //Switch statement sends choice to NPC-specific script which proceeds along the dialog tree
        switch (PressedButton)
        {
            case 'A':
                Debug.Log("Button A pressed");
                NPCScript.changeDialogueEvent(PressedButton);
                PressedButton = ' ';
                break;
            case 'B':
                Debug.Log("Button B pressed");
                NPCScript.changeDialogueEvent(PressedButton);
                PressedButton = ' ';
                break;
            case 'C':
                Debug.Log("Button C pressed");
                NPCScript.changeDialogueEvent(PressedButton);
                PressedButton = ' ';
                break;
            case 'N':
                Debug.Log("Next Button Pressed");
                NPCScript.changeDialogueEvent(PressedButton);
                PressedButton = ' ';
                break;

            default:
                break;
        }    
    }
}
