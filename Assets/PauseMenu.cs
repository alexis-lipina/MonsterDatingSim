using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private GameObject[] interactibles;



    public void OpenMenu()
    {
        interactibles = GameObject.FindGameObjectsWithTag("Interactible");
        this.gameObject.SetActive(true);
        for (int i = 0; i < interactibles.Length; i++)
        {
            interactibles[i].SetActive(false);
        }
    }

    public void MainMenuButton()
    {
        LevelManager.ChangeScene("MainMenu");
    }


	public void ResumeButton()
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < interactibles.Length; i++)
        {
            interactibles[i].SetActive(true);
        }
    }

    public void SaveButton()
    {
        print("Save button pressed.");
    }

    public void LoadButton()
    {
        print("Load button pressed.");
    }

    public void OptionsButton()
    {
        print("Option button pressed.");
    }

    public void QuitButton()
    {
        print("Quit button pressed.");
        LevelManager.QuitGame();
        print("Shouldnt get here.");
    }
}
