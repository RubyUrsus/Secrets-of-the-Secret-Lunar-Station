using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] GlobalFloat playerHealth;

    SaveManager saveManager;

    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
        saveManager = GetComponent<SaveManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V)) playerHealth.currentHealth = playerHealth.maxHealth;
        if (Input.GetKeyDown(KeyCode.K)) playerHealth.currentHealth = 0;

        if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        saveManager.Load();
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.PlayHumanDamageSound();
        if (collision.gameObject.tag == "Damage")
        {
            playerHealth.currentHealth -= 20;
        }
    }

    public void TakeDamagee(float damageAmount)
    {
        //throw new System.NotImplementedException();
        playerHealth.currentHealth -= 20;
    }
}
