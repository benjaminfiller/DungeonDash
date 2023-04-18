using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // variable to handle what scene player goes to next


    private void OnTriggerEnter(Collider other)
    {
        // if the player touches the portal
        if (other.gameObject.CompareTag("Player"))
        {
            // switch the scene or end the game
            // send the player object through to call the gameEnd function
            switchScene();
        }
    }
    public void switchScene()
    {
        // will load the build index that we set newSceneIndex to in Unity
        
        // if the current scene is the first scene

            // loads the second scene (index 1)
            SceneManager.LoadScene(1);
    }
    
}
