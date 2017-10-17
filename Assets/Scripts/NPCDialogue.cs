/** NPC Dialogue Script
 *  Mark Lipina
 *  This class serves to read in dialogue event objects from a JSON file specific to 
 *  a given NPC, and stores it locally. It provides methods for the DialogueWindowHandler 
 *  to proceed along the dialogue structure based on given inputs, and calls upon methods
 *  in the DialogueWindowHandler to modify the text displayed based on the current 
 *  DialogueObject. 
 * */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {

    public Text TextBox;
    public Text ButtonA;
    public Text ButtonB;
    public Text ButtonC;
    public DialogueWindowHandler handler;
    Dictionary<string, DialogueEvent> npcDialogue = new Dictionary<string, DialogueEvent>();
    DialogueEvent currentDialogueEvent;

    void Start()
    {
        npcDialogue.Add("start", new NormalChat("Hi! I'm some NPC. How are you?", "Some NPC", 0, 3, new string[] { "Good, you?", "What's your name?", "Goodbye." }, new string[] { "a", "b", "exit" }));
        npcDialogue.Add("a", new NormalChat("Good, thanks!", "Some NPC", 0, 3, new string[] {"Oh... uh, Goodbye.", "Toodle-oo", "See ya." }, new string[] { "exit", "exit", "exit" }));
        npcDialogue.Add("b", new NormalChat("I just told you, I'm Some NPC", "Some NPC", 0, 3, new string[] { "Oh. Ok, bye.", "Bye, Felicia.", "Goodbye." }, new string[] { "exit", "exit", "exit" }));
        npcDialogue.Add("exit", new GoodbyeChat("Okay, see you later!", "Some NPC", 0));
        // TODO : Read dialogue from JSON or other data file
    }


    public void StartDialogue()
    { 
        if (npcDialogue.ContainsKey("start"))
        {
            currentDialogueEvent = npcDialogue["start"];
            printDialogue();
            handler.openDialogue("TestNPC");
        }
        else
        {
            print("ERROR: 'start' not in dialogue data structure!");
        }
        
    }

    public void printDialogue()
    {
        /*  This method sends display data to the DialogueWindowHandler whenever there is a change in dialogue.
         * */

        //DEBUG
        print("Printing object type...");
        print(currentDialogueEvent.GetType().ToString());
        print("...Done!");

        switch (currentDialogueEvent.GetType().ToString())
        {
            case "NormalChat":
                //TODO : Enable A B and C, disable next, send body text, send name
                handler.EnableButtonA();
                handler.EnableButtonB();
                handler.EnableButtonC();
                handler.DisableButtonNext();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.SetButtonAText(currentDialogueEvent.getButtonText('A'));
                handler.SetButtonBText(currentDialogueEvent.getButtonText('B'));
                handler.SetButtonCText(currentDialogueEvent.getButtonText('C'));
                break;
            case "MonologueChat":
                //TODO : Disable A B and C, enable Next, send body text, send name
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.EnableButtonNext();
                break;
            case "ModifyChat":
                //TODO : Disable A B and C, enable next, send body text, send name, make or send modification
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                break;
            case "GoodbyeChat":
                //TODO : Disable A B and C, enable next, send body text, send name, close window after next - - - - - - !!!IDEA - Maybe replace GoodbyeChat with a MonologueChat that has no valid next event key???
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.EnableButtonNext();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                break;
            case "VamonosChat":
                //TODO : Disable A B and C, enable next, send body text, send name, 
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                break;
        }
    }


    public void changeDialogueEvent(char buttonpressed)
    {
        if (currentDialogueEvent.GetType().ToString() == "GoodbyeChat")
        {
            handler.closeDialogue();
        }
        else
        {
            print("Button " + buttonpressed + "pressed");
            currentDialogueEvent = npcDialogue[currentDialogueEvent.getButtonEvent(buttonpressed)];
            printDialogue();
        }
        
    }




	// Update is called once per frame
	void Update ()
    {
		
	}
}
