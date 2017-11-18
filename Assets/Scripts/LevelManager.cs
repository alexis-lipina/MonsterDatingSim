/** Mark Lipina
 *  Level Manager Script
 *  This script takes care of scene transitions and quit requests
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static void ChangeScene(string name)
    {   /// changes the scene to that of name "name"        
        SceneManager.LoadScene(name);
    }
    public void buttonChangeScene(string name)
    {   ///calls ChangeScene method because Unity buttons cant call upon static methods
        ChangeScene(name);
    }

    public static void QuitGame()
    {   ///quits the game, probably will be useful to use this if I want to quit a specific way every time
        Application.Quit();
    }
    public void buttonQuitGame()
    {
        QuitGame();
    }


}
