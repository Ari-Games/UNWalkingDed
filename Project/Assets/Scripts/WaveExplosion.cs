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

}
