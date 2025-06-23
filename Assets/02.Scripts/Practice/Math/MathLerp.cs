using System.Threading;
using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 target_pos;
    public float smooth_value = 0.1f;
    private Vector3 start_pos;
    private float timer , percent , lerpTime;

    void Start()
    {
        this.start_pos = this.transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime ;

        percent = timer / lerpTime; // lerpTime이 1 일시 percent는 1초에 100%가 됨

        this.transform.position = Vector3.Lerp(this.start_pos, this.target_pos, percent);
    }
}
