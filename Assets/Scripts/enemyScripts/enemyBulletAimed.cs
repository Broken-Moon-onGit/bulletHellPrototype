using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletAimed : MonoBehaviour
{
    //[SerializeField] enemyBulletAimer bulletAimer;

    [SerializeField] Vector2 aim;
    public Rigidbody2D enemyBullet;
    public float bulletSpeed;
    Transform _player;

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
        enemyBullet = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<playerMovement>().transform;
        bulletSpeed = 5;
    }

    void FixedUpdate()
    {
        //bulletVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Destroy(GetComponent<BoxCollider2D>());
            Debug.Log("Bullet!");
            return;
        }
        if (collision.gameObject.tag == "destroyer")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Destroy(GetComponent<BoxCollider>());
            Debug.Log("Bullet Removed");
            return;
        }
    }
}
