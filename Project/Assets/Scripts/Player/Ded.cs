using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ded : MonoBehaviour
{
    [SerializeField]
    private int health = 70;

    public int Health
    {
        get{return health;}
    }
   
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject.FindWithTag("Manager").GetComponent<GameManager>().TheEnd();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health < 0)
            health = 0;
        // Mathf.Clamp(health,health)
    }
}
