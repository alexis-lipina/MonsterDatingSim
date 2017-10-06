using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueChat : DialogueEvent {
    string nextEvent;

    public MonologueChat(string btxt, string nm, int sprref, string nxtevnt) : base(btxt, nm, sprref)
    {
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
        Debug.LogError("ERROR: getButtonCount called on MonologueChat");
        return 0;
    }

    public override string getButtonText(char btn)
    {
        Debug.LogError("ERROR: getButtonText called on MonologueChat");
        return "";
    }
    public override string getNextEvent()
    {
        return nextEvent;
    }
    public override string getButtonEvent(char btn)
    {
        Debug.LogError("ERROR: getButtonEvent called on MonologueChat");
        return "";
    }
    public override int getTrustChange() //==============={ LEFT OFF WORK HERE }
    {
        Debug.LogError("ERROR: getTrustChange called on MonologueChat - method only implemented in ModifyChat");
        return 0;
    }
    public override string getDestination()
    {
        Debug.LogError("ERROR: getDestination method called on MonologueChat");
        return "";
    }

}
