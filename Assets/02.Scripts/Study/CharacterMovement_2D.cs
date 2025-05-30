using Unity.Collections;
using UnityEngine;

public class CharacterMovement_2D : MonoBehaviour
{
    public float move_speed = 3f;

    public float jump_force = 5f;

    public SpriteRenderer[] childs;

    private float h = 0;

    private Rigidbody2D char_rb;

    private bool isGround = false;

    void Start()
    {
        this.char_rb = this.GetComponent<Rigidbody2D>();

        this.childs = this.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        this.h = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary> 입력값에 따라 캐릭터 속도 및 애니메이션 렌더링이 달라지는 기능 </summary>
    private void Move()
    {
        if (!this.isGround)
        {
            return;
        }
        else if (this.h == 0)         // 움직이지 않을 때
        {
            // Idle
            this.childs[0].enabled = true;
            this.childs[1].enabled = false;
        }
        else // 움직일 떄
        {
            foreach (SpriteRenderer element in this.childs)
            {
                element.flipX = this.h > 0 ? false : true;
            }

            // Run
            this.childs[0].enabled = false;
            this.childs[1].enabled = true;
        }

        char_rb.linearVelocityX = this.move_speed * this.h;
    }

    /// <summary> 점프 </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && this.isGround)
        {
            this.char_rb.AddForceY(this.jump_force, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 땅에 닿으면 속도에 따른 모션 활성화
        {
            this.isGround = true;
            this.childs[2].enabled = false;

            // fixed update에서 렌더링 여부를 결정하기때문인지는 모르겠으나, 
            // 밑의 코드가 없으면 1프레임 정도 스프라이트가 비는 타이밍이 생겨버림
            // 렌더러 활성화를 모아서 update마다 확인하는 함수를 따로만들면 되겠지만 update마다 호출하는게 과연 좋을까 싶음.
            int index = this.char_rb.linearVelocityX == 0 ? 0 : 1;
            this.childs[index].enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 땅에서 벗어나면 점프 모션 활성화
        {
            this.childs[0].enabled = false;
            this.childs[1].enabled = false;
            this.childs[2].enabled = true;
            this.isGround = false;
        }
    }

}
