using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject[] bugs;
    public int enemiesCount;

    public int score;
    public Text scoreText;

    public int numberOfLives;
    public Text livesText;

    private IEnumerator myGame;

    void Start()
    {
        score = 0;
        numberOfLives = 3;
        setScoreText();
        setLivesText();
        myGame = SpawnEnemies();
        StartCoroutine(myGame);
    }


    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForSeconds(1);

            for (int i = 0; i < bugs.Length ; i++)
            {
                var randomX = Random.Range(-10, 10);
                Quaternion spawnRotation;
                if (randomX >= 0)
                {
                    randomX = 13;
                    spawnRotation = new Quaternion(0, 0, 90, 0);
                }
                else
                {
                    randomX = -13;
                    spawnRotation = new Quaternion(0, 0, -90, 0);
                }
                Vector3 spawnPosition = new Vector3(randomX, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

                GameObject enemyBug = Instantiate(bugs[i], spawnPosition, spawnRotation) as GameObject;
                Vector3 startPos = spawnPosition;
                Vector3 endPos = new Vector3(spawnPosition.x * -1, spawnPosition.y, spawnPosition.z);
                float dist = Vector3.Distance(startPos, endPos);

                Vector3 midPos1 = Vector3.Slerp(startPos, endPos, (dist * 0.1f) / dist);
                Vector3 midPos2 = Vector3.Slerp(startPos, endPos, (dist * 0.9f) / dist);


                midPos1 += Vector3.up * 2;
                midPos2 += Vector3.up * 2;

                LTBezierPath ltPath = new LTBezierPath(new Vector3[] { startPos, midPos1, midPos2, endPos });
                if (randomX >= 0)
                {
                    LeanTween.rotateZ(enemyBug, 90, 1);
                }
                else
                {
                    LeanTween.rotateZ(enemyBug, -90, 3);
                }
                LeanTween.move(enemyBug, ltPath, Random.Range(2, 5)).setOnComplete(() => {
                    Destroy(enemyBug);
                }).setEase(LeanTweenType.easeInOutQuad); ;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
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

    public void addScore()
    {
        score += 1;
        setScoreText();

    }

    public void loseLife()
    {
        if (numberOfLives > 1)
        {
            numberOfLives -= 1;
            setLivesText();
        }
        else
        {
            numberOfLives = 0;
            setLivesText();
            StopCoroutine(myGame);
            SceneManager.LoadScene("StartMenu");
        }
    }
}
