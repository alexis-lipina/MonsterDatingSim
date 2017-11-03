using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class serves as an intermediary between the JSON file and the
/// actual DialogueEvent objects. This is because JSON deserialization 
/// requires that fields be public, which violates data encapsulation.
/// Not entirely necessary, but it's probably a good habit to follow 
/// good software engineering practices even for projects like this.
/// </summary>
/// 

[Serializable]
public class JSONDialogue
{
    public string bodytext;
    public int buttoncount;
    public int spriteindex;
    public string speakername;
    public string[] buttontext;
    public string eventkey;
    public string nextkey;
    public string destination;
    public int trustchange;
    public string[] buttonevent;
    public string dialoguetype;

    public JSONDialogue() { }

    /// <summary>
    /// Constructs a DialogueEvent object out of the data within the JSONDialogue object this method is being called on
    /// </summary>
    /// <returns>Corresponding dialogue event</returns>
    public DialogueEvent toDialogueEvent()
    {
        return null;
    }
}
