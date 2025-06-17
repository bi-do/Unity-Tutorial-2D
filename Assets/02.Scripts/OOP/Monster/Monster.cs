using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private int dir = 1;

    [SerializeField]
    private float hp = 3f;

    protected float HP
    {
        get { return hp; }
        set
        {
            this.hp = value;
            if (this.hp <= 0)
            {
                Debug.Log($"{this.gameObject.name}이 죽었습니다.");
                Destroy(this.gameObject);
            }
        }
    }

    protected float move_speed = 5f;

    private SpriteRenderer sprite_renderer;

    protected abstract void Init();

    void Start()
    {
        this.sprite_renderer = this.GetComponent<SpriteRenderer>();
        this.Init();
    }

    void OnMouseDown()
    {
        this.Hit(1);
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position += Vector3.right * this.move_speed * Time.deltaTime * dir;

        if (this.transform.position.x < -9 || this.transform.position.x > 9)
        {
            this.dir *= -1;
            this.sprite_renderer.flipX = !this.sprite_renderer.flipX;
        }
    }

    protected void Hit(float param_damage)
    {
        this.HP -= param_damage;
    }
}
