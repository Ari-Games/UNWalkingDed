using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BezierMover : MonoBehaviour
{ 
    Vector2 point2;

    Vector2 point3;

    [SerializeField]
    Transform point4 = null;
    
    float lenOfOX = 0f;
    float lenOfOY =0f;
    float tParamSlider = 0f;
   
    GameManager gameManager = null;

    private void Start()
    {
        point4 = GameObject.FindWithTag("Player").transform;
        lenOfOX =   (point4.position.x - transform.position.x);
        lenOfOY = (point4.position.y - transform.position.y);
        gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        Mathf.Clamp01(tParamSlider);
    }

    private void Update()
    {
       if(Vector2.Distance(transform.position,point4.position) < 0.5f)
        {
            Destroy(gameObject);
            if(gameManager)
                gameManager.IncCountOfCount();

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
        transform.position = Vector2.Lerp(transform.position,dist,Time.deltaTime*2.5f);
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
