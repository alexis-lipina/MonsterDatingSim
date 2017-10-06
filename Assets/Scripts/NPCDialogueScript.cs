using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour {


    //======================================================================================| OLD SHIT START 
    #region Old Dialogue Storage
    string startDialogue = "This is the first thing the NPC would say.";

    string choiceA = "Text in the first response choice.";
    string choiceB = "Text in the second";
    string choiceC = "In the third.";


    string responseA = "This is what the NPC will say in response to choice A.";
    string responseB = "The NPC will say this in response to choice B.";
    string responseC = "Choice C has been chosen, apparently. Make another one.";
    string responseD = "The fourth choice has been made. Now make another.";
    ///===========================================================================| A
    string choiceAA = "Dont tell me you're choosing A again...";
    string choiceAB = "B would be the next logical choice, alphabetically speaking.";
    string choiceAC = "Air Conditioning";

    
    string responseAA = "You picked A? Again? Very creative. Well, at least you're consistent.";
    string responseAB = "A, B... I think I'm starting to see a pattern here.";
    string responseAC = "A C has been your choice progression so far.";

    //===========================================================================| B
    string choiceBA = "Choice B, then A";
    string choiceBB = "Choice B then B";
    string choiceBC = "Choice B then C";


    string responseBA = "You picked choice B first, then choice A";
    string responseBB = "You picked choice B first, then choice B";
    string responseBC = "You picked choice B first, then choice C";

    //===========================================================================| C
    string choiceCA = "You could pick A.";
    string choiceCB = "Or B";
    string choiceCC = "Or C. Might as well pick C again.";


    string responseCA = "You picked choice C first, then choice A";
    string responseCB = "You picked choice C and then B";
    string responseCC = "Closed Captioning is provided by...";
    #endregion
    //======================================================================================| OLD SHIT END 


    Dictionary<string, string> dialogueDict = new Dictionary<string, string>();

    
    public string getResponse(string pathname)
    {
        return "";
    }
}
