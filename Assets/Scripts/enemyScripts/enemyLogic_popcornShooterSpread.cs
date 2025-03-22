using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic_popcornShooterSpread : MonoBehaviour
{
    [SerializeField] basicEnemyStats enemyStats; //call enemy stats script
    [SerializeField] bulletPatterns bulletPattern;
    [SerializeField] GameObject enemyBullet;
    GameObject BulletPatternLibrary;


    [SerializeField] float lifetime = 5;

    Transform _player;

    public float speed; //enemy speed
    public float hangTime = 3; //supposed to be for determining how long the enemy sits in one place
    public float waitTime = 0.25f;
    public int ammo;
    public float shootingCD;
    public float nextShot;
    public Rigidbody2D shooterBody;

    float vectorDirectionX = 0;
    float vectorDirectionY = -1; //used for y value in Vector2

    bool trigger = true;
    bool canShoot = false;
    bool decelerate = true;
    bool accelerate = false;

    void Awake()
    {
        enemyStats = GetComponent<basicEnemyStats>();
        BulletPatternLibrary = GameObject.FindWithTag("patternLib");
        bulletPattern = BulletPatternLibrary.GetComponent<bulletPatterns>();
        Debug.Log(bulletPattern);

        _player = FindObjectOfType<playerMovement>().transform;

        speed = 8f;
        enemyStats.hitpoints = 150; //HP
        ammo = 5;
        shootingCD = 1/3f;
        nextShot = Time.time;

        enemyStats.spawnProtection = 0.25f;
        enemyStats.killValue = 15000;
        StartCoroutine(lifespan());
    }
    
    IEnumerator firingDelay()
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Firing");
        canShoot = true;
    }

    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
        Destroy(GetComponent<CircleCollider2D>());
        Debug.Log("Enemy Removed");
    }
    
    void reloadTimer()
    {        
        if (ammo > 0 && canShoot == true)
        {
            if (Time.time > nextShot)
            {
                bulletPattern.TripleAimedShot();
                nextShot = Time.time + shootingCD;
                ammo--;
            }
        }
        if (ammo <= 0)
        {
            accelerate = true;
            //vectorDirectionX = 1;
        }
    }

    void FixedUpdate()
    {
        reloadTimer();
        
        Vector2 direction = new Vector2(vectorDirectionX, vectorDirectionY).normalized; //enemy goes along vector
        shooterBody.velocity = direction * speed; //at a constant speed based on speed value

        if (decelerate == true) //deceleration code; reduce speed of enemy when active
        {
            speed -= 0.25f;
        }
        if (speed <= 1 && trigger == true)
        {
            decelerate = false; //stop deceleration code
            trigger = false; //prevents this chunk of code from running continuously
            StartCoroutine(firingDelay());
        }
        if (accelerate == true) //acceleration code; increase speed of enemy when active
        {
            speed += 0.25f;
        }
    }

}
