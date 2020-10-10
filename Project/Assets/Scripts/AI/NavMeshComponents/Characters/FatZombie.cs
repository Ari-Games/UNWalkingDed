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

    public float health = 25f;
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
        agent.SetDestination(target.position);
        if(health <= 0)
        {
            ExplosionDead();
        }
        else if(Vector2.Distance(transform.position, target.position) < 1f)
        {
            ExplosionDead();
        }
    }
    
    void ExplosionDead()
    {
        //TODO
        //Call Particle effect and hit player if in area
        if(Vector2.Distance(transform.position, target.position) <2f)
            target.GetComponent<Ded>().TakeDamage(3);
        Destroy(gameObject, timeToExplosion);
        agent.isStopped = true;
    }
}


