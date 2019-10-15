using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject spawnee;
    public int spawnLimit;
    public int spawnAmmount;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {

        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }

    public void SpawnObject()
    {

            Instantiate(spawnee, transform.position, transform.rotation);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        
    }

    void Update()
    {
        


    }
}
