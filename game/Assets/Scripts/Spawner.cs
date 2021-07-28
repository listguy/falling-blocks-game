using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject fallingBlockPrefab;
    [SerializeField] Vector2 secondsBetweenSpawnsMinMax;
    private float nextSpawnTime;

    // store the minimum and maximum falling cube dise size as a (x,y)
    [SerializeField] Vector2 spawnSizeMinMax;
    [SerializeField] float spawnAngleMax;

    // store the screen ratios as a (x,y)
    private Vector2 screenHalfSizeWorldUnits;

    // Difficulty hadler moved into a different script, Difficulty.cs, after video instructions
    // Difficulity will grow every x seconds until difficulity hits five, where x = secondsBetweenDifficulityIncrease
    //public static float currentDifficulity = 1;
    //[SerializeField] float secondsBetweenDifficulityIncrease = 10;
    //private float nextDifficulityIncreaseTime;
    
    void Start()
    {
        // Old difficulty handling
        //nextDifficulityIncreaseTime = Time.time + secondsBetweenDifficulityIncrease;
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        // Old difficulty handling
        //if (Time.time > nextDifficulityIncreaseTime && currentDifficulity < 5)
        //{
        //    currentDifficulity++;
        //    nextDifficulityIncreaseTime = Time.time + secondsBetweenDifficulityIncrease;
        //}

        if(Time.time > nextSpawnTime)
        {
            // Old difficulty handling
            // nextSpawnTime = Time.time + (secondsBetweenSpawns * (1 - 0.1f * (currentDifficulity - 1)));
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Debug.Log(secondsBetweenSpawns);

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

// Spawning blocks code moved here from FallingBlock.cs after video instructions
