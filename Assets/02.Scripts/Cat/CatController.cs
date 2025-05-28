using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D cat_rb;

    /// <summary> 점프력 </summary>
    public float jump_force = 7f;

    /// <summary> 점프 횟수 상수 ( 매크로 상수 처럼 동작하게끔 만듬 , C#은 매크로가 없냐 왜... ) </summary>
    public int jump_count = 2;

    /// <summary> 실제 로직에서 사용되는 int </summary>
    private int jump_count_real;

    /// <summary> 땅에 붙어있냐? </summary>
    public bool isGround = false;

    void Start()
    {
        this.cat_rb = this.GetComponent<Rigidbody2D>();
        this.jump_count_real = this.jump_count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count_real > 0)
        {
            // (점프 = y축 방향으로 이동) == false
            this.cat_rb.AddForceY(this.jump_force, ForceMode2D.Impulse);
            this.jump_count_real--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGround = true;

            // 점프 횟수 초기화
            this.jump_count_real = this.jump_count;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGround = false;
        }
    }
}
