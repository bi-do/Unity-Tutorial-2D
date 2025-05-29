using UnityEngine;
using UnityEngine.UI;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D left_bar_rb;
    public Rigidbody2D right_bar_rb;

    public float torque_up = 40f;
    public float torque_down = 30f;

    private int total_score = 0;

    public Text score_text;

    void Start()
    {
        this.left_bar_rb.gravityScale = 0;
        this.right_bar_rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            this.left_bar_rb.AddTorque(this.torque_up);
        }
        else
        {
            this.left_bar_rb.AddTorque(-this.torque_down);
        }

        if (Input.GetKey(KeyCode.X))
        {
            this.right_bar_rb.AddTorque(-this.torque_up);
        }
        else
        {
            this.right_bar_rb.AddTorque(this.torque_down);
        }
    }

    public void Add_Score(int param)
    {
        this.total_score += param;
        this.score_text.text = this.total_score.ToString();
    }

    public void Init_Score()
    {
        this.total_score = 0;
        this.score_text.text = this.total_score.ToString();
    }

    public int Get_Score()
    {
        return this.total_score;
    }
}
