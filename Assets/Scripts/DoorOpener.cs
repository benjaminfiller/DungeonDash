using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // [Brough, Heath]
    // [4/17/2023]
    // moves the door down

    // stores the position of the down point the door should go to
    public GameObject downpoint;
    private Vector3 downPoint;

    // how many keys it takes to open the door
    public int locks;
    // how fast the door moves
    public int doorSpeed;
    // Start is called before the first frame update
    void Start()
    {
        downPoint = downpoint.gameObject.transform.position;
    }

    // moves the door down
    public void goDown()
    {
        transform.position = downPoint;
        // while the door is higher than the down position
    }
}
