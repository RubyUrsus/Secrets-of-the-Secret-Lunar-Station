using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    Animator animator;
    //[SerializeField]
    float enemyHealth;
    NavMeshAgent agent;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KillEntity()
    {
        //GameManager.Instance.TrackEnemies();
        animator.SetTrigger("Death");
        isDead = true;
        Debug.Log("Killed an enemy");
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log("took damage" + enemyHealth);
        if (enemyHealth == 0)
        {
            KillEntity();
        }
    }
}
