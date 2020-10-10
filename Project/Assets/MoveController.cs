using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    
    Rigidbody2D _rigidbody;
    bool _flag;
    Vector3 _from;
    Vector3 _to;
    [SerializeField] ArrowDraw arrow;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_flag)
        {
            arrow.DrawArrow(transform.position, mousePos);
        }
        if (Input.GetMouseButtonDown(0))
        {            
            _flag = true;
            _from = mousePos;
            //Debug.Log(direction);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _to = mousePos;
            _flag = false;
            Vector2 direction = _to - _from;
            Debug.Log(direction);
            _rigidbody.AddForce(-direction * 1000);
            arrow.StopDraw();
        }
        
       

    }
    private void OnMouseDown()
    {
        _from = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(_from);
    }
    private void OnMouseUp()
    {
        _to = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //arrow.DrawArrow(transform.position, (_to - _from) + transform.position);
        Vector2 direction = _to -  _from;
        Debug.Log(direction);
        _rigidbody.AddForce(-direction * 1000);
    }
    private void Update()
    {
            
    }
    
}
