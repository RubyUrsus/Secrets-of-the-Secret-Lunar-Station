using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoom03UndoChargeSpawnerActive : MonoBehaviour
{
    [SerializeField]
    AutoSpawnCharge autoSpawnChargePuzzle01;
    [SerializeField]
    AutoSpawnCharge autoSpawnChargePuzzle02;

    // Start is called before the first frame update
    void Start()
    {
        autoSpawnChargePuzzle01.enabled = true;
        autoSpawnChargePuzzle02.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            autoSpawnChargePuzzle01.enabled = false;

            GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");

            foreach (GameObject powerUp in powerUps)
            {
                Destroy(powerUp);
            }
            autoSpawnChargePuzzle02.enabled = true;
        }
    }
}
