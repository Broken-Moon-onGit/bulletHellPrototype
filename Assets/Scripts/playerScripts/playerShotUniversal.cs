using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShotUniversal : MonoBehaviour
{
    private float speed;
    public float damage = 10;
    public float timer = 1f;
    public Rigidbody2D shot;

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

    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
        damage = 10;
        Vector2 direction = new Vector2(0, speed);
        shot.velocity = direction; //bullet moves upward
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Timed out");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hitBox")
        {
            Destroy(gameObject);
            Destroy(GetComponent<BoxCollider2D>());
            Debug.Log("Hit!");
            return;
        }
        if (collision.gameObject.tag == "destroyer")
        {
            Destroy(gameObject);
            Destroy(GetComponent<BoxCollider>());
            Debug.Log("Shot Removed");
            return;
        }
    }
}
