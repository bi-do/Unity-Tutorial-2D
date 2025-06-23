using UnityEngine;

public class MathCross : MonoBehaviour
{
    public Vector3 vec_a = new Vector3(1, 0, 0);
    public Vector3 vec_b = new Vector3(0, 1, 0);

    void Start()
    {
        Vector3 result = Vector3.Cross(vec_a, vec_b);
        Debug.Log($"벡터의 외적 : {result}");


        Vector3 result2 = Vector3.Reflect(vec_a, vec_b);
    }
}
