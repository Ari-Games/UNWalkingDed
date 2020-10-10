using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField]
    int overweight = 100;


    [SerializeField]
    int normalWeight = 10;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().mass = overweight;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().mass = normalWeight;
        }
    }
}
