using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float move_speed = 3f;

    private Rigidbody2D car_rb;

    private float h;

    void Start()
    {
        this.car_rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        this.h = Input.GetAxis("Horizontal");

        // Trasnform 이동 ( 해당 좌표로 순간 이동 )
        // this.transform.position += Vector3.right *h* this.move_speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Rigidbody의 속도를 활용한 물리적인 이동 ( 해당 오브젝트의 속도를 변경 )
        this.car_rb.linearVelocityX = this.h * this.move_speed;
    }

    /// <summary> 충돌 시작 시 </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"충돌 시작. 충돌 대상 : {collision.gameObject.name}");
    }

    /// <summary> 충돌 중 </summary>
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"충돌 중. 충돌 대상 : {collision.gameObject.name}");
    }

    /// <summary> 충돌 종료 시 </summary>
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"충돌 종료. 충돌 대상 : {collision.gameObject.name}");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"트리거 충돌 시작. 충돌 대상 : {collision.gameObject.name}");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"트리거 충돌 중. 충돌 대상 : {collision.gameObject.name}");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"트리거 충돌 종료. 충돌 대상 : {collision.gameObject.name}");
    }


}
