using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // speed controller
    public float speed;
    // left position to move to
    private Vector3 leftPos;
    // right position to move to
    private Vector3 rightPos;
    // left object to get the left position from
    public GameObject leftPoint;
    // right object to get the right position from
    public GameObject rightPoint;
    // determines whether the enemy should move left if true, or right if false
    public bool moveLeft;

    // [Filler, Benjamin]
    // [3/23/2023]
    // Enemy movement script
    // Start is called before the first frame update
    void Start()
    {
        // sets the left position to the initial position of the left object
        leftPos = leftPoint.transform.position;
        // sets the right position to the initial position of the right object
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if move left is true, check to see if the enemy should still be moving left
        
        if (moveLeft)
        {
            // if the enemy is too far to the left, then set moveLeft to false
            // which will make it move right
            if (transform.position.x <= leftPos.x)
            {
                moveLeft = false;
            }
            else
            {
                // if the enemy is within bounds to move left, move left
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            // if the enemy is too far to the right, then set moveLeft to true
            // which will make it move Left
            if (transform.position.x >= rightPos.x)
            {
                moveLeft = true;
            }
            else
            {
                // if the enemy is within bounds to move right, move right
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
