using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knight_rb;

    [SerializeField] private Button jump_btn;
    [SerializeField] private Button atk_btn;

    [SerializeField] private float move_speed = 3f;
    [SerializeField] private float jump_power = 20f;

    float h, v;
    private Vector3 input_dir;

    bool isFalling = false;
    bool isCombo = false;
    bool isAttack = false;

    // private string anim_bool_isMove = "isRun";
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

        this.jump_btn.onClick.AddListener(this.Jump);
        this.atk_btn.onClick.AddListener(this.Attack);
    }

    void Update() // 일반적인 작업
    {

    }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
        Fall();
    }

    public void InputJoystick(float x, float y)
    {
        this.input_dir = new Vector3(x, y, 0).normalized;
        this.animator.SetFloat(anim_float_joystick_x, input_dir.x);
        this.animator.SetFloat(anim_float_joystick_y, input_dir.y);

        if (input_dir.x != 0)
        {
            float scale_x = this.input_dir.x > 0 ? 1 : -1;
            this.transform.localScale = new Vector3(scale_x, 1, 1);
        }
    }

    private void Jump()
    {
        this.animator.SetTrigger(this.anim_trigger_jump);
        this.knight_rb.AddForceY(this.jump_power, ForceMode2D.Impulse);
    }

    private void Attack()
    {
        if (!isCombo)
        {
            if (!isAttack)
            {
                this.isAttack = true;
                this.animator.SetTrigger(this.anim_trigger_atk);
            }
            else
                this.isCombo = true;
        }

    }

    private void Move()
    {
        if (input_dir.x > 0.45f || input_dir.x < -0.45f)
            this.knight_rb.linearVelocityX = this.input_dir.x * move_speed;
        else
            this.knight_rb.linearVelocityX = 0f;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.animator.SetBool(this.anim_bool_isFall, false);
            this.isFalling = false;
        }
    }

    private void CheckCombo()
    {
        Debug.Log("Check Combo");
        if (isCombo)
        {
            Debug.Log("Combo Attack Execute");
        }
        else
        {
            Debug.Log("Combo Attack Not Execute");
        }
        animator.SetBool(anim_bool_isCombo, isCombo);
        this.isAttack = false;
    }

    private void EndComboAttack()
    {
        this.isAttack = false;
        this.isCombo = false;
        animator.SetBool(anim_bool_isCombo, false);
    }
}
