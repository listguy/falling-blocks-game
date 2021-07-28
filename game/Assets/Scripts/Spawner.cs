using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject fallingBlockPrefab;
    [SerializeField] float secondsBetweenSpawns = 1;
    private float nextSpawnTime;

    // store the minimum and maximum falling cube dise size as a (x,y)
    [SerializeField] Vector2 spawnSizeMinMax;
    [SerializeField] float spawnAngleMax;

    // store the screen ratios as a (x,y)
    private Vector2 screenHalfSizeWorldUnits;
    
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float randomSideSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float halfPlayerHeight = randomSideSize;

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + halfPlayerHeight);

            // create a new falling block
            GameObject newFallingBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            // give it a random size
            // Instead of adding to the existing scale:
            //newFallingBlock.transform.localScale += new Vector3(randomSideSize, randomSideSize, 0);
            // I'll just set the random one:
            newFallingBlock.transform.localScale = Vector2.one * randomSideSize;
        }
    }
}

// Spawning blocks code moved here from FallingBlock after video instructions
