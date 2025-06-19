using UnityEngine;

public class MathVector : MonoBehaviour
{
    public Vector3 vec_a = new Vector3(3, 0, 0);
    public Vector3 vec_b = new Vector3(0, 4, 0);

    void Start()
    {
        float size = Vector3.Magnitude(this.vec_a + this.vec_b);
        Debug.Log($"Magnitude :  {size}");

        float distance = Vector3.Distance(this.vec_b, this.vec_b);
        Debug.Log($"Distace : {distance}");

        float s_size = Vector3.SqrMagnitude(this.vec_a + this.vec_b);
        Debug.Log($"Magnitude :  {s_size}");

    }
}
