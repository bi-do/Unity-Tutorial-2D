using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    private float idle_time, patrol_time;

    // private float percent;
    // private Vector3 start_pos, end_pos;

    private string anim_bool_isRun = "isRun";
    private string anim_trigger_isAttack = "Attack";

    private float trace_dist = 5f;
    private float attack_dist = 1.5f;

    protected override void Init()
    {
        base.Init();
        this.hp = 10f;
        this.speed = 3f;
        this.attack_time = 2f;
    }

    public override void Idle()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.idle_time)
        {
            this.timer = 0f;
            SetRandomDir();
            this.patrol_time = Random.Range(1f, 5f);

            this.animator.SetBool(this.anim_bool_isRun, true);

            this.monster_state = MonsterState.PATROL;

            // pos 기반 이동 ( Lerp )
            // this.start_pos = this.transform.position;
            // this.end_pos = this.start_pos + Vector3.right * this.dir_x * this.patrol_time;
        }
        CheckEnemy();
        Debug.Log("Idle");
    }

    public override void Patrol()
    {
        // 물리 기반 이동
        this.monster_rb.linearVelocityX = this.dir_x * this.speed;

        this.timer += Time.deltaTime;

        // pos 기반 이동
        // this.percent =this.timer / this.patrol_time;
        // this.transform.position = Vector3.Lerp(this.start_pos, this.end_pos, percent);

        if (this.timer >= this.patrol_time)
        {
            // 물리 기반 제동
            this.monster_rb.linearVelocityX = 0f;

            this.timer = 0f;

            this.idle_time = Random.Range(1f, 5f);

            this.animator.SetBool(this.anim_bool_isRun, false);
            this.monster_state = MonsterState.IDLE;
        }
        CheckEnemy();
        Debug.Log("Patrol");
    }

    public override void TRACE()
    {
        // 몬스터 기준에서 플레이어가 존재하는 방향
        this.dir_x = (this.target_tf.position - this.transform.position).normalized.x;

        if (this.dir_x < 0)
        {
            this.dir_x = Mathf.FloorToInt(dir_x);

        }
        else
            this.dir_x = Mathf.CeilToInt(dir_x);

        this.monster_rb.linearVelocityX = this.dir_x * this.speed;

        this.transform.localScale = new Vector3(this.dir_x, 1, 1);

        if (this.target_dist > this.trace_dist) // 몬스터의 추격 범위에서 플레이어가 벗어났을 시
        {
            this.animator.SetBool(this.anim_bool_isRun, false);
            ChangeState(MonsterState.IDLE);
        }

        if (this.target_dist < attack_dist) // 플레이어가 몬스터의 공격 범위 내에 있을 시
        {
            ChangeState(MonsterState.ATTACK);
            Debug.Log("공격 범위 내");
        }
    }

    public override void Attack()
    {
        if (!this.isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        this.isAttack = true;
        animator.SetTrigger(this.anim_trigger_isAttack);

        // 공격 시전 시간 ( 애니메이션 이벤트로 바꿀 필요 있음 , 동기화 필요 )
        yield return new WaitForSeconds(1f); 

        this.isAttack = false;
        this.timer = 0f;

        this.animator.SetBool(this.anim_bool_isRun, false);
        ChangeState(MonsterState.IDLE);
    }

    /// <summary> Patrol 방향 랜덤 지정 </summary>
    private void SetRandomDir()
    {
        int ran_value = Random.Range(0, 2);
        this.dir_x = ran_value == 0 ? 1 : -1;
        this.transform.localScale = new Vector3(this.dir_x, 1, 1);
    }

    /// <summary> Trace 진입 체크 </summary>
    private void CheckEnemy()
    {
        // 몬스터가 바라보는 방향
        Vector3 monster_dir = Vector3.right * this.dir_x;

        // 몬스터를 기준으로 플레이어가 위치한 방향 
        // ( 플레이어 위치 - 몬스터 위치 = 몬스터 위치에서 플레이어 까지의 벡터 )
        Vector3 player_dir = (this.target_tf.position - this.transform.position).normalized;

        // 두 벡터의 내적 ( 음수 = 반대 , 양수 = 평행 )
        this.isTrace = Vector3.Dot(monster_dir, player_dir) > 0 ? true : false;
        if (this.target_dist <= trace_dist && isTrace)
        {
            this.timer = 0f;
            this.animator.SetBool(this.anim_bool_isRun, true);
            ChangeState(MonsterState.TRACE);
        }
    }
}
