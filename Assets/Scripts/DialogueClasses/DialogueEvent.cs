using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueEvent
{
    protected string bodyText;
    protected string name;
    protected int spriteReference;

    public DialogueEvent(string btxt, string nm, int sprref)
    {
        bodyText = btxt;
        name = nm;
        spriteReference = sprref;
    }

    public abstract int getButtonCount();
    public abstract string getBodyText();
    public abstract int getSpriteReference();
    public abstract string getName();
    public abstract string getButtonText(char btn);
    public abstract string getNextEvent();
    public abstract string getButtonEvent(char btn);
    public abstract int getTrustChange();
    public abstract string getDestination();

}
