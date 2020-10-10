using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] ParticleSystem exploseParticle;
    [SerializeField] ParticleSystem bloodSplash;
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;
        var expl = Instantiate(exploseParticle, collision.transform.position, Quaternion.identity);
        expl.GetComponent<ParticleSystem>().Play();
        if (collision.tag != "Zombie" && collision.tag != "FatZombie")
        {
            return;
        }
        var splash = Instantiate(bloodSplash.gameObject, collision.transform);
        splash.GetComponent<ParticleSystem>().Play();

        Debug.Log("EXPLOSE");
        Destroy(expl,1f);
        Destroy(splash, 0.5f);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
