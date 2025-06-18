using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Monster : MonoBehaviour
{

    private SpriteRenderer monster_sprite_renderer;
    private Animator monster_animator;
    public SpawnManager spawn_manager;

    private string anim_trigger_hit = "Hit";
    private string anim_trigger_death = "Death";

    /// <summary> 움직이는 방향 조정 변수 </summary>
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
                StartCoroutine(this.Death());
                this.spawn_manager.OnDropCoin(this.transform.position);
            }
        }
    }

    protected float move_speed = 5f;
    private bool isMove = true;

    private Coroutine prev_coroutine = null;


    void Start()
    {
        this.Init_Component();
        this.Init_Childs();
    }

    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        this.Hit(1);
    }

    /// <summary> 몬스터를 상속받는 오브젝트 초기화 </summary>
    protected abstract void Init_Childs();

    /// <summary> 몬스터 클래스가 갖고 있는 컴포넌트 할당 </summary>
    private void Init_Component()
    {
        this.monster_sprite_renderer = this.GetComponent<SpriteRenderer>();
        this.monster_animator = this.GetComponent<Animator>();
        this.spawn_manager = FindFirstObjectByType<SpawnManager>();
    }

    private void Move()
    {
        if (!isMove)
            return;
        else
        {

            this.transform.position += Vector3.right * this.move_speed * Time.deltaTime * dir;

            if (this.transform.position.x < -9 || this.transform.position.x > 9)
            {
                this.dir *= -1;
                this.monster_sprite_renderer.flipX = !this.monster_sprite_renderer.flipX;
            }
        }
    }

    private void Hit(float param_damage)
    {
        // 연속 클릭 가능 로직
        // if (this.prev_coroutine != null)
        //     StopCoroutine(this.prev_coroutine);

        // 연속 공격 불가능 로직
        if (!this.isMove)
            return;
        else
        {
            this.isMove = false;
            this.monster_animator.SetTrigger(this.anim_trigger_hit);

            this.HP -= param_damage;
            if (this.HP > 0)
                this.prev_coroutine = StartCoroutine(this.Hit_Routine());
        }

    }

    IEnumerator Death()
    {
        this.monster_animator.SetTrigger(this.anim_trigger_death);

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }

    /// <summary> 몬스터 피격후 다시 이동 </summary>
    IEnumerator Hit_Routine()
    {
        yield return new WaitForSeconds(0.6f);
        this.isMove = true;
    }
}
