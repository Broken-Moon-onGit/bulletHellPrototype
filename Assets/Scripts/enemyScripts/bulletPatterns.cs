using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPatterns : MonoBehaviour
{
    Transform _player;

    enemyBulletAimed bulletAim;
    GameObject enemyBullet;

    // Start is called before the first frame update
    void Awake()
    {
        _player = FindObjectOfType<playerMovement>().transform;
        bulletAim = GetComponent<enemyBulletAimed>();
    }

    public void BasicAimedShot()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject bullet = enemyBulletPool.instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = gameObject.transform.position;
            }
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.up = _player.transform.position - bullet.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            bulletRB.velocity += (Vector2)bullet.transform.up * bulletAim.bulletSpeed;
        }
    }

    public void TripleAimedShot()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = enemyBulletPool.instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = gameObject.transform.position;
            }
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.up = _player.transform.position - bullet.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 10 * (i - 1));
            bulletRB.velocity += (Vector2)bullet.transform.up * bulletAim.bulletSpeed;
        }
    }

    public void SixteenWayAimedShot()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject bullet = enemyBulletPool.instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = gameObject.transform.position;
            }
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.up = _player.transform.position - bullet.transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 22.5f * i);
            bulletRB.velocity += (Vector2)bullet.transform.up * bulletAim.bulletSpeed;
        }
    }

    public void SixteenWayNormalShot()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject bullet = enemyBulletPool.instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = gameObject.transform.position;
            }
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.up = Vector3.up;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 22.5f * i);
            bulletRB.velocity += (Vector2)bullet.transform.up * bulletAim.bulletSpeed;
        }
    }


}
