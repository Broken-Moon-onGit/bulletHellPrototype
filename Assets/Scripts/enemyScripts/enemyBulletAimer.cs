using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletAimer : MonoBehaviour
{
    [SerializeField] enemy_playerAim enemyAim; //call aiming script


    public Vector2 aimOrientation { get; set; }
    public Rigidbody2D enemyAimer;

    void Awake()
    {
        enemyAim = GetComponent<enemy_playerAim>();
        enemyAim.aiming = true;
    }

    private void updateTargetDirection()
    {
        aimOrientation = enemyAim.directionToPlayer;
    }

    private void aimToTarget()
    {
        if (aimOrientation == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, aimOrientation);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100000 * Time.deltaTime);
        enemyAimer.SetRotation(rotation);
    }

    void FixedUpdate()
    {
        updateTargetDirection();
        aimToTarget();
    }
}