/*  Dialogue Window Handler
 *  Author - Mark Lipina
 *  This class takes "input" from the NPCDialogueScript class and makes changes to the NPC Dialogue UI accordingly, including opening and closing it.
 *  It also accepts user input and sends this input back to the NPCDialogueScript.
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



    //===========================================================================| Methods for editing UI Elements
    public void ChangeBodyText(string NPCTextString)
    {
        // This method changes the main body text displayed in the dialogue window.
        NPCText.text = NPCTextString;
    }
    public void ChangeButtonAText(string ButtonText)
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
    public void ChangeButtonBText(string ButtonText)
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
    public void ChangeButtonCText(string ButtonText)
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

    public void enableButtonA()
    {
        ButtonA.enabled = true;
    }
    public void enableButtonB()
    {
        ButtonB.enabled = true;
    }
    public void enableButtonC()
    {
        ButtonC.enabled = true;
    }
    public void enableButtonNext()
    {
        NextButton.enabled = true;
    }

    public void disableButtonA()
    {
        ButtonA.enabled = false;
    }
    public void disableButtonB()
    {
        ButtonB.enabled = false;
    }
    public void disableButtonC()
    {
        ButtonC.enabled = false;
    }
    public void disableButtonNext()
    {
        NextButton.enabled = false;
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
