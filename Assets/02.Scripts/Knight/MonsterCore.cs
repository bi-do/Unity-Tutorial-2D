using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    protected Rigidbody2D monster_rb;
    protected Animator animator;
    protected Collider2D monster_coll;

    public Transform target_tf;

    public enum MonsterState
    {
        IDLE,
        PATROL,
        TRACE,
        ATTACK
    }
    public MonsterState monster_state;

    public float hp;
    public float speed;
    public float attack_time;

    /// <summary> 몬스터가 바라보는 방향 </summary>
    protected float dir_x = 1f;

    /// <summary> 타겟 ( 플레이어 ) 와 자신의 거리 </summary>
    public float target_dist;

    protected bool isTrace = false;
    protected bool isAttack = false;

    protected virtual void Init()
    {
        this.target_tf = FindFirstObjectByType<KnightController_Keyboard>().transform;

        this.monster_rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.monster_coll = this.GetComponent<Collider2D>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
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
    }



}
