using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laser_spawner_prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Laser", 0f, 2f);    
    }

    public void Laser()
    {
        Instantiate(laser_spawner_prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
