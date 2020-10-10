using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExpl : MonoBehaviour
{
    // Rigidbody2D rigidbody = null;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,5f);
        foreach(var hit in colliders)
        {
            print(hit.name);
            var rb = hit.GetComponent<Rigidbody2D>();
            if(rb && rb != gameObject)
            {
                print(gameObject.name);
                rb.AddExplosionForce(5f,transform.position,5f);
            }
        }
        
    }


}
