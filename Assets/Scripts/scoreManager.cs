using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public enemyScoreValue eScoreValue;
    public Text scoreValue;
    public Text hiScoreValue;
    public int score;
    public int hiScore;
    private int currentScore;

    private void Awake()
    {
        scoreValue.text = score.ToString("000,000,000,000"); //updates score display based on the score value
    }
    public void scoreUpdater()
    {
        StartCoroutine(scoreUpdate());
    }

    private IEnumerator scoreUpdate()
    {

        while(score != 0)
        {
            currentScore += 100;
            scoreValue.text = currentScore.ToString("000,000,000,000");
            if (currentScore > hiScore)
            {
                hiScore = currentScore;
                hiScoreValue.text = hiScore.ToString("000,000,000,000"); //updates high score display based on current score
            }
            score -= 100;

            yield return null;
        }
        
    }
}
