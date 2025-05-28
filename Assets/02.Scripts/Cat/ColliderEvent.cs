using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("게임 오버");
        }
    }



    // /// <summary> 상호작용하는 둘 다 isTrigger = false일 경우 호출 </summary>
    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log($"{this.gameObject.name} : Collision Enter");
    // }

    // /// <summary> 상호작용하는 둘 중 하나라도 isTrigger = true일 경우 호출 </summary>
    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log($"{this.gameObject.name} : Trigger Enter");
    // }
}
