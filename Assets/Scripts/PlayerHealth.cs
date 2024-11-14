using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GlobalFloat playerHealth;

    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Dead");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            playerHealth.currentHealth -= 20;
        }
    }
}
