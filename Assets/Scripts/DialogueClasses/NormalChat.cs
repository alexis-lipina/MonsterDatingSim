using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChat : DialogueEvent
{
    int buttonCount;
    string[] buttonText;
    string[] buttonEvent;

    public NormalChat(string btxt, string nm, int sprref, int btncount, string[] btntxt, string[] btnevnt) : base(btxt, nm, sprref)
    {
        buttonCount = btncount;
        buttonText = btntxt;
        buttonEvent = btnevnt;

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
        return buttonCount;
    }

    public override string getButtonText(char btn)
    {
        switch (btn)
        {
            case 'A':
                return buttonText[0];
            case 'B':
                return buttonText[1];
            case 'C':
                return buttonText[2];
            default:
                Debug.LogError("ERROR: getButtonText called with improper (" + btn + ") argument");
                return "";
        }
    }
    public override string getNextEvent()
    {
        Debug.LogError("ERROR: getNextEvent called on NormalChat - use getButtonEvent instead");
        return "";
    }
    public override string getButtonEvent(char btn)
    {
        switch (btn)
        {
            case 'A':
                return buttonEvent[0];
            case 'B':
                return buttonEvent[1];
            case 'C':
                return buttonEvent[2];
            default:
                Debug.LogError("ERROR: getButtonEvent called with improper (" + btn + ") argument");
                return "";
        }
    }
    public override int getTrustChange()
    {
        Debug.LogError("ERROR: getTrustChange called on NormalChat - method only implemented in ModifyChat");
        return 0;
    }
    public override string getDestination()
    {
        Debug.LogError("ERROR: getDestination method called on NormalChat");
        return "";
    }
}
