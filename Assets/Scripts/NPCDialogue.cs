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
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogue : MonoBehaviour {

    public Text TextBox;
    public Text ButtonA;
    public Text ButtonB;
    public Text ButtonC;
    public Text ButtonD;
    public DialogueWindowHandler handler;
    Dictionary<string, DialogueEvent> npcDialogue = new Dictionary<string, DialogueEvent>();
    DialogueEvent currentDialogueEvent;
    public Sprite[] npcsprites;


    void Start()
    {
        // TODO : Read dialogueObjects from JSON
        /*
        npcDialogue.Add("start", new NormalChat("Hi! I'm some NPC. How are you?", "Some NPC", 0, 3, new string[] { "Good, you?", "What's your name?", "Goodbye." }, new string[] { "a", "b", "exit" }));
        npcDialogue.Add("a", new NormalChat("Good, thanks!", "Some NPC", 0, 3, new string[] {"Oh... uh, Goodbye.", "Toodle-oo", "See ya." }, new string[] { "exit", "exit", "exit" }));
        npcDialogue.Add("b", new NormalChat("I just told you, I'm Some NPC", "Some NPC", 0, 3, new string[] { "Oh. Ok, bye.", "Bye, Felicia.", "Goodbye." }, new string[] { "exit", "exit", "exit" }));
        npcDialogue.Add("exit", new GoodbyeChat("Okay, see you later!", "Some NPC", 0));
        */

        // Hardcoded file reading

        //npcDialogue.Add("start", new NormalChat("Hi! I'm some NPC. How are you?", "Some NPC", 0, 3, new string[] { "I'm alright.", "Good, thanks.", "Get out of my face." }, new string[] { "a", "a", "badexit" }));
        //npcDialogue.Add("a", new MonologueChat("That's good to hear!", "Some NPC", 0, "b"));
        //npcDialogue.Add("b", new NormalChat("What can I do for you?", "Some NPC", 0, 3, new string[] { "You're pretty cute.", "What is this place?", "I should go." }, new string[] { "c", "d", "goodexit" }));
        //npcDialogue.Add("c", new MonologueChat("Uh, thanks, but we just met. Ease off on the afterburners, buddy.", "Some NPC", 0, "b"));
        //npcDialogue.Add("d", new MonologueChat("This is the Galacticapital™, the center of commerce, trade and politics between the civilizations within our galaxy!", "Some NPC", 0, "e"));
        //npcDialogue.Add("e", new MonologueChat("Here, you can find portals to some planets you'll hopefully see in more detail once this game is more developed. Feel free to pay them a visit, public transit is free in the Future!", "Some NPC", 0, "b"));
        //npcDialogue.Add("goodexit", new GoodbyeChat("Alright, good to meet you, have a pleasant stay!", "Some NPC", 0));
        //npcDialogue.Add("badexit", new GoodbyeChat("Wow, I hope the rest of your species isn't as rude as you. Dont expect any help from me, buddy.", "Some NPC", 0));


        loadDialogueFromJSON("testdialogue1.json");
    }

  
    private void loadDialogueFromJSON(string filename)
    {
        StreamReader filestream = new StreamReader(Application.dataPath + "/" + filename);
        JSONDialogueCollection dialoguearray = JsonUtility.FromJson<JSONDialogueCollection>(filestream.ReadToEnd());
        filestream.Close();

        JSONDialogue[] tempevents = dialoguearray.nodes;
        for (int i = 0; i < tempevents.Length; i++)
        {
            switch (tempevents[i].dialoguetype)
            {
                case "GoodbyeChat":                   
                    npcDialogue.Add(tempevents[i].eventkey, new GoodbyeChat(tempevents[i].bodytext, tempevents[i].speakername, tempevents[i].spriteindex));
                    Debug.Log("GoodbyeChat created.");
                    break;
                case "ModifyChat":
                    npcDialogue.Add(tempevents[i].eventkey, new ModifyChat(tempevents[i].bodytext, tempevents[i].speakername, tempevents[i].spriteindex, tempevents[i].trustchange, tempevents[i].nextkey));
                    Debug.Log("ModifyChat created.");
                    break;
                case "MonologueChat":
                    npcDialogue.Add(tempevents[i].eventkey, new MonologueChat(tempevents[i].bodytext, tempevents[i].speakername, tempevents[i].spriteindex, tempevents[i].nextkey));
                    Debug.Log("MonologueChat created.");
                    break;
                case "NormalChat":
                    npcDialogue.Add(tempevents[i].eventkey, new NormalChat(tempevents[i].bodytext, tempevents[i].speakername, tempevents[i].spriteindex, tempevents[i].buttoncount, tempevents[i].buttontext, tempevents[i].buttonevent));
                    Debug.Log("NormalChat created.");
                    break;
                case "VamonosChat":
                    npcDialogue.Add(tempevents[i].eventkey, new VamonosChat(tempevents[i].bodytext, tempevents[i].speakername, tempevents[i].spriteindex, tempevents[i].destination));
                    Debug.Log("VamonosChat created.");
                    break;
                default:
                    Debug.Log("ERROR: Invalid dialoguetype in json file " + filename + ", at index " + i);
                    break;
            }
        }
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
               
                handler.DisableButtonNext();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                switch (currentDialogueEvent.getButtonCount())
                {
                    case (1):
                        handler.EnableButtonA();
                        handler.SetButtonAText(currentDialogueEvent.getButtonText('A'));
                        break;
                    case (2):
                        handler.EnableButtonA();
                        handler.EnableButtonB();
                        handler.SetButtonAText(currentDialogueEvent.getButtonText('A'));
                        handler.SetButtonBText(currentDialogueEvent.getButtonText('B'));
                        break;
                    case (3):
                        handler.EnableButtonA();
                        handler.EnableButtonB();
                        handler.EnableButtonC();
                        handler.SetButtonAText(currentDialogueEvent.getButtonText('A'));
                        handler.SetButtonBText(currentDialogueEvent.getButtonText('B'));
                        handler.SetButtonCText(currentDialogueEvent.getButtonText('C'));
                        break;
                    case (4):
                        handler.EnableButtonA();
                        handler.EnableButtonB();
                        handler.EnableButtonC();
                        handler.EnableButtonD();
                        handler.SetButtonAText(currentDialogueEvent.getButtonText('A'));
                        handler.SetButtonBText(currentDialogueEvent.getButtonText('B'));
                        handler.SetButtonCText(currentDialogueEvent.getButtonText('C'));
                        handler.SetButtonDText(currentDialogueEvent.getButtonText('D'));
                        break;
                }
                
                handler.SetSpeakerText(currentDialogueEvent.getName());
                break;
            case "MonologueChat":
                //TODO : Disable A, B, C, and D, enable Next, send body text, send name
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.DisableButtonD();
                handler.EnableButtonNext();
                handler.SetSpeakerText(currentDialogueEvent.getName());
                break;
            case "ModifyChat":
                //TODO : Disable A, B, C, and D, enable next, send body text, send name, make or send modification
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.DisableButtonD();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.SetSpeakerText(currentDialogueEvent.getName());
                break;
            case "GoodbyeChat":
                //TODO : Disable A, B, C, and D, enable next, send body text, send name, close window after next - - - - - - !!!IDEA - Maybe replace GoodbyeChat with a MonologueChat that has no valid next event key???
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.DisableButtonD();
                handler.EnableButtonNext();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.SetSpeakerText(currentDialogueEvent.getName());
                break;
            case "VamonosChat":
                //TODO : Disable A, B, C, and D, enable next, send body text, send name, 
                handler.DisableButtonA();
                handler.DisableButtonB();
                handler.DisableButtonC();
                handler.DisableButtonD();
                handler.SetBodyText(currentDialogueEvent.getBodyText());
                handler.SetSpeakerText(currentDialogueEvent.getName());
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
            print("Button " + buttonpressed + " pressed");
            currentDialogueEvent = npcDialogue[currentDialogueEvent.getButtonEvent(buttonpressed)];
            printDialogue();
        }
        
    }
}
