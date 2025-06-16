using UnityEngine;

public class Door : MonoBehaviour, IDamageable
{
    public float hp;

    public void TakeDamage(float param_damage)
    {
        Debug.Log($"{param_damage} 데미지 받음");

        hp -= param_damage;
        if (hp <= 0)
        {
            this.Death();
        }
    }

    public void Death()
    {
        Debug.Log("문이 파괴되었습니다.");
    }



}