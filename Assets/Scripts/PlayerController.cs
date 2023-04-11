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
    // variable to display the coin total
    public Text coinText;
    // variable to display the lives
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        // Hides the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }
    }

    // updates the text displaying how many coins and lives the player has
    void setInfoText()
    {
        coinText.text = "Coins: " + coins.ToString();
        lifeText.text = "Lives: " + lives.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {   
        // if the player touches an enemy, take away one life
        if (other.CompareTag("Enemy"))
        {
            lives--;
        }

        // increments the coin coint and disables the coin object
        if (other.CompareTag("Coin"))
        {
            coins++;
            other.gameObject.SetActive(false);
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

        // Moves the Player to the left if the player presses down the "A" key
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime * -1;
        }

        // Moves the Player to the right if the player presses down the "D" key
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
