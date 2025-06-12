using Unity.Collections;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    /// <summary> 랜덤으로 활성화 할 오브젝트 타입 </summary>
    public enum ColliderType
    {
        Pipe,
        Apple,
        Both
    }
    public ColliderType collider_type;

    public GameObject eat_effect;
    public GameObject apple;
    public GameObject pipe;

    /// <summary> 이동 속도 </summary>
    public float move_speed = 5f;

    /// <summary> 되돌아가는 기준 / 되돌아가는 pos </summary>
    private float return_pos_x = 15f;

    /// <summary> 랜덤 높이 </summary>
    private int random_height = 0;

    /// <summary> 파이프의 최대 높이 </summary>
    private int max_heigt = -4;

    /// <summary> 파이프의 최소 높이 </summary>
    private int min_heigt = -9;

    /// <summary> 게임 시작시 최초 배치 위치 </summary>
    private Vector2 init_pos;

    void Awake()
    {
        this.init_pos = this.transform.position;
    }

    void OnEnable()
    {
        Item_RePosition(this.init_pos.x);
    }

    void Update()
    {
        // 아이템 실시간 좌측 이동
        this.transform.position += Vector3.left * this.move_speed * Time.deltaTime;

        if (this.transform.position.x <= -this.return_pos_x)
        {
            Item_RePosition(this.return_pos_x);
        }
    }

    /// <summary> 아이템 재 위치 </summary>
    void Item_RePosition(float param_pos_x)
    {
        this.random_height = Random.Range(this.max_heigt, min_heigt);
        this.transform.position = new Vector3(param_pos_x, this.random_height, 0);

        this.collider_type = (ColliderType)Random.Range(0, 3);

        this.AllObjOff();

        switch (this.collider_type)
        {
            case ColliderType.Pipe:
                this.pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                this.apple.SetActive(true);
                break;
            case ColliderType.Both:
                this.apple.SetActive(true);
                this.pipe.SetActive(true);
                break;
        }
    }

    /// <summary> 파이프 및 사과 OFF </summary>
    void AllObjOff()
    {
        this.eat_effect.SetActive(false);
        this.apple.SetActive(false);
        this.pipe.SetActive(false);
    }
}
