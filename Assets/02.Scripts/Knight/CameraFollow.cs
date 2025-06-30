using Unity.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset = new Vector3(0, 5, 0);
    [SerializeField] private float smooth_speed = 3f;

    Vector2 minBound = new Vector2(-8.9f, -9.9f);
    Vector2 maxBound = new Vector2(41f, 33.5f);

    void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 destination = target.position + offset;
        Vector3 smooth_pos = Vector3.Lerp(this.transform.position, destination, Time.deltaTime * smooth_speed);

        smooth_pos.x = Mathf.Clamp(smooth_pos.x, minBound.x, maxBound.x);
        smooth_pos.y = Mathf.Clamp(smooth_pos.y, minBound.y, maxBound.y);

        this.transform.position = smooth_pos;
    }
}
