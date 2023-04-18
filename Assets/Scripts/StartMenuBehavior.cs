using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            this.transform.parent.gameObject.SetActive(true);
            // Makes the cursor visible
            Cursor.visible = true;
        }
    }
    
    public void gameStart()
    {
        Cursor.visible = false;
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
