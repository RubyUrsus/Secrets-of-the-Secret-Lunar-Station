using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemySpawners;

    private void Start()
    {
        foreach (GameObject enemy in enemySpawners)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            foreach (GameObject enemy in enemySpawners)
            {
                enemy.SetActive(true);
            }
        }

    }
}
