using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [Brough, Heath]
// [4/15/2023]
// rotates the key
public class KeyRotator : MonoBehaviour
{
    // how fast the coin rotates
    public float degreesPerSecond;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // rotates the coin degreesPerSecond degrees every second
        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    }
}
