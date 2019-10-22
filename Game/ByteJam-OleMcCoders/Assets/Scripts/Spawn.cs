using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;

    public int spawnCount;
    public float spawnTime;

    public float waveDelay;
    public float firstWaveDelay = 0;
    public int plusEnemies;
    public int remainingEnemies = 0;

    bool firstWave = true;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {

        // Initial wait

        if (firstWave = true)
        {
            yield return new WaitForSeconds(firstWaveDelay);
            
            firstWave = false;
        }
        else { yield return new WaitForSeconds(waveDelay); }


        yield return new WaitForSeconds(waveDelay);
        
        
        
        for (int count = spawnCount; count > 0; --count)
        {
            GameObject clone = Instantiate(prefab, transform.position, transform.rotation);

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
            spawnCount = spawnCount+ plusEnemies;

            StartCoroutine(SpawnObjects());
        }
    }
}