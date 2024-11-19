using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTriggerer : MonoBehaviour
{

    [SerializeField] bool keyTriggered;
    [SerializeField] bool allEnemiesDead;
    [SerializeField] GameObject keyPrefab;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        keyTriggered = false;
        allEnemiesDead = false;
        keyPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (keyTriggered)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                CheckIfAllEnemiesDefeated();
                timer = 0;
            }
        }

        if (allEnemiesDead && keyTriggered)
        {
            keyPrefab.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.transform.root.gameObject)
        {
            keyTriggered = true;
        }

    }


    void CheckIfAllEnemiesDefeated()
    {
        // Haetaan kaikki objektit, joilla on "Enemy" -tunniste
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Jos vihollisia ei ole jäljellä, suoritetaan haluttu toiminto
        if (enemies.Length == 0)
        {
            OnAllEnemiesDefeated();
        }
    }

    void OnAllEnemiesDefeated()
    {
        allEnemiesDead = true;
    }
}
