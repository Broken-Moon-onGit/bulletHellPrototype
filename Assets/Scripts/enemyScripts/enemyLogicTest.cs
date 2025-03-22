using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogicTest : MonoBehaviour
{
    public float speed = 2;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(0, -1).normalized;
        body.velocity = direction * speed;
    }
}
