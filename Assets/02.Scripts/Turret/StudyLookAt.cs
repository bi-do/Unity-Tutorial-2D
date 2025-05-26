using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    /// <summary> 타겟 transform </summary>
    public Transform traget_tf;

    /// <summary> 터렛 수평 유지 용 ( 최종 타겟 transform )</summary>
    private Transform target_tf_end;

    public Transform turret_head;

    /// <summary> 터렛 x , z 각도 고정용 벡터 변수 </summary>
    private Vector3 vec3_y;

    /// <summary> 총알 오브젝트 </summary>
    public GameObject bullet_prefab;

    /// <summary> 총탄 발사 위치 </summary>
    public Transform fire_pos;

    public float timer = 0;
    public float cool_down_time = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.traget_tf = GameObject.FindGameObjectWithTag("Player").transform;

        this.vec3_y = new Vector3(0, this.turret_head.transform.position.y, 0);

        this.target_tf_end = new GameObject("Transform_temp").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 추적 각도 조정 ( x,z 축 고정 )
        target_tf_end.position = this.traget_tf.position + vec3_y;
        this.turret_head.LookAt(this.target_tf_end);

        timer += Time.deltaTime;
        if (timer > cool_down_time)
        {
            timer = 0;

            // 프리팹 복제 ( 생성 대상 , 생성 위치 , 회전 상태 )
            // 총탄 생성
            Instantiate(bullet_prefab, fire_pos.position, fire_pos.rotation);
        }
    }
}
