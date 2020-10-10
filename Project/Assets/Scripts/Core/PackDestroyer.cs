using UnityEngine;
using System.Collections.Generic;
public class PackDestroyer : MonoBehaviour {

    List<Transform> listOfChild = new List<Transform>();
    private void Start() {
        // Invoke("DeleteChild", 5f);
        Destroy(gameObject,0.3f);
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

}