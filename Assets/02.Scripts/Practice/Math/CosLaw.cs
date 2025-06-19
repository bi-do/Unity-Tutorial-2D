using System;
using Unity.Mathematics;
using UnityEngine;

public class CosLaw : MonoBehaviour
{
    public float c_angle = 60f;
    public float a_side = 1;
    public float b_side = 1;

    void Start()
    {
        float c_rad = this.c_angle * Mathf.Deg2Rad;
        float c_side = MathF.Sqrt(Mathf.Pow(a_side, 2) + Mathf.Pow(b_side, 2) - 2 * a_side * b_side * Mathf.Cos(c_rad));
        Debug.Log(c_side);
    }
}
