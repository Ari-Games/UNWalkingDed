using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BezierMover : MonoBehaviour
{
    

    Vector2 point2;


    Vector2 point3;


    public Transform point4;
    
    float lenOfOX = 0f;
    float lenOfOY =0f;
    float tParamSlider = 0f;
    // Start is called before the first frame update
   
    // Update is called once per frame

    private void Start() {
         lenOfOX =   (point4.position.x - transform.position.x);
         lenOfOY = (point4.position.y - transform.position.y);

        Mathf.Clamp01(tParamSlider);

        
    }

    private void Update()
    {
       if(Vector2.Distance(transform.position,point4.position) < 0.3f)
        {
            Destroy(gameObject);
            
        }
        CoinMover();
    }

    
    void CoinMover()
    {
        point2 = new Vector2(transform.position.x + lenOfOX * 0.25f,
            transform.position.y + lenOfOY * 0.25f);
        point3 = new Vector2(point2.x * 2, point2.y);
        tParamSlider += 0.1f;
        Vector2 dist = Bezier.GetPos(transform.position, point2, point3, point4.position, tParamSlider);
        transform.position = Vector2.Lerp(transform.position,dist,Time.deltaTime*1);
       // transform.rotation = Quaternion.LookRotation(Bezier.GetRot(transform.position, point2,
          //          point3, point4.position, tParamSlider));
    }

    // void FixedUpdate()
    // {
    //     transform.position = Bezier.GetPos(point1.position, point2.position, point3.position, point4.position, tParamSlider);
    //     transform.rotation = Quaternion.LookRotation(Bezier.GetRot(point1.position, point2.position, 
    //                 point3.position, point4.position, tParamSlider));
    // }

 
}
