using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic_popcornScout : MonoBehaviour
{
    [SerializeField] basicEnemyStats enemyStats; //call enemy stats script
    [SerializeField] enemyScoreValue enemyScore; //call score script

    [SerializeField] float lifetime = 5;
    
    public float speed; //enemy speed
    public float hangTime = 2; //supposed to be for determining how long the enemy sits in one place
    public Rigidbody2D scoutBody;

    float vectorDirection = -1; //used for y value in Vector2

    bool trigger = true;
    bool decelerate = true;
    bool accelerate = false;

    void Start()
    {
        speed = 15;
        enemyStats.hitpoints = 70; //HP
        enemyStats.spawnProtection = 0.25f;
        enemyStats.killValue = 15000;
        StartCoroutine(lifespan());
    }
    IEnumerator stayInPlace()
    {
        Debug.Log("Stopped");

        yield return new WaitForSeconds(hangTime);

        vectorDirection = 1; //makes y value of Vector2 point UP
        accelerate = true; //start acceleration code
        Debug.Log("Heading Back");
    }

    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
        Destroy(GetComponent<CircleCollider2D>());
        Debug.Log("Enemy Removed");
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(0, vectorDirection).normalized; //enemy goes along vector
        scoutBody.velocity = direction * speed; //at a constant speed based on speed value

        if (decelerate == true) //deceleration code; reduce speed of enemy when active
        {
            speed -= 1f;
        }
        if (speed <= 0 && trigger == true)
        {
            decelerate = false; //stop deceleration code
            trigger = false; //prevents this chunk of code from running continuously
            StartCoroutine(stayInPlace());
        }
        if (accelerate == true) //acceleration code; increase speed of enemy when active
        {
            speed += 1f;
        }

    }
    void Update()
    {

    }
}

