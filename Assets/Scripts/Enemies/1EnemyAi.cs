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
    EnemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        attackCoolDown = maxAttackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Velocity", agent.velocity.magnitude);
        timer += Time.deltaTime;
        if(timer > 1)
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
        if (health.isDead) Death();
    }
    public void Death()
    {
        //agent.IsStopped = true;
        enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && attackCoolDown <= 0)
        {
            attackCoolDown = maxAttackCoolDown;
            Debug.Log("Kutsuu");
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
