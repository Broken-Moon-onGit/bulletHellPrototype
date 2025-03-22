using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] public class Spawnable //framework for spawning enemies
{
    public GameObject hazardEnemy;
    public int spawnCount;
    public float spawnCooldown;
    public Vector3 spawnOffset;
}

[System.Serializable] public class Wave //framework for spawning waves 
{
    public List<Spawnable> wavePattern = new List<Spawnable>();
    public int waveRepeat;
    public float repeatCooldown;
    public float waveDelay;
}

public class basicEnemySpawner_test : MonoBehaviour
{
    public List<Wave> Wave = new List<Wave>(); //assign enemy GameObjects to create waves to spawn
    public float startSpawnDelay;

    void Start()
    {
        StartCoroutine(SpawnEnemies(Wave, startSpawnDelay));
    }
    IEnumerator SpawnEnemies(List<Wave> waveTable, float startDelay) //wave and enemy spawning parameters
    {
        yield return new WaitForSeconds(startDelay);

        foreach (Wave w in waveTable)
        {
            for (int i = 0; i < w.waveRepeat; i++)
            {
                foreach (Spawnable s in w.wavePattern)
                {
                    for (int k = 0; k < s.spawnCount; k++)
                    {
                        GameObject spawnedEnemy = (GameObject)Instantiate(s.hazardEnemy, (gameObject.transform.position)+ s.spawnOffset, Quaternion.identity);

                        yield return new WaitForSeconds(s.spawnCooldown);
                    }
                }
                yield return new WaitForSeconds(w.repeatCooldown);
                Debug.Log("Wave Repeat");
            }
            yield return new WaitForSeconds(w.waveDelay);
            Debug.Log("New Wave");
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
