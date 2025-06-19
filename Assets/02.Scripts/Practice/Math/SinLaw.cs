using UnityEngine;

public class SinLaw : MonoBehaviour
{
    public float a_angle = 30f;
    public float b_angle = 90f;
    public float aSide = 1f;

    void Start()
    {
        float aRad = this.a_angle * Mathf.Deg2Rad;
        float bRad = this.b_angle * Mathf.Deg2Rad;

        float bSide = (aSide * Mathf.Sin(bRad)) / Mathf.Sin(aRad);

        Debug.Log(bSide);
    }

}
