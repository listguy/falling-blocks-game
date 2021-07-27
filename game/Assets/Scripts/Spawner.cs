using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject fallingBlockPrefab;
    [SerializeField] float secondsBetweenSpawns = 1;

    // store the sizes as a (x,y)
    private Vector2 screenHalfSizeWorldUnits;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float halfPlayerHeight = 0.5f;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + halfPlayerHeight);

            Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

// Spawning blocks code moved here from FallingBlock after video instructions
