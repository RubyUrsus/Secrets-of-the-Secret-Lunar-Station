using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public int damage = 1; // Amount of damage each bullet does

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hit an enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Apply damage to the enemy
            enemy.TakeDamage(damage);

            // Destroy the bullet after hitting the enemy
            Destroy(gameObject);
        }
    }
}
