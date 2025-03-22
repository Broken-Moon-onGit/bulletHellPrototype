using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_playerAim : MonoBehaviour
{
    public bool aiming = false;
    public Vector3 directionToPlayer { get; private set; }

    private Transform _player;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _player = FindObjectOfType<playerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyToPlayerVector = _player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
        transform.rotation = Quaternion.LookRotation(enemyToPlayerVector);
    }
}
