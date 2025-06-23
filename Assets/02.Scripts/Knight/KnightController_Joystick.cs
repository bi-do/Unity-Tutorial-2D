using UnityEngine;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knight_rb;

    private Vector3 input_dir;
    [SerializeField]
    private float move_speed = 3f;
    private float jump_power = 20f;

    float h, v;
    bool isFalling = false;

    private string anim_bool_isMove = "isRun";
    private string anim_trigger_jump = "Jump";
    private string anim_bool_isfall = "isFall";

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

        Jump();
        SetMoveSprite();
    }

    private void SetMoveSprite()
    {
        if (h != 0)
        {
            this.animator.SetBool(this.anim_bool_isMove, true);

            float scale_x = this.input_dir.x > 0 ? 1 : -1;
            this.transform.localScale = new Vector3(scale_x, 1, 1);
        }
        else
        {
            this.animator.SetBool(this.anim_bool_isMove, false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            this.animator.SetTrigger(this.anim_trigger_jump);
            this.knight_rb.AddForceY(this.jump_power, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        if (input_dir.x != 0)
            this.knight_rb.linearVelocityX = this.input_dir.x * move_speed;
    }

    private void Fall()
    {
        if (isFalling)
            return;
        else if (this.knight_rb.linearVelocityY < 0)
        {
            this.animator.SetBool(this.anim_bool_isfall, true);
            isFalling = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.animator.SetBool(this.anim_bool_isfall, false);
            this.isFalling = false;
        }
    }
}
