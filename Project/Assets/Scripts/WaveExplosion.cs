using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveExplosion : MonoBehaviour
{
    [SerializeField] private float timeExplosion;
    public void Start()
    {
        transform.localScale = new Vector3(3, 3, 1);
        Destroy(transform.parent.gameObject, timeExplosion);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "FatZombie")
            Destroy(collision.gameObject);
    }

}
