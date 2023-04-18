using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RestartFunction : MonoBehaviour
{
    [SerializeField]
    private FloatSO coinsSO;
    private float coins;
    // Start is called before the first frame update
    void Start()
    {
        // if the player is on the first level, set their coins to 0
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            coinsSO.Value = 0;
        }
        // stores the number of coins on level load
        coins = coinsSO.Value;
    }

    public void restart()
    {
        // resets the player and brings you back to the first level
        SceneManager.LoadScene(0);

    }

    public void restartLevel()
    {
        // reset the coin value to what it was at the start of the scene
        coinsSO.Value = coins;
        // reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
