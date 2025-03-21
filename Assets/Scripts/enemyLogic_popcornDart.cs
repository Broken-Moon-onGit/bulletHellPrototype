using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic_popcornDart : MonoBehaviour
{
    [SerializeField] basicEnemyStats enemyStats; //call enemy stats script
    [SerializeField] enemyScoreValue enemyScore; //call score script
    [SerializeField] enemy_playerAim enemyAim; //call aiming script

    public float aimingDelay;
    public float lifetime = 5;
    public float speed; //enemy speed
    public float enemyAcceleration; //acceleration rate
    public float hangTime = 3; //supposed to be for determining how long the enemy sits in one place
    public Rigidbody2D dartBody;

    private GameObject hazard_popcornDart;
    private Vector2 targetOrientation;

    float vectorDirection = 1; //used for y value in Vector2

    //bool trigger = true;
    //bool decelerate = true;
    bool accelerate = false;

    void Awake()
    {
        dartBody = GetComponent<Rigidbody2D>();
        enemyAim = GetComponent<enemy_playerAim>();

        speed = 30;
        aimingDelay = 0.1f;
        enemyStats.hitpoints = 40; //HP
        enemyStats.spawnProtection = 0.1f;
        enemyStats.killValue = 15000;

        StartCoroutine(aimDelay());

        StartCoroutine(lifespan());
    }
    
    IEnumerator aimDelay()
    {
        yield return new WaitForSeconds(aimingDelay);
        speed = 0;
        enemyAim.aiming = true;
        StartCoroutine(dartRammer());
    }
    
    IEnumerator dartRammer()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAim.aiming = false;
        accelerate = true;
    }

    IEnumerator lifespan()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
        Destroy(GetComponent<CircleCollider2D>());
        Debug.Log("Enemy Removed");
    }

    private void updateTargetDirection()
    {
        if (enemyAim.aiming == true)
        {
            targetOrientation = enemyAim.directionToPlayer;
        }
    }

    private void aimToTarget()
    {
        if (targetOrientation == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetOrientation);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100000 * Time.deltaTime);
        dartBody.SetRotation(rotation);
    }

    private void enemyVelocity()
    {
        if (targetOrientation == Vector2.zero)
        {
            Vector2 direction = new Vector2(0, vectorDirection).normalized; //enemy goes along vector
            dartBody.velocity = direction * speed; //at a constant speed based on speed value
        }
        else
        {
            enemyAcceleration = 0.5f;
            dartBody.velocity = transform.up * speed;
        }
        
    }

    void FixedUpdate()
    {
        updateTargetDirection();
        aimToTarget();
        enemyVelocity();
        if (accelerate == true)
        {
            speed += enemyAcceleration;
        }
    }
    void Update()
    {
        if (enemyAim.aiming == true)
        {

        }
    }
}
