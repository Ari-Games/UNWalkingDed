using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPos(Vector3 point1,Vector3 point2,Vector3 point3,Vector3 point4, float tParam)
    {
        tParam = Mathf.Clamp01(tParam);
        float oneMinus = 1.0f - tParam;
        return (float) Math.Pow(oneMinus,3) * point1 + 3f * (float) Math.Pow(oneMinus, 2) * tParam * point2 
            + 3f * oneMinus * (float)Math.Pow(tParam, 2) * point3 + (float)Math.Pow(tParam, 3)  * point4;
    }

    public static Vector3 GetRot(Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4, float tParam)
    {
        tParam = Mathf.Clamp01(tParam);
        float oneMinus = 1.0f - tParam;
        return 3f * oneMinus * oneMinus * (point2-point1) + 6f * oneMinus * tParam*(point3-point2)
            + 3f * tParam * tParam * (point4 - point3);
    }
}
