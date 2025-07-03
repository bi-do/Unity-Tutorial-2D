using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState
    {
        IDLE,
        PATROL,
        TRACE,
        ATTACK,
        HIT,
        DEATH
    }
    public MonsterState monster_state;

    public ItemManager item_manager;

    protected Rigidbody2D monster_rb;
    protected Animator animator;
    protected Collider2D monster_coll;
    [SerializeField] protected Image hp_bar_UI;

    protected Transform target_tf;

    // Init에서 초기화 바람
    public float max_hp;
    public float cur_hp;
    public float speed;
    public float atk_dmg;
    public float attack_time;

    /// <summary> 몬스터가 바라보는 방향 </summary>
    protected float dir_x = 1f;

    /// <summary> 타겟 ( 플레이어 ) 와 자신의 거리 </summary>
    public float target_dist;

    [SerializeField] protected bool isTrace = false;
    protected bool isAttack = false;
    protected bool isDead = false;

    /// <summary> 초기화 ( MonsterCore의 Start에서 호출하니, 추가 기능은 재정의로 넣으면 됨. ) </summary>
    protected virtual void Init()
    {
        this.item_manager = FindFirstObjectByType<ItemManager>();

        this.target_tf = FindFirstObjectByType<KnightController_Keyboard>().transform;

        this.monster_rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.monster_coll = this.GetComponent<Collider2D>();

        this.cur_hp = this.max_hp;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (isDead)
            return;

        this.target_dist = Vector3.Distance(this.transform.position, this.target_tf.position);
        switch (this.monster_state)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                TRACE();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void TRACE();
    public abstract void Attack();

    /// <summary> 상태 설정 함수 </summary>
    protected void ChangeState(MonsterState param_state)
    {
        if (param_state != this.monster_state)
            this.monster_state = param_state;
        return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            this.dir_x *= -1f;
            this.transform.localScale = new Vector3(this.dir_x, 1, 1);
        }
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(this.atk_dmg);
        }
    }

    public void TakeDamage(float param_damage)
    {
        cur_hp -= param_damage;

        this.animator.SetTrigger("Hit");
        this.hp_bar_UI.fillAmount = cur_hp / max_hp;
        if (cur_hp <= 0f)
        {
            Death();
        }

    }

    public void Death()
    {
        this.animator.SetTrigger("Death");
        this.monster_coll.enabled = false;
        this.monster_rb.gravityScale = 0f;
        this.monster_rb.linearVelocityX = 0f;

        this.isDead = true;

        int item_count = Random.Range(0, 3);
        if (item_count > 0)
        {
            for (int i = 0; i < item_count; i++)
            {
                this.item_manager.OnDropItem(this.transform.position);
            }
        }

    }
}
