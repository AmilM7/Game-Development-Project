using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static int numberOfFruits;
    public Text fruitsText;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberOfFruits = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale=0;
            gameOverPanel.SetActive(true);
        }

        fruitsText.text = "Fruits: " +numberOfFruits;
    }
}
