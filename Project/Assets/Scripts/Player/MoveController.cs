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
    Animator _animation;
    [Header("Settings")]
    [SerializeField] ArrowDraw arrow;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] GameObject heroSprite;
    [SerializeField] Transform aim;
    [SerializeField] private AudioSource explSound;
    private void Start()
    {
        _animation = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (_flag)
        {
            arrow.DrawArrow(transform.position, mousePos);
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            heroSprite.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            aim.position = mousePos;
        }
        if (Input.GetMouseButtonDown(0) && !_flag)
        {
            _flag = true;
            _from = mousePos;
            aim.gameObject.SetActive(true);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _animation.SetTrigger("shoot");
            _to = mousePos;
            _flag = false;
            aim.gameObject.SetActive(false);
            Vector2 direction = _to - _from;
            _rigidbody.AddForce(-direction * 1000);
            FireByDirection(direction);
        }
    }

    private void FireByDirection(Vector2 direction)
    {
        var bulletInstance = Instantiate(bullet,transform.position,Quaternion.identity);
        StartCoroutine(PlaySwist());
        //bulletInstance.transform.LookAt(direction);
        ///////////////////////////////
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        bulletInstance.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        //////////////////////////////
        bulletInstance.AddForce(direction * 100);
        Destroy(bulletInstance.gameObject, 0.5f );
        
    }

    IEnumerator PlaySwist()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        if (!explSound.isPlaying)
            explSound.Play();
    }
}
