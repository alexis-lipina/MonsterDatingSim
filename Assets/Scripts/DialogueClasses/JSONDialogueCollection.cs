using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class defines a JSON-Serializeable collection for storing and 
/// reading in arrays of JSONDialogue objects.
/// </summary>
[Serializable]
public class JSONDialogueCollection {
    public JSONDialogue[] nodes;
	
}
