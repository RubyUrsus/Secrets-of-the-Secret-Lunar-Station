using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float SpawnTime;
    [SerializeField]
    private float timer;
    [SerializeField]
    int maxEnemiesToSpawn;

    [SerializeField]
    GameObject enemy;

    private void Start()
    {
        //if ((GameObject == null) = FindObjectOfType<GameObject>();
    }

    public void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            //Debug.Log("Spawning started");
            {
                //Debug.Log(maxEnemiesToSpawn - 1);
                //maxEnemiesToSpawn = maxEnemiesToSpawn - 1;
                //maxEnemiesToSpawn -= 1;
                if (maxEnemiesToSpawn > 0)
                {
                    maxEnemiesToSpawn -= 1;
                    SpawnEnemies();
                    timer = 0;
                }
                else
                {
                    timer = 0;
                }
            }
        }
    }

    private void SpawnEnemies()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        timer = 0;
    }
}
