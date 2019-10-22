using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;

    public int spawnCount;

    public float spawnTime;

    public float spawnDelay;

    public int remainingEnemies = 0;

    float x;
    float z;

    public float MinX ;
    public float MaxX ;
    public float MinZ ;
    public float MaxZ ;




    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {

        // Initial wait
        yield return new WaitForSeconds(spawnDelay);

        for (int count = spawnCount; count > 0; --count)
        {
            x = Random.Range(MinX, MaxX);
            z = Random.Range(MinZ, MaxZ);


            GameObject clone = Instantiate(prefab, transform.position+(new Vector3(x,0,z)), Quaternion.identity);

            DestroyEventEmitter destroyEventEmitter = clone.AddComponent<DestroyEventEmitter>();
            destroyEventEmitter.OnObjectDestroyedEvent += OnGameObjectDestroyed;
            remainingEnemies++;

            // Wait before next spawn
            yield return new WaitForSeconds(spawnTime);

        }

        Debug.Log("All the ennemies have been instantiated !");
    }

    private void OnGameObjectDestroyed(DestroyEventEmitter emitter)
    {
        remainingEnemies--;
        emitter.OnObjectDestroyedEvent -= OnGameObjectDestroyed;

        Debug.Log("Remaining ennemies : " + remainingEnemies);

        if (remainingEnemies == 0)
        {
            spawnCount++;

            StartCoroutine(SpawnObjects());
        }
    }
}