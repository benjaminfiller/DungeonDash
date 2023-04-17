using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
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
}
