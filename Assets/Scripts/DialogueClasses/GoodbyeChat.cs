using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This DialogueEvent class allows the display of body text and the "next" button,
/// and afterwards closes the interface
/// </summary>
public class GoodbyeChat : DialogueEvent {

    

    public GoodbyeChat(string btxt, string nm, int sprref) : base(btxt, nm, sprref)
    {   }


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
        Debug.LogError("ERROR: getButtonCount called on GoodbyeChat");
        return 0;
    }

    public override string getButtonText(char btn)
    {
        Debug.LogError("ERROR: getButtonText called on GoodbyeChat");
        return "";
    }
    public override string getNextEvent()
    {
        Debug.LogError("ERROR: getNextEvent called on GoodbyeChat");
        return null;
    }
    public override string getButtonEvent(char btn)
    {
        Debug.LogError("ERROR: getButtonEvent called on GoodbyeChat");
        return "";
    }
    public override int getTrustChange() 
    {
        Debug.LogError("ERROR: getTrustChange called on GoodbyeChat - method only implemented in ModifyChat");
        return 0;
    }
    public override string getDestination()
    {
        Debug.LogError("ERROR: getDestination method called on GoodbyeChat");
        return "";
    }
}
