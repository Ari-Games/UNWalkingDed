using UnityEngine;
using UnityEngine.AI;

public class ThinZombie : MonoBehaviour 
{
    public float health = 50f;

    [SerializeField]
    Transform target = null;

    [SerializeField]
    float distanceToHit = 1f;

    [SerializeField]
    Animator zombieInst;

    private void Start() {

        if(target == null)
            target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        if(Vector2.Distance(transform.position,target.position) < distanceToHit)
        {
            
            target.GetComponent<Ded>().TakeDamage(3);
            print("Hit");
        }
    }

    void Dead()
    {
        //TODO 
        //Particle effect of Blood
        zombieInst.SetTrigger("kill");
        Destroy(GetComponent<NavMeshAgent>());// = true;
        GetComponent<Flocking.Flock>().enabled = false;
        Debug.Log("AAAAAAAAAAAAA");
        Destroy(gameObject, 5f);
       
       
    }
    
}   