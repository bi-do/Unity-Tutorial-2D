using Unity.Mathematics;
using UnityEngine;

public class MathCircle : MonoBehaviour
{
    public float theta , radius , speed;

    public float x, y;

    void Update()
    {
        this.theta += Time.deltaTime * speed;
        this.x = Mathf.Cos(theta);
        this.y = Mathf.Sin(theta);
        Vector2 pos = new Vector2(x, y) * radius;
        this.transform.position = pos;
    }

}
