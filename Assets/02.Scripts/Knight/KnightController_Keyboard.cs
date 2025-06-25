using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knight_rb;

    private Vector3 input_dir;
    [SerializeField]
    private float move_speed = 3f;
    private float jump_power = 20f;

    float h, v;

    private float atk_dmg = 3f;

    bool isFalling = false;
    bool isCombo = false;
    bool isAttack = false;
    bool isGround = false;

    private string anim_trigger_jump = "Jump";
    private string anim_trigger_atk = "Attack";

    private string anim_bool_isFall = "isFall";
    private string anim_bool_isCombo = "isCombo";

    private string anim_float_joystick_x = "JoystickX";
    private string anim_float_joystick_y = "JoystickY";

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.knight_rb = this.GetComponent<Rigidbody2D>();
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();

    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
        Fall();
    }

    void InputKeyboard()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        this.input_dir = new Vector3(h, v, 0);


        this.animator.SetFloat(this.anim_float_joystick_x, input_dir.x);
        this.animator.SetFloat(this.anim_float_joystick_y, input_dir.y);
        Jump();
        Attack();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !isAttack)
        {
            isGround = false;
            this.animator.SetTrigger(this.anim_trigger_jump);
            this.knight_rb.AddForceY(this.jump_power, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        if (input_dir.x != 0 && !isAttack)
        {
            this.knight_rb.linearVelocityX = this.input_dir.x * move_speed;
            float scale_x = this.input_dir.x > 0 ? 1 : -1;
            this.transform.localScale = new Vector3(scale_x, 1, 1);
        }

    }

    private void Fall()
    {
        if (isFalling)
            return;
        else if (this.knight_rb.linearVelocityY < 0)
        {
            this.animator.SetBool(this.anim_bool_isFall, true);
            isFalling = true;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) &&isGround)
        {
            if (!isCombo)
            {
                if (!isAttack)
                {
                    this.atk_dmg = 3f;
                    this.isAttack = true;
                    this.animator.SetTrigger(this.anim_trigger_atk);
                }
                else
                    this.isCombo = true;
            }
            else
            {
                Debug.Log("콤보 공격 시전 중엔 공격 입력이 불가능합니다.");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.animator.SetBool(this.anim_bool_isFall, false);
            this.isFalling = false;
            this.isGround = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{this.atk_dmg} 데미지로 공격");
        }
        Debug.Log("공격 판정");
    }

    // 기본 공격 애니메이션 이벤트 콜백 ( 콤보 공격 사용 여부 체크 )
    private void CheckCombo()
    {
        Debug.Log("Check Combo");
        if (isCombo)
        {
            this.atk_dmg = 5f;
            // Debug.Log("콤보 공격 시전");
        }
        else
        {
            // Debug.Log("콤보 공격 시전 안함");
        }
        animator.SetBool(anim_bool_isCombo, isCombo);

    }

    //  콤보 공격 애니메이션 이벤트 콜백 ( 콤보 공격 종료 시에 공격 관련 변수 초기화 )
    private void EndComboAttack()
    {
        this.isAttack = false;
        this.isCombo = false;
        animator.SetBool(anim_bool_isCombo, false);
    }

}
