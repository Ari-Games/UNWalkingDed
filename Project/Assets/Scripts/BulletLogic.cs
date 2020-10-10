using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] ParticleSystem exploseParticle;
    [SerializeField] ParticleSystem bloodSplash;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;
        var expl = Instantiate(exploseParticle, collision.transform.position, Quaternion.identity);
        expl.GetComponent<ParticleSystem>().Play();
        Destroy(expl, 1f);
        if (!collision.CompareTag("Zombie") && !collision.CompareTag("FatZombie"))
        {
            return;
        }
        var splash = Instantiate(bloodSplash.gameObject, collision.transform);
        splash.GetComponent<ParticleSystem>().Play();

        Debug.Log("EXPLOSE");
        Destroy(splash, 0.5f);
        Destroy(this.gameObject);
    }

    private void OnDestroy() {
        var expl = Instantiate(exploseParticle, transform.position, Quaternion.identity);
        expl.GetComponent<ParticleSystem>().Play();
        Destroy(expl, 1f);
    }
  
}
