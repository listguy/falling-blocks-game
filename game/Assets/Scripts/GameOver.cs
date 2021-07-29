using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text secondsSurvivedUI;
    private bool gameOver;

    private void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += onGameOver;
    }

    void Update()
    {
        if(gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void onGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;

    }
}
