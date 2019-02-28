using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public int numberOfLives;
    public Text livesText;

    public Button bugButton;
    public Button nonBugButton;

    public Text gameOverText;

    void Start()
    {
        //score.GetComponent<Text>().text = "Score: " + 20;
        score = 0;
        numberOfLives = 3;
        gameOverText.enabled = false;
        setScoreText();
        setLivesText();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void addScore()
    {
        score += 1;
        setScoreText();
    }

    public void loseLife()
    {
        if (numberOfLives > 1) {
            numberOfLives -= 1;
            setLivesText();
        }
        else
        {
            numberOfLives = 0;
            setLivesText();
            resetGame();
        }
    }

    private void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void setLivesText()
    {
        livesText.text = "Lives: " + numberOfLives.ToString();
    }

    private void resetGame()
    {
        gameOverText.enabled = true;
        StartCoroutine(waitThreeSeconds());
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds((float)3.0);
        Start();
    }
}
