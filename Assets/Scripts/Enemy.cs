using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 5;
    Animator animator;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            animator.SetTrigger("IsStopped");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, Vector3 impactPoint, Vector3 impactDirections)
    {
        //if (rb != null)
        {
            //rb.AddForceAtPosition(impactDirections * 3, impactPoint, ForceMode.Impulse);
            animator.SetTrigger("TakeDamage");
            Debug.Log("Takes Damage");
        }
        TakeDamage(damage);
    }
}
