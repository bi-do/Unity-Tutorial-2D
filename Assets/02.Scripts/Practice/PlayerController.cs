using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite_renderer;

    [SerializeField]
    private GameObject hit_box;

    [SerializeField]
    float move_speed = 3f;

    private bool isAttack = false;

    float h, v;

    private string anim_bool_isRun = "isRun";


    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.sprite_renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        this.h = Input.GetAxisRaw("Horizontal");
        this.v = Input.GetAxisRaw("Vertical");


        if (h != 0 || v != 0) // Run
        {
            if (h < 0)
                this.transform.localScale = new Vector3(-1, 1, 1);
            else if (h > 0)
                this.transform.localScale = new Vector3(1, 1, 1);


            this.animator.SetBool(this.anim_bool_isRun, true);
        }
        else // Idle
        {
            this.animator.SetBool(this.anim_bool_isRun, false);
        }

        this.transform.position += new Vector3(h, v).normalized * this.move_speed * Time.deltaTime;
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !this.isAttack)
        {
            StartCoroutine(this.Attack_Routine());
        }
    }

    IEnumerator Attack_Routine()
    {
        this.isAttack = true;
        this.hit_box.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        this.hit_box.SetActive(false);

         yield return new WaitForSeconds(0.5f);
        this.isAttack = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IItem>() != null)
        {
            collision.gameObject.GetComponent<IItem>().Get();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Monster>() != null)
        {
            Monster monster = collision.GetComponent<Monster>();
            monster.OnHit(1);
        }
    }
}
