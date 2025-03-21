using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] public class bulletSpawnable //framework for spawning bullets
{
    public GameObject hazardBullet;
    public int bulletSpawnCount;
    public float bulletSpawnCD;
    public Vector3 bulletSpawnOffset;
}

[System.Serializable] public class bulletWave //framework for spawning bullet patterns 
{
    public List<bulletSpawnable> bulletPattern = new List<bulletSpawnable>();
    public int bulletRepeat;
    public float bulletRepeatCooldown;
    public float bulletDelay;
}

public class bulletSpawner_test : MonoBehaviour
{
    public List<bulletWave> bulletWave = new List<bulletWave>(); //assign enemy GameObjects to create bullet patterns to spawn
    public float startBulletDelay;

    void Start()
    {
        StartCoroutine(SpawnEnemies(bulletWave, startBulletDelay));
    }
    IEnumerator SpawnEnemies(List<bulletWave> bulletWaveTable, float startDelay) //bullet spawning parameters
    {
        yield return new WaitForSeconds(startDelay);

        foreach (bulletWave w in bulletWaveTable)
        {
            for (int i = 0; i < w.bulletRepeat; i++)
            {
                foreach (bulletSpawnable s in w.bulletPattern)
                {
                    for (int k = 0; k < s.bulletSpawnCount; k++)
                    {
                        GameObject spawnedEnemy = (GameObject)Instantiate(s.hazardBullet, (gameObject.transform.position)+ s.bulletSpawnOffset, Quaternion.identity);

                        yield return new WaitForSeconds(s.bulletSpawnCD);
                    }
                }
                yield return new WaitForSeconds(w.bulletRepeatCooldown);
                Debug.Log("bulletWave Repeat");
            }
            yield return new WaitForSeconds(w.bulletDelay);
            Debug.Log("New bulletWave");
        }
    }







    /*
        [SerializeField] private GameObject hazardEnemy;
        [SerializeField] private float spawnTimer = 3;

        private float timeUntilSpawn;

        private void SetTimeUntilSpawn()
        {
            timeUntilSpawn = spawnTimer;
        }


        // Start is called before the first frame update
        void Awake()
        {
            SetTimeUntilSpawn();
        }

        // Update is called once per frame
        void Update()
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {
                Instantiate(hazardEnemy, transform.position, Quaternion.identity);
                Debug.Log("New Enemy!");
                SetTimeUntilSpawn();
                return;
            }
        }*/

}
