using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public int maxHealth = 3; // Set the health to 3 hits
    private int currentHealth;

    // Optional death effect
    public GameObject deathEffect;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by damage amount
        currentHealth -= damage;

        // Check if health is zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optional: Instantiate a death effect at the enemy's position
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
