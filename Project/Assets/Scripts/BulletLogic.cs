using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] ParticleSystem exploseParticle;
    [SerializeField] ParticleSystem bloodSplash;
    [SerializeField] private AudioClip explosionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet")
            return;
        var expl = Instantiate(exploseParticle, collision.transform.position, Quaternion.identity);
        expl.GetComponent<ParticleSystem>().Play();
        Destroy(expl, 1f);
        if (collision.tag != "Zombie" && collision.tag != "FatZombie")
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
        GetComponent<AudioSource>().PlayOneShot(explosionSound);
        Destroy(expl, 1f);
    }
  
}
