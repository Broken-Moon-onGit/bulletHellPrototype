using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    [SerializeField] gameManagerScript gameManager;

    void Awake()
    {
        gameManager = GetComponent<gameManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hazard" && collision.gameObject.tag == "bulletHazard")
        {
            gameManager.lives--;
            gameManager.bombs = 2;
            if (gameManager.lives > 1) {
                Debug.Log("Death! " + gameManager.lives + " lives left!");
            } else if (gameManager.lives == 1) {
                Debug.Log("Death! Last life!");
            } else if (gameManager.lives == 0) {
                Debug.Log("GAME OVER!");
            } else {
                Debug.Log("how");
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && gameManager.bombs > 0)
        {
            gameManager.bombs--;
            Debug.Log("Bomb!");
            return;
        }
        if (Input.GetKeyDown(KeyCode.X) && gameManager.bombs <= 0)
        {
            Debug.Log("You're out of Bombs!");
            return;
        }


        /*        int hasBomb = 0;
                if (bombs > 1) { hasBomb = 1; }

                switch (hasBomb)
                {
                    case 1:
                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            Debug.Log("Bomb!");
                        }
                        break;
                    default:
                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            Debug.Log("You're out of Bombs!");
                        }
                        break;*/
    }
}
