using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class playerConfig : MonoBehaviour
{
    public int playerType;
    public float speed;
    public float focusFactor;

    public void Player1()
    {
        playerType = 0;
    }
    public void Player2()
    {
        playerType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerType == 0)
        {
            speed = 8;
            focusFactor = 1.8f;
        }
        if (playerType == 1)
        {
            speed = 16;
            focusFactor = 2.5f;
        }
    }
}
