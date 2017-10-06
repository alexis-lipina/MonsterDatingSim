using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VamonosChat : DialogueEvent {

    string destination;
    public VamonosChat(string btxt, string nm, int sprref, string dest) : base(btxt, nm, sprref)
    {
        destination = dest;
    }
    public override string getBodyText()
    {
        return bodyText;
    }

    public override int getSpriteReference()
    {
        return spriteReference;
    }
    public override string getName()
    {
        return name;
    }
    public override int getButtonCount()
    {
        Debug.LogError("ERROR: getButtonCount called on VamonosChat");
        return 0;
    }

    public override string getButtonText(char btn)
    {
        Debug.LogError("ERROR: getButtonText called on VamonosChat");
        return "";
    }
    public override string getNextEvent()
    {
        Debug.LogError("ERROR: getNextEvent called on VamonosChat");
        return null;
    }
    public override string getButtonEvent(char btn)
    {
        Debug.LogError("ERROR: getButtonEvent called on VamonosChat");
        return "";
    }
    public override int getTrustChange()
    {
        Debug.LogError("ERROR: getTrustChange called on VamonosChat - method only implemented in ModifyChat");
        return 0;
    }
    public override string getDestination()
    {
        return destination;
    }
}
