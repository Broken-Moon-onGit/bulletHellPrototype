using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBasicWeaponUniversal : MonoBehaviour
{
    public GameObject shotPrefab;
    
    private float firingDelay = 0.05f;
    private float cooldownTimer = 0; 

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && cooldownTimer <= 0)
        {
            Instantiate(shotPrefab, this.transform.position, Quaternion.identity);
            cooldownTimer = firingDelay;
            Debug.Log("Firing!");
            return;
        }
    }
}
