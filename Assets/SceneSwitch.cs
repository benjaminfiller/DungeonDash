using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // player gameobject
    public GameObject player;
    // variable to handle what scene player goes to next
    public int newSceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchScene()
    {
        // will load the build index that we set newSceneIndex to in Unity
        SceneManager.LoadScene(newSceneIndex);
    }
    private void Awake()
    {
        //array of player objects
        GameObject[] playerobjects = GameObject.FindGameObjectsWithTag(player.tag);
        // if array returns larger than 1 there is more than 1 player
        if (playerobjects.Length > 1)
        {
            //destroy player in assigned scene
            Destroy(player);

        }
        else
        {
            // dont want to destroy the following:
            // player
            DontDestroyOnLoad(player);
        }
    }
}
