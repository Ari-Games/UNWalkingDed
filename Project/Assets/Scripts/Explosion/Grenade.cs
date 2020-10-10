using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Vector2 explosionPoint = Vector2.zero;
    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);
        if((collider && collider != gameObject) || Vector2.Distance(transform.position, explosionPoint) < 1f)
        {
            Explose();
        }
        
    }

    private void Explose()
    {
        //TODO 
        //Effects
        print("!!!");
        ForceOnArea();
        Destroy(gameObject, 2f);
    }

    private void ForceOnArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (var hit in colliders)
        {
            var rb = hit.GetComponent<Rigidbody2D>();
            if (rb && rb != gameObject)
            {
                rb.AddExplosionForce(10f, transform.position, 5f);
            }
        }
    }
}
