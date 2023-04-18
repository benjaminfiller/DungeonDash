using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // variable to handle what scene player goes to next
    public int newSceneIndex;


    private void OnTriggerEnter(Collider other)
    {
        // if the player touches the portal
        if (other.gameObject.CompareTag("Player"))
        {
            // switch the scene or end the game
            // send the player object through to call the gameEnd function
            switchScene(other);
        }
    }
    public void switchScene(Collider other)
    {
        // will load the build index that we set newSceneIndex to in Unity
        
        // if the current scene is the first scene
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // loads the second scene (index 1)
            SceneManager.LoadScene(newSceneIndex);
        }
        else
        {
            // ends the game if the player hits the exit in the second scene
            other.gameObject.GetComponent<PlayerController>().gameEnd(true);
        }
    }
    
}
