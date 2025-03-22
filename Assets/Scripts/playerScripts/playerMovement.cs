using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] playerConfig _playerConfig;

    public Rigidbody2D body;
    private Vector2 movement;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        _playerConfig = GetComponent<playerConfig>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(xInput, yInput).normalized;
    }
    void FixedUpdate()
    {
        body.velocity = movement * _playerConfig.speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = (movement * _playerConfig.speed) / _playerConfig.focusFactor;
        }
    }
}
