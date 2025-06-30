using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D platform_rb;

    public float theta;
    public float range = 3f;
    public float speed = 1f;

    private Vector3 init_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.init_pos = this.transform.position;
        this.platform_rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * speed;
        // transform.position = new Vector3(this.init_pos.x + range * Mathf.Sin(this.theta), init_pos.y, init_pos.z);
        this.platform_rb.linearVelocityX = range * Mathf.Sin(this.theta);
    }

}
