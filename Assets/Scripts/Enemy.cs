using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 5;
    Animator animator;
    NewBehaviour enemyAI;
    [SerializeField]
    Collider colliderOne;
    [SerializeField]
    Collider colliderTwo;


    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        enemyAI = GetComponentInChildren<NewBehaviour>();
        colliderOne.enabled = true;
        colliderTwo.enabled = true;
    }
    public void TakeDamage(float damage)
    {
        SoundManager.Instance.PlayMonsterDamageSound();
        health -= damage;
        if (health < 0)
        {
            if (animator != null)
            {
                colliderOne.enabled = false;
                colliderTwo.enabled = false;
                animator.SetTrigger("IsStopped");
                Destroy(gameObject, 5);
                enemyAI.enabled = false;
            }

            SoundManager.Instance.PlayMonsterDeathSound();

        }
    }

    public void TakeDamage(float damage, Vector3 impactPoint, Vector3 impactDirections)
    {
        //if (rb != null)
        {
            //rb.AddForceAtPosition(impactDirections * 3, impactPoint, ForceMode.Impulse);
            //animator.SetTrigger("TakeDamage");
            //Debug.Log("Takes Damage");
        }
        TakeDamage(damage);
    }
}
