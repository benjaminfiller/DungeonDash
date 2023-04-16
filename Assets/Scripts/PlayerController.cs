using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // controls how fast the player moves
    public float moveSpeed;
    // the rigidbody component
    Rigidbody rigidbody;
    // if the player is grounded they can jump
    public bool isGrounded = false;
    // bool variable that tells fixed update when to jump
    private bool jump = false;
    //a float value that controls how high the player jumps
    public float jumpForce;
    // tracks the number of coins the player has
    public int coins = 0;
    // tracks the lives the player has left
    public int lives = 3;
    // tracks the number of keys the player has
    public int keys = 0;
    // variable to display the coin total
    public Text coinText;
    // variable to display the lives
    public Text lifeText;
    // variable to display text in the pause menu
    public Text outcomeText;
    // game object holding the pause panel
    public GameObject Menu;
    // bool to check if the player can slide or not
    public bool boost;


    // Start is called before the first frame update
    void Start()
    {   
        // unfreezes time after restarting the game
        Time.timeScale = 1;
        // hides the menu on start
        Menu.SetActive(false);
        rigidbody = transform.GetComponent<Rigidbody>();
        // Hides the cursor
        Cursor.visible = false;
        outcomeText.text = "Leaving Already?";
        Menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        endCondition();
        OnPPress();
        setInfoText();
        movement();

        // fires a ray from the center of the player downwards 1.15 meters
        // returns true if it hits something
        // returns False if it doesnt hit anything
        if (Physics.Raycast(transform.position, Vector3.down, 1.15f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // if the player presses down the space bar then jump
        // if the player is sliding or getting out of a slid, they cannot jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            boost = true;
        }
    }

    // updates the text displaying how many coins and lives the player has
    void setInfoText()
    {
        coinText.text = "Coins: " + coins.ToString();
        lifeText.text = "Lives: " + lives.ToString();
    }

    // hides or shows the mouse when the P key is pressed
    private void OnPPress()
    {
        if (Input.GetKeyDown(KeyCode.P) && lives > 0)
        {
            // hides the cursor if the cursor is visible
            if (Cursor.visible == true)
            {
                // Hides the cursor
                Cursor.visible = false;
                // makes the menu invisible
                Menu.gameObject.SetActive(false);
                // locks the cursor to the center of the screen so it stays in the screen
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                // Makes the cursor visible
                Cursor.visible = true;
                // makes the menu visible
                Menu.gameObject.SetActive(true);
                // confines the cursor to the bounds of the game screen
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        // if the player touches an enemy, take away one life
        if (other.CompareTag("Enemy"))
        {
            lives--;
            Debug.Log("touched an enemy");
        }

        // increments the coin coint and disables the coin object
        if (other.CompareTag("Coin"))
        {
            coins++;
            other.gameObject.SetActive(false);
            Debug.Log("Picked up a coin");
        }
         // increments the key coint and disables the key object
        if (other.CompareTag("Key"))
        {
            keys++;
            other.gameObject.SetActive(false);
            Debug.Log("Picked up a key");
        }

    }
    
    private void FixedUpdate()
    {
        // rule of thumb - do physics manipulation in fixed update instead of update
        // if jump is true then jump once
        if (jump)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // sets jump to false after adding force so that jump does happen constantly
            jump = false;
        }
        if (boost)
        {
            rigidbody.AddForce(Vector3.up * jumpForce/2, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
            // sets jump to false after adding force so that jump does happen constantly
            boost = false;
        }
    }

    private void movement()
    {
        // Moves the Player to the left if the player presses down the "A" key
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime * -1;
        }

        // Moves the Player to the right if the player presses down the "D" key
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        // Moves the Player backwards if the player presses down the "A" key
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime * -1;
        }

        // Moves the Player forwards if the player presses down the "D" key
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    // looks for two end conditions of the game and changes the ending screen accordingly
    private void endCondition()
    {
        // if they player dies, the game over screen players 
        if (lives <= 0)
        {
            Cursor.visible = true;
            Menu.gameObject.SetActive(true);
            outcomeText.text = "Better luck next time :(\nYour score was: " + coins.ToString();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        if (coins == 2)
        {
            Cursor.visible = true;
            Menu.gameObject.SetActive(true);
            outcomeText.text = "You win!\nYour score was: " + coins.ToString();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
