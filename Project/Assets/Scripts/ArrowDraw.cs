using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DottedLine;


public class ArrowDraw : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void DrawArrow(Vector3 from,Vector3 to)
    {
        DottedLine.DottedLine.Instance.DrawDottedLine(from, to);
    }
   
}
