using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Camera camera; 

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(inputX, 0);

        transform.Translate(direction * speed * Time.deltaTime);
        if (!isOnScreen())
        {
            Vector3 playerWorldPos = camera.WorldToViewportPoint(transform.position);
            transform.position = (camera.ViewportToWorldPoint(new Vector3((Mathf.Round(playerWorldPos.x) + 1) % 2, playerWorldPos.y, playerWorldPos.z)));
        }
    }

    // Tell wether the player is seen by the camera or not
    bool isOnScreen()
    {
        Vector3 playerWorldPos = camera.WorldToViewportPoint(transform.position);

        return playerWorldPos.x > 0 && playerWorldPos.x < 1;
      
    }
}
