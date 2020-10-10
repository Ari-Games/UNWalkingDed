using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMover : MonoBehaviour
{

    GameObject target = null;

   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if(hasHit && hit.collider.tag ==  "Point")
            {
                target = hit.collider.gameObject;
                target.transform.position = new Vector3(hit.collider.transform.position.x, hit.point.y, hit.point.z);
            }
        }
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
