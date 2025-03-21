using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    [SerializeField] public int lives = 3;
    [SerializeField] public int bombs = 2;
    [SerializeField] bool gameOver = false;

    void Awake()
    {

    }

    public void GameOver()
    {
        if (lives <= 0) {
            Debug.Log("Game Over!");
        }
    }
}
