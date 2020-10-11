﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveExplosion : MonoBehaviour
{
    [SerializeField] private float timeExplosion;
    [SerializeField] private GameObject coin = null;

    public void Start()
    {
        transform.localScale = new Vector3(3, 3, 1);
        Destroy(transform.parent.gameObject, timeExplosion);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "FatZombie")
        {
            collision.gameObject.GetComponentInChildren<Animator>().SetTrigger("kill");
            collision.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            if(collision.gameObject.tag == "Zombie")
            {
                collision.gameObject.GetComponent<Flocking.Flock>().enabled = false;
            }
            Destroy(collision.gameObject,4f);
            if(Random.Range(1,4)==1)
                Instantiate(coin,transform.position,Quaternion.identity);
        } 
    }

}
