using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public Text highscoreDisplay;


      void Start()
    {
        highscoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // increase score of 1
            score++;
            Debug.Log(score);

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highscoreDisplay.text = score.ToString();
            }
            
        }
    }
}
