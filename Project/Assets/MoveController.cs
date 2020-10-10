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
        

    }
    
    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_flag)
        {
            arrow.DrawArrow(transform.position, mousePos);
        }
        if (Input.GetMouseButtonDown(0) && !_flag)
        {
            Debug.Log("DOWN " + _flag);
            _flag = true;
            _from = mousePos;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("UP " + _flag);
            _to = mousePos;
            _flag = false;

            Vector2 direction = _to - _from;
            Debug.Log(direction);
            _rigidbody.AddForce(-direction * 1000);
            arrow.StopDraw();
        }


    }

}
