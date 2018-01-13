using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper sK;
    public static int score;

    public Text scoreText;
    public Text gameOverText;
    public Text finalScoreText;

    public GameObject playAgainButton;

    //private GameObject player;

    public int highScore;
    public GameObject highScoreLine;

    void Start ()
    { 
        //player = GameObject.Find("Player").transform.gameObject;
        sK = this;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore1", 0);
        if (highScore > 0)
        {
            Instantiate(highScoreLine, new Vector2(0, (float)highScore), Quaternion.identity);
        }     
    }
	
	
	void Update ()
    {
        scoreText.text = "Score: " + score;
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore1", score);          
        }
    }

    public void EndGame()
    {  
        gameOverText.enabled = true;        
        finalScoreText.text = "Your score: " + score;
        finalScoreText.enabled = true;
        playAgainButton.SetActive(true);
    }

}
