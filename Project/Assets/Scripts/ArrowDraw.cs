using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArrowDraw : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void DrawArrow(Vector3 from,Vector3 to)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPositions(new Vector3[] { from, to});
    }
    public void StopDraw()
    {
        lineRenderer.enabled = false;
    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    
}
