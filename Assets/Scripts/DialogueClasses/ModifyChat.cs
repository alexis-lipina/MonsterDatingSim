using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyChat : DialogueEvent {

    protected int trustChange;
    protected string nextEvent;

    public ModifyChat(string btxt, string nm, int sprref, int trustchng, string nxtevnt) : base(btxt, nm, sprref)
    {
        trustChange = trustchng;
        nextEvent = nxtevnt;

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
        Debug.LogError("ERROR: getButtonCount method called on ModifyChat");
        return 0;
    }

    public override string getButtonText(char btn)
    {
        Debug.LogError("ERROR: getButtonText method called on ModifyChat");
        return "ERROR";
    }
    public override string getNextEvent()
    {
        return nextEvent;
    }
    public override string getButtonEvent(char btn)
    {
        Debug.LogError("ERROR: getButtonEvent method called on ModifyChat");
        return "";
    }
    public override int getTrustChange()
    {
        return trustChange;
    }
    public override string getDestination()
    {
        Debug.LogError("ERROR: getDestination method called on ModifyChat");
        return "";
    }
}
