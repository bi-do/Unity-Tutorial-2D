using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator door_animator;

    void Start()
    {
        this.door_animator = this.GetComponent<Animator>();
    }

    // 콜라이더에 플레이어 접근 시 Open 트리거 파라미터 활성화
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.door_animator.SetTrigger("Open");
        }
    }

    // 콜라이더에서 플레이어가 벗어났을 시 Close 트리거 파라미터 활성화
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.door_animator.SetTrigger("Close");
        }
    }

}
