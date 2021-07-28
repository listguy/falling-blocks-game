﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    
    [SerializeField] float speed = 7f;
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime * (1 + Spawner.currentDifficulity / 5));
    }
}

// My code that is responsible for block spawning. Video instructions have it in another script called 'Spawner'
// This script now handles moving the block down and destroying it
//public class FallingBlock : MonoBehaviour
//{
//    [SerializeField] Rigidbody2D fallingBlock;
//    private float screenHalfWidthInWorldUnits;
//    private float screenHeightInWorldUnits;
//    private float yAxisSpanPoint;
//    // Start is called before the first frame update
//    void Start()
//    {
//        float halfBlockWidth = fallingBlock.transform.localScale.x / 2f;
//        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfBlockWidth;
//        screenHeightInWorldUnits = (1 / Camera.main.aspect) * 2 * (screenHalfWidthInWorldUnits + halfBlockWidth);
//        yAxisSpanPoint = screenHeightInWorldUnits / 2 + fallingBlock.transform.localScale.y;
//        InvokeRepeating("spawnBlock", 1, 1);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void spawnBlock()
//    {
//        Rigidbody2D instance = Instantiate(fallingBlock, new Vector3(Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits), yAxisSpanPoint), Quaternion.Euler(0, 0, 0));

//        instance.velocity = Vector2.up * -3;
//        Destroy(instance.gameObject, 5);
//    }
//}
