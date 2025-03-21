using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScoreValue : MonoBehaviour
{
    [SerializeField] public int totalKillValue; //accumulated killValue score
    [SerializeField] basicEnemyStats enemyStats;
    private scoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<scoreManager>();
    }
    public void AllocateScore()
    {
        scoreManager.score += totalKillValue; //adds value of accumulated enemy killValue to the total score
        scoreManager.scoreUpdater();
    }

    void FixedUpdate()
    {

    }
}

// I want the score counter to increment a certain amount every frame to make the score display more dynamic