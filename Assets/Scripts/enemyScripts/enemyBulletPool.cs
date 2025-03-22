using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletPool : MonoBehaviour
{
    public static enemyBulletPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 65536;

    [SerializeField] private GameObject enemyBullet;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyBullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
