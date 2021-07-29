using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public event System.Action OnPlayerDeath;

    private float screenHalfWidthInWorldUnits;
    private void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;

        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            // if player crossed the right border, 'teleport' it to the left
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            // if player crossed the left border, 'teleport' it to the right
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}

// My code
//public class Player : MonoBehaviour
//{
//    [SerializeField] float speed = 5f;
//    [SerializeField] Camera camera; 

//    // Update is called once per frame
//    void Update()
//    {
//        float inputX = Input.GetAxisRaw("Horizontal");
//        Vector2 direction = new Vector2(inputX, 0);

//        transform.Translate(direction * speed * Time.deltaTime);
//        if (!isOnScreen())
//        {
//            Vector3 playerWorldPos = camera.WorldToViewportPoint(transform.position);
//            transform.position = (camera.ViewportToWorldPoint(new Vector3((Mathf.Round(playerWorldPos.x) + 1) % 2, playerWorldPos.y, playerWorldPos.z)));
//        }
//    }

//    // Tell wether the player is seen by the camera or not
//    bool isOnScreen()
//    {
//        Vector3 playerWorldPos = camera.WorldToViewportPoint(transform.position);

//        return playerWorldPos.x > 0 && playerWorldPos.x < 1;
      
//    }
//}
