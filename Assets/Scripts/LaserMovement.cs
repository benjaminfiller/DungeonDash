using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifetime());

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }
    public IEnumerator Lifetime()
    {
        for (int index = 0; index < 1; index++)
        {
            yield return new WaitForSeconds(3 / 2);

        }
        Destroy(this.gameObject);
    }
}
