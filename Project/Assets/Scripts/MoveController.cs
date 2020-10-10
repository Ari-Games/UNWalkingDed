using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    
    Rigidbody2D _rigidbody;
    bool _flag;
    Vector3 _from;
    Vector3 _to;
    [Header("Settings")]
    [SerializeField] ArrowDraw arrow;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] GameObject heroSprite;
    private void Start()
    {
        arrow.StopDraw();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_flag)
        {
            arrow.DrawArrow(transform.position, mousePos);
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            heroSprite.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
        if (Input.GetMouseButtonDown(0) && !_flag)
        {
            _flag = true;
            _from = mousePos;

        }
        else if (Input.GetMouseButtonUp(0))
        {
         
            _to = mousePos;
            _flag = false;

            Vector2 direction = _to - _from;
            _rigidbody.AddForce(-direction * 1000);
            arrow.StopDraw();
            FireByDirection(direction);
        }


    }

    private void FireByDirection(Vector2 direction)
    {
        var bulletInstance = Instantiate(bullet,transform.position,Quaternion.identity);
        //bulletInstance.transform.LookAt(direction);
        ///////////////////////////////
        //HACK:
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        bulletInstance.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        //////////////////////////////
        bulletInstance.AddForce(direction * 100);
        Destroy(bulletInstance.gameObject,0.5f );
        
    }
}
