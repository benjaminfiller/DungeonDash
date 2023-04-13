using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RestartFunction : MonoBehaviour
{

    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // pulls up the restart menu and disables the restart menu button
    public void restartMenu()
    {
        Menu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
