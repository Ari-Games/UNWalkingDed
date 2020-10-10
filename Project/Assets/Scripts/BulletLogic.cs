using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] ParticleSystem exploseParticle;
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Zombie" && collision.tag != "FatZombie")
        {
            return;
        }
        var expl = Instantiate(exploseParticle.gameObject, collision.transform);
        expl.GetComponent<ParticleSystem>().Play();
        Debug.Log("EXPLOSE");
        Destroy(expl, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
