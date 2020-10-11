using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatZombie : MonoBehaviour
{
    
    [SerializeField]
    Transform target = null;

    NavMeshAgent agent = null;

    [SerializeField]
    float timeToExplosion = 1f;

    [SerializeField]
    Animator zombieInst;

    public float health = 25f;

    bool isAttacked = false;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            target = GameObject.FindWithTag("Player").transform;
            
        agent = GetComponent<NavMeshAgent>();
        if (agent)
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
            agent.SetDestination(target.position);
        if(health <= 0 && !isAttacked)
        {
            StartCoroutine(ExplosionDead());
        }
        else if(Vector2.Distance(transform.position, target.position) < 1f && !isAttacked)
        {
            StartCoroutine(ExplosionDead());
        }
    }

    IEnumerator ExplosionDead()
    {
        isAttacked = true;
        if (Vector2.Distance(transform.position, target.position) < 2f)
            target.GetComponent<Ded>().TakeDamage(35);
        Destroy(gameObject, timeToExplosion);
        agent.isStopped = true;
        zombieInst.SetTrigger("kill");
        yield return new WaitForSeconds(1f);
        isAttacked = false;
    }
}


