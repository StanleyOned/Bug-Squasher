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

    void Start()
    {
        //score.GetComponent<Text>().text = "Score: " + 20;
        score = 0;
        numberOfLives = 3;
        scoreText.text = "Score: " + score.ToString ();
        livesText.text = "Lives: " + numberOfLives.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
