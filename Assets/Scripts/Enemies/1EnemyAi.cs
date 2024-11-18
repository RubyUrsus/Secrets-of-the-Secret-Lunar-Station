using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    private float timer;
    Animator animator;
    [SerializeField]
    float damage;
    [SerializeField]
    float maxAttackCoolDown;
    [SerializeField]
    float attackCoolDown;
    NavMeshAgent agent;
    //[SerializeField]
    EnemyHealth enemyhealth;

    private CalculateVelocity calculateVelocity;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyhealth = GetComponent<EnemyHealth>();
        attackCoolDown = maxAttackCoolDown;

        animator = GetComponentInChildren<Animator>();
        calculateVelocity = GetComponent<CalculateVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", calculateVelocity.InverseVelocity.magnitude);
        timer += Time.deltaTime;
        //animator.SetFloat("VelocityZ", calculateVelocity.InverseVelocity.z, 0.05f, Time.deltaTime);
        //animator.SetFloat("VelocityX", calculateVelocity.InverseVelocity.x, 0.05f, Time.deltaTime);
        if (timer > 1)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 1.5)
            {
                agent.SetDestination(player.transform.position);
                timer = 0;
            }
            
        }
        if (attackCoolDown > 0)
        {
            attackCoolDown -= Time.deltaTime;
        }
        //if (enemyhealth.isDead) Death();
    }
    //public void Death()
    //{
    //    animator.SetTrigger("IsStopped");
    //    enabled = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && attackCoolDown <= 0)
        {
            attackCoolDown = maxAttackCoolDown;
            Debug.Log("Kutsuu");
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                animator.SetTrigger("Attacks");
                damageable.TakeDamage(damage);
            }
        }
    }
}
