using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knight_rb;

    [SerializeField] private float move_speed = 3f;

    float h, v;
    private Vector3 input_dir;

    private string anim_float_joystick_x = "JoystickX";
    private string anim_float_joystick_y = "JoystickY";

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.knight_rb = this.GetComponent<Rigidbody2D>();
    }

    // void Update() // 일반적인 작업
    // {

    // }

    private void FixedUpdate() // 물리적인 작업
    {
        Move();
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


    private void Move()
    {
        // if (input_dir.x > 0.45f || input_dir.x < -0.45f)
        this.knight_rb.linearVelocity = this.input_dir * move_speed;
        // else
        //     this.knight_rb.linearVelocityX = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
