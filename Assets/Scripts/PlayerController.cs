using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // controls how fast the player moves
    public float moveSpeed;
    // the rigidbody component
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
        // Moves the Player to the left if the player presses down the "A" key
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Moves the Player to the right if the player presses down the "D" key
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        // Moves the Player to the left if the player presses down the "A" key
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        // Moves the Player to the right if the player presses down the "D" key
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
    }
}
