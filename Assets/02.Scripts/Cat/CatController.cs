using Cat;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public SoundManager sound_manager; // 사운드 매니저

    private Rigidbody2D cat_rb;
    private Animator cat_ani;

    /// <summary> 점프력 </summary>
    public float jump_force = 7f;

    /// <summary> 점프 횟수 상수 ( 매크로 상수 처럼 동작하게끔 만듬 , C#은 매크로가 없냐 왜... ) </summary>
    public int jump_count = 2;

    /// <summary> 실제 로직에서 사용되는 int </summary>
    private int jump_count_real;

    /// <summary> 땅에 붙어있냐? </summary>
    private bool isGround = false;

    void Start()
    {
        this.cat_rb = this.GetComponent<Rigidbody2D>();
        this.cat_ani = this.GetComponent<Animator>();
        this.jump_count_real = this.jump_count;
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count_real > 0)
        {
            // (점프 = y축 방향으로 이동) == false
            this.cat_rb.AddForceY(this.jump_force, ForceMode2D.Impulse);
            this.cat_ani.SetBool("isGround", false);

            // 애니메이션 실행
            this.cat_ani.SetTrigger("Jump");

            // 점프 카운트 감소
            this.jump_count_real--;

            // 사운드 재생
            this.sound_manager.OnJumpSound();


        }
        this.Jump_Rotate();
    }

    private void Jump_Rotate()
    {
        var catRotation = this.transform.eulerAngles;
        catRotation.z = this.cat_rb.linearVelocityY * 3f;
        this.transform.eulerAngles = catRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGround = true;

            // 걷는 모션 재 실해
            this.cat_ani.SetBool("isGround", true);

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
