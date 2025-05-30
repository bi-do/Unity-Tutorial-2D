using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterMovement.coin_count++;
            Debug.Log($"코인 획득! 현재 코인 개수 = {CharacterMovement.coin_count}");
            Destroy(this.gameObject);
        }
    }
}
