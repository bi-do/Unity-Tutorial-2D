using UnityEngine;

public class MathDot : MonoBehaviour
{
    public Vector3 vec_a = new Vector3(1, 0, 0);
    public Vector3 vec_b = new Vector3(1, 1, 0);

    void Start()
    {
        float result = Vector3.Angle(vec_a, vec_b);

        Debug.Log($"벡터의 내적 각도 : {result}");
    }
}
