using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 5;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, Vector3 impactPoint, Vector3 impactDirections)
    {
        if (rb != null)
        {
            rb.AddForceAtPosition(impactDirections * 3, impactPoint, ForceMode.Impulse);

        }
        TakeDamage(damage);
    }
}
