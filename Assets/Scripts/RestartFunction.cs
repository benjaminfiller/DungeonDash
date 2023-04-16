using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RestartFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void restart()
    {
        // resets the player and brings you back to the first level
        SceneManager.LoadScene(0);
    }
}
