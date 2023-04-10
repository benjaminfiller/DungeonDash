using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaMovement : MonoBehaviour
{
    // speed controller
    public float speed;
    // left position to move to
    private Vector3 upPos;
    // right position to move to
    private Vector3 downPos;
    // left object to get the left position from
    public GameObject upPoint;
    // right object to get the right position from
    public GameObject downPoint;
    // determines whether the enemy should move left if true, or right if false
    public bool moveUp;

    // [Filler, Benjamin]
    // [3/23/2023]
    // Koopa movement script
    // Start is called before the first frame update
    void Start()
    {
        // sets the left position to the initial position of the left object
        upPos = upPoint.transform.position;
        // sets the right position to the initial position of the right object
        downPos = downPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if move left is true, check to see if the enemy should still be moving left

        if (moveUp)
        {
            // if the enemy is too far to the left, then set moveUp to false
            // which will make it move right
            if (transform.position.y >= upPos.y)
            {
                moveUp = false;
            }
            else
            {
                // if the enemy is within bounds to move left, move left
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        else
        {
            // if the enemy is too far to the right, then set moveUp to true
            // which will make it move Left
            if (transform.position.y <= downPos.y)
            {
                moveUp = true;
            }
            else
            {
                // if the enemy is within bounds to move right, move right
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}