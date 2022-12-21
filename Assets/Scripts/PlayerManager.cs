using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject overlay;

    public static int numberOfFruits;
    public Text fruitsText;

    public Text finalScore;

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
            overlay.SetActive(false);

        }

        fruitsText.text = "Fruits: " +numberOfFruits;
        finalScore.text = "Final Score: " +numberOfFruits;
    }
}
