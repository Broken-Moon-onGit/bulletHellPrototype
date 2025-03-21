using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyStats : MonoBehaviour
{
    public SpriteRenderer image;

    [SerializeField] playerShotUniversal playerBullet; //call bullet
    [SerializeField] enemyScoreValue enemyScore;
    [SerializeField] public int killValue; //score value of enemy
    [SerializeField] public float hitpoints; //enemy HP
    [SerializeField] public float spawnProtection; //invulnerable time
    bool invulnerable = true; //is invulnerable

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    void DestroyScriptInstance()
    {
        Destroy(this);
    }
    void DestroyComponent()
    {
        Destroy(GetComponent<Rigidbody2D>());
    }

    void Start()
    {
        image.color = Color.yellow;
        StartCoroutine(Invulnerability());
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (invulnerable == false)
        {
            if (collision.gameObject.tag == "playerBullet")
            {
                hitpoints -= playerBullet.damage;
                Debug.Log("Hurt!");
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Damage!");
        }
    }

    public IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(spawnProtection);

        image.color = Color.white;
        invulnerable = false;
    }

    void Update()
    {
        if (hitpoints <= 0)
        {
            enemyScore.totalKillValue += killValue;
            enemyScore.AllocateScore();
            Destroy(gameObject);
            Destroy(GetComponent<CircleCollider2D>());
            Debug.Log("Killed!");
        }
    }
}
