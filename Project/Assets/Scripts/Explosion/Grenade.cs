using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Rigidbody2D rigidbody = null;
    public Vector2 target = Vector2.zero;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        // Collider2D collider = Physics2D.OverlapCircle(transform.position, 5f);
        // if(collider && collider.gameObject != gameObject || Vector2.Distance(transform.position, target) < 0.5f)
        // {
        //     Explosion();
        //     Destroy(gameObject,2f);
        // }
        Explosion();
    }

    private void Explosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (var hit in colliders)
        {
            print(hit.name);
            var rb = hit.GetComponent<Rigidbody2D>();
            if (rb && rb.gameObject != gameObject)
            {
                rb.AddExplosionForce(300f, transform.position, 10f);
            }
        }
    }
}
