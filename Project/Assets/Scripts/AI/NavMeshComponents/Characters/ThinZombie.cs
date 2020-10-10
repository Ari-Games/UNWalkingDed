using UnityEngine;

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
            //TODO 
            //Play Animation
            //target.GetComponent<somth>().makeDamage;
            print("Hit");
        }
    }

    void Dead()
    {
        //TODO 
        //Particle effect of Blood
        zombieInst.SetTrigger("kill");
        Destroy(gameObject, 5f);
    }
    
}   